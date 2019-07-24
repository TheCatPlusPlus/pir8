#include <pir8/pch.hpp>

#include <vector>
#include <string>
#include <optional>

#include <glad/glad.h>
#include <GLFW/glfw3.h>

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>

#include <stb_image.h>

#include <gsl/span>

#include <pir8/utils.hpp>

namespace pir8
{
	static void on_glfw_error(int error, const char* description)
	{
		fmt::print(std::cerr, "[glfw] (0x{:08X}) {}\n", error, description);
	}

	static void on_gl_error(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, const GLchar* message, const void* user)
	{
		std::string_view source_str;
		std::string_view type_str;
		std::string_view severity_str;
		std::string_view message_str(message, length);

		switch (source)
		{
		case GL_DEBUG_SOURCE_API:
			source_str = "API";
			break;
		case GL_DEBUG_SOURCE_APPLICATION:
			source_str = "App";
			break;
		case GL_DEBUG_SOURCE_WINDOW_SYSTEM:
			source_str = "WM";
			break;
		case GL_DEBUG_SOURCE_THIRD_PARTY:
			source_str = "Vendor";
			break;
		case GL_DEBUG_SOURCE_SHADER_COMPILER:
			source_str = "GLSL";
			break;
		case GL_DEBUG_SOURCE_OTHER:
			source_str = "Other";
			break;
		default:
			source_str = "<unknown source>";
			break;
		}

		switch (type)
		{
		case GL_DEBUG_TYPE_ERROR:
			type_str = "Error";
			break;
		case GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR:
			type_str = "Deprecated";
			break;
		case GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR:
			type_str = "UB";
			break;
		case GL_DEBUG_TYPE_PORTABILITY:
			type_str = "Portability";
			break;
		case GL_DEBUG_TYPE_PERFORMANCE:
			type_str = "Performance";
			break;
		case GL_DEBUG_TYPE_MARKER:
			type_str = "Marker";
			break;
		case GL_DEBUG_TYPE_PUSH_GROUP:
			type_str = "Push group";
			break;
		case GL_DEBUG_TYPE_POP_GROUP:
			type_str = "Pop group";
			break;
		case GL_DEBUG_TYPE_OTHER:
			type_str = "Other";
			break;
		default:
			type_str = "<unknown type>";
			break;
		}

		switch (severity)
		{
		case GL_DEBUG_SEVERITY_HIGH:
			severity_str = "High";
			break;
		case GL_DEBUG_SEVERITY_MEDIUM:
			severity_str = "Med";
			break;
		case GL_DEBUG_SEVERITY_LOW:
			severity_str = "Low";
			break;
		case GL_DEBUG_SEVERITY_NOTIFICATION:
			severity_str = "Notify";
			break;
		default:
			severity_str = "<unknown severity>";
			break;
		}

		fmt::print(std::cerr, "[gl] [{}] [{}] [{}] [{}] {}\n", source_str, type_str, severity_str, id, message_str);
	}

	static void set_debug_name(GLuint type, GLuint object, std::string_view name)
	{
		glObjectLabel(type, object, static_cast<GLsizei>(name.size()), name.data());
	}

	static void* on_glad_load_func(const char* name)
	{
		return glfwGetProcAddress(name);
	}

	static void on_key(GLFWwindow* window, int key, int scancode, int action, int mods)
	{
		if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
		{
			glfwSetWindowShouldClose(window, GLFW_TRUE);
		}
	}

	static void on_resize(GLFWwindow*, int width, int height)
	{
		glViewport(0, 0, width, height);
	}

