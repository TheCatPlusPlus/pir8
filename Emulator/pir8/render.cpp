#include <pir8/pch.hpp>

#include <fstream>

#include <pir8/render.hpp>
#include <pir8/gl.hpp>

#include <stb_image.h>

namespace pir8::r
{
	Window::Window(glm::ivec2 size)
		: m_size{size}
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
		: m_texture{gl::create<gl::Texture>("tex_font")}
	{
		auto glyph_count = font.m_size / font.m_glyph_size;

		for (auto idx = 0; idx < (glyph_count.x * glyph_count.y); ++idx)
		{
			auto x = (idx % glyph_count.x) * font.m_glyph_size.x;
			auto y = (idx / glyph_count.x) * font.m_glyph_size.y;

			auto origin = glm::vec2(x, y) / glm::vec2(font.m_size);
			auto size = glm::vec2(font.m_glyph_size) / glm::vec2(font.m_size);

			m_uvs.emplace_back(origin, size);
		}

		m_texture.set(gl::MagFilter::Nearest);
		m_texture.set(gl::MinFilter::Nearest);
		m_texture.set(gl::Wrap::S, gl::WrapMode::ClampToEdge);
		m_texture.set(gl::Wrap::T, gl::WrapMode::ClampToEdge);

		m_texture.allocate(gl::TextureFormat::RGB8, font.m_size.x, font.m_size.y);
		m_texture.upload(font.m_pixels);
	}
}
