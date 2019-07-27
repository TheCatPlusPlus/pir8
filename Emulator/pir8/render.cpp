#include <pir8/pch.hpp>

#include <fstream>

#include <pir8/render.hpp>
#include <pir8/gl.hpp>

#include <stb_image.h>

namespace pir8::r
{
	static glm::mat4 ortho(glm::vec2 size)
	{
		return glm::ortho(0.0f, size.x, size.y, 0.0f, -1.0f, 1.0f);
	}

	Window::Window(glm::ivec2 size)
		: m_size(size)
		, m_projection(ortho(glm::vec2(size.x, size.y)))
	{
		auto&& gl_loader = [](const char* name) -> void*
		{
			return glfwGetProcAddress(name);
		};

		auto&& on_gl_message = [](GLuint id, gl::DebugSource source, gl::DebugType type, gl::DebugSeverity severity, std::string_view message)
		{
			fmt::print(std::cerr, "[OpenGL] [0x{:08X}] [{}] [{}] [{}]\n\t{}\n", id, to_string(source), to_string(type), to_string(severity), message);
		};

		auto&& on_glfw_error = [](int error, const char* message)
		{
			fmt::print(std::cerr, "[GLFW] [0x{:08X}]\n\t{}\n", error, message);
		};

		auto&& on_framebuffer_size = [](GLFWwindow*, int width, int height)
		{
			gl::viewport({width, height});
		};

		PIR8_ENSURE(glfwInit());
		glfwSetErrorCallback(on_glfw_error);

		glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
		glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 6);
		glfwWindowHint(GLFW_OPENGL_DEBUG_CONTEXT, GLFW_TRUE);
		glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GLFW_TRUE);
		glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
		glfwWindowHint(GLFW_VISIBLE, GLFW_FALSE);

		auto monitor = glfwGetPrimaryMonitor();
		PIR8_ENSUREM(monitor, "glfwGetPrimaryMonitor");

		int monitor_x{};
		int monitor_y{};
		int monitor_width{};
		int monitor_height{};
		glfwGetMonitorWorkarea(monitor, &monitor_x, &monitor_y, &monitor_width, &monitor_height);

		auto width = size.x;
		auto height = size.y;
		m_handle = glfwCreateWindow(width, height, "PIR8", nullptr, nullptr);
		PIR8_ENSUREM(m_handle, "glfwCreateWindow");

		auto x = monitor_x + (monitor_width / 2 - width / 2);
		auto y = monitor_y + (monitor_height / 2 - height / 2);
		glfwSetWindowPos(m_handle, x, y);

		glfwShowWindow(m_handle);
		glfwMakeContextCurrent(m_handle);

		PIR8_ENSURE(gladLoadGLLoader(gl_loader));
		gl::set_debug_callback(on_gl_message);

		glfwSetFramebufferSizeCallback(m_handle, on_framebuffer_size);
		glfwSwapInterval(1);
	}

	Font::Font(fs::path path)
	{
		int width{};
		int height{};
		int glyph_width{};
		int glyph_height{};

		auto metrics_path = path.replace_extension("txt").string();

		auto pixels = stbi_load("data/terminal10x16_gs_ro.png", &width, &height, &m_channels, 0);
		PIR8_ENSUREF(pixels, "stbi_load({})", path);
		auto pixels_span = gsl::as_bytes(gsl::span(pixels, pixels + (width * height * m_channels)));

		std::ifstream glyph_metrics(metrics_path, std::ios::binary | std::ios::in);
		glyph_metrics.exceptions(std::ios::failbit | std::ios::badbit);
		glyph_metrics >> glyph_width >> glyph_height;

		m_pixels.assign(pixels_span.begin(), pixels_span.end());
		stbi_image_free(pixels);

		m_size = {width, height};
		m_glyph_size = {glyph_width, glyph_height};
	}

	FontTexture::FontTexture(const Font& font)
		: m_texture("tex_font")
	{
		auto glyph_count = font.m_size / font.m_glyph_size;

		for (auto idx = 0; idx < (glyph_count.x * glyph_count.y); ++idx)
		{
			auto x = (idx % glyph_count.x) * font.m_glyph_size.x;
			auto y = (idx / glyph_count.x) * font.m_glyph_size.y;

			auto origin = glm::vec2(x, y) / glm::vec2(font.m_size);
			auto size = glm::vec2(font.m_glyph_size) / glm::vec2(font.m_size);

			m_glyphs.emplace_back(origin, size);
		}

		m_texture.set(gl::MagFilter::Nearest);
		m_texture.set(gl::MinFilter::Nearest);
		m_texture.set(gl::Wrap::S, gl::WrapMode::ClampToEdge);
		m_texture.set(gl::Wrap::T, gl::WrapMode::ClampToEdge);

		m_texture.allocate(gl::TextureFormat::RGB8, font.m_size.x, font.m_size.y);
		m_texture.upload(font.m_pixels);
	}

	Grid::Grid(fs::path font_path, glm::ivec2 grid_size)
		: m_grid_size(grid_size)
		, m_font(font_path)
		, m_window(grid_size * m_font.m_glyph_size)
		, m_font_texture(m_font)
		, m_program("grid_program")
		, m_vao("grid_vao")
		, m_buffer_static("grid_buffer_static")
		, m_buffer_dynamic("grid_buffer_dynamic")
		, m_buffer_index("grid_buffer_index")
	{
		m_font.m_pixels.clear();

		std::vector<r::VertexStatic> data_static{};
		std::vector<uint16_t> data_index{};

		auto data_count = static_cast<size_t>(grid_size.x * grid_size.y * 4);
		auto index_count = static_cast<size_t>(grid_size.x * grid_size.y * 6);

		m_element_count = static_cast<GLsizei>(index_count);
		data_static.reserve(data_count);
		data_index.reserve(index_count);

		m_data_dynamic.resize(data_count);

		for (auto y = 0; y < grid_size.y; ++y)
		{
			for (auto x = 0; x < grid_size.x; ++x)
			{
				auto size = glm::vec2(m_font.m_glyph_size);
				auto origin = glm::vec2(x, y) * size;

				auto quad = Quad(origin, size);
				auto offset = static_cast<uint16_t>(data_static.size());

				data_static.emplace_back(quad.m_top_left);
				data_static.emplace_back(quad.m_top_right);
				data_static.emplace_back(quad.m_bottom_right);
				data_static.emplace_back(quad.m_bottom_left);

				data_index.emplace_back(offset + 0);
				data_index.emplace_back(offset + 1);
				data_index.emplace_back(offset + 2);

				data_index.emplace_back(offset + 0);
				data_index.emplace_back(offset + 2);
				data_index.emplace_back(offset + 3);
			}
		}

		m_buffer_static.allocate(data_static);
		m_buffer_index.allocate(data_index);
		m_buffer_dynamic.allocate(m_data_dynamic, gl::BufferUsage::DynamicStorage);

		m_vao.bind();
		auto vao_static = m_vao.add_buffer(m_buffer_static);
		auto vao_dynamic = m_vao.add_buffer(m_buffer_dynamic);

		m_vao.add(vao_static, gl::AttribSize::Two, gl::AttribType::Float, offsetof(r::VertexStatic, m_position));
		m_vao.add(vao_dynamic, gl::AttribSize::Two, gl::AttribType::Float, offsetof(r::VertexDynamic, m_uv));
		m_vao.add(vao_dynamic, gl::AttribSize::Four, gl::AttribType::Float, offsetof(r::VertexDynamic, m_color));

		auto shader_vs = gl::VertexShader("grid_program_vs");
		auto shader_fs = gl::FragmentShader("grid_program_fs");

		shader_vs.compile(read_file("data/shader_vertex.glsl"));
		shader_fs.compile(read_file("data/shader_fragment.glsl"));
		m_program.link(shader_vs, shader_fs);
		m_program.use();

		gl::set_uniform(0, m_window.m_projection);
		gl::set_uniform(1, 0);

		gl::clear_color(glm::vec4(0, 0, 0, 1));
	}

	void Grid::draw()
	{
		if (m_is_dirty)
		{
			m_buffer_dynamic.upload(m_data_dynamic);
			m_is_dirty = false;
		}

		m_buffer_index.bind_to(gl::BufferTarget::ElementArray);
		m_font_texture.m_texture.bind_to(0);
		m_vao.bind();
		m_program.use();

		gl::clear(gl::Clear::Color);
		gl::draw_elements(m_element_count);
		glfwSwapBuffers(m_window.m_handle);
	}

	void Grid::put(int x, int y, int ch, glm::vec4 color)
	{
		put({x, y}, ch, color);
	}

	void Grid::put(glm::ivec2 position, int ch, glm::vec4 color)
	{
		auto offset = (position.x * 4) + (position.y * m_grid_size.x * 4);
		auto glyph = m_font_texture.m_glyphs.at(ch);

		m_data_dynamic.at(offset + 0) = r::VertexDynamic(glyph.m_top_left, color);
		m_data_dynamic.at(offset + 1) = r::VertexDynamic(glyph.m_top_right, color);
		m_data_dynamic.at(offset + 2) = r::VertexDynamic(glyph.m_bottom_right, color);
		m_data_dynamic.at(offset + 3) = r::VertexDynamic(glyph.m_bottom_left, color);

		m_is_dirty = true;
	}
}