	static void main(std::vector<std::string> args)
	{
		std::optional<std::string> image{};

		if (!args.empty())
		{
			image = args[0];
		}

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

		int font_width{};
		int font_height{};
		int font_channels{};
		auto font_pixels = stbi_load("data/terminal10x16_gs_ro.png", &font_width, &font_height, &font_channels, 0);
		PIR8_ENSUREM(font_pixels, "stbi_load(data/terminal10x16_gs_ro.png)");

		fmt::print(std::cerr, "font = {}x{}:{}\n", font_width, font_height, font_channels);

		auto glyph_width = 10;
		auto glyph_height = 16;
		auto font_glyphs_per_row = font_width / glyph_width;
		auto font_glyph_rows = font_height / glyph_height;

		std::vector<glm::vec2> font_uv{};
		for (auto glyph_idx = 0; glyph_idx < (font_glyph_rows * font_glyphs_per_row); ++glyph_idx)
		{
			auto glyph_x = (glyph_idx % font_glyphs_per_row) * glyph_width;
			auto glyph_y = (glyph_idx / font_glyphs_per_row) * glyph_height;

			auto glyph_u = static_cast<float>(glyph_x) / font_width;
			auto glyph_v = static_cast<float>(glyph_y) / font_height;

			font_uv.emplace_back(glm::vec2(glyph_u, glyph_v));
		}

		auto grid_width = 128;
		auto grid_height = 45;
		auto width = glyph_width * grid_width;
		auto height = glyph_height * grid_height;
		auto window = glfwCreateWindow(width, height, "PIR8", nullptr, nullptr);
		PIR8_ENSUREM(window, "glfwCreateWindow");

		auto window_x = monitor_x + (monitor_width / 2 - width / 2);
		auto window_y = monitor_y + (monitor_height / 2 - height / 2);
		glfwSetWindowPos(window, window_x, window_y);
		glfwShowWindow(window);

		glfwMakeContextCurrent(window);
		PIR8_ENSURE(gladLoadGLLoader(on_glad_load_func));

		glDebugMessageCallback(on_gl_error, nullptr);
		glEnable(GL_DEBUG_OUTPUT_SYNCHRONOUS);
		glEnable(GL_DEBUG_OUTPUT);

		glfwSetKeyCallback(window, on_key);
		glfwSetFramebufferSizeCallback(window, on_resize);
		glfwSwapInterval(1);

		GLuint font_texture{};
		glCreateTextures(GL_TEXTURE_2D, 1, &font_texture);
		set_debug_name(GL_TEXTURE, font_texture, "font_texture");

		glTextureParameteri(font_texture, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
		glTextureParameteri(font_texture, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
		glTextureParameteri(font_texture, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
		glTextureParameteri(font_texture, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);

		glTextureStorage2D(font_texture, 1, GL_RGB8, font_width, font_height);
		glTextureSubImage2D(font_texture, 0, 0, 0, font_width, font_height, GL_RGB, GL_UNSIGNED_BYTE, font_pixels);
		stbi_image_free(font_pixels);

		std::vector<glm::vec2> grid_positions{};
		std::vector<glm::vec2> grid_uvs{};
		for (auto glyph_idx = 0; glyph_idx < font_uv.size(); ++glyph_idx)
		{
			auto grid_x = glyph_idx % grid_width;
			auto grid_y = glyph_idx / grid_width;

			auto grid_screen_x = grid_x * glyph_width;
			auto grid_screen_y = grid_y * glyph_height;

			grid_positions.emplace_back(glm::vec2(grid_screen_x, grid_screen_y));
			grid_uvs.emplace_back(font_uv[glyph_idx]);
		}

		GLuint positions_buffer{};
		GLuint uvs_buffer{};
		glCreateBuffers(1, &positions_buffer);
		glCreateBuffers(1, &uvs_buffer);

		set_debug_name(GL_BUFFER, positions_buffer, "positions_buffer");
		set_debug_name(GL_BUFFER, uvs_buffer, "uvs_buffer");

		auto positions_span = gsl::span<glm::vec2>(grid_positions);
		auto positions_byte_span = gsl::as_bytes(positions_span);

		auto uvs_span = gsl::span<glm::vec2>(grid_uvs);
		auto uvs_byte_span = gsl::as_bytes(uvs_span);

		glNamedBufferStorage(positions_buffer, positions_byte_span.size(), positions_byte_span.data(), 0);
		glNamedBufferStorage(uvs_buffer, uvs_byte_span.size(), uvs_byte_span.data(), GL_DYNAMIC_STORAGE_BIT);

		GLuint vao{};
		glCreateVertexArrays(1, &vao);
		set_debug_name(GL_VERTEX_ARRAY, vao, "vao");

		glEnableVertexArrayAttrib(vao, 0);
		glVertexArrayVertexBuffer(vao, 0, positions_buffer, 0, sizeof(glm::vec2));
		glVertexArrayAttribFormat(vao, 0, 2, GL_FLOAT, GL_FALSE, 0);

		glEnableVertexArrayAttrib(vao, 1);
		glVertexArrayVertexBuffer(vao, 1, uvs_buffer, 0, sizeof(glm::vec2));
		glVertexArrayAttribFormat(vao, 1, 2, GL_FLOAT, GL_FALSE, 0);

		auto projection = glm::ortho(0, width, height, 0);

		auto time = glfwGetTime();
		while (!glfwWindowShouldClose(window))
		{
			auto new_time = glfwGetTime();
			auto dt = new_time - time;
			time = new_time;

			glfwPollEvents();

			glBindTextureUnit(0, font_texture);
			glClear(GL_COLOR_BUFFER_BIT);

			glfwSwapBuffers(window);
		}
	}
}

int main(int argc, char** argv)
{
	std::vector<std::string> args{};
	args.reserve(argc);

	for (auto idx = 1; idx < argc; ++idx)
	{
		args.emplace_back(argv[idx]);
	}

	pir8::main(args);
	return 0;
}
