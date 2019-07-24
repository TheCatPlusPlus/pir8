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
#include <pir8/gl.hpp>
#include <pir8/render.hpp>

namespace pir8
{
	static void on_key(GLFWwindow* window, int key, int scancode, int action, int mods)
	{
		if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
		{
			glfwSetWindowShouldClose(window, GLFW_TRUE);
		}
	}

	static void on_resize(GLFWwindow*, int width, int height)
	{
		gl::viewport({width, height});
	}

	static void main(std::vector<std::string> args)
	{
		std::optional<std::string> image{};

		if (!args.empty())
		{
			image = args[0];
		}

		auto font = r::Font("data/terminal10x16_gs_ro.png");
		auto window = r::Window(r::g_grid_size * font.m_glyph_size);

		glfwSetKeyCallback(window.m_handle, on_key);
		glfwSetFramebufferSizeCallback(window.m_handle, on_resize);
		glfwSwapInterval(1);

		auto tex_font = r::FontTexture(font);

		std::vector<r::VertexStatic> buf_static_data{};
		std::vector<r::VertexDynamic> buf_dynamic_data{}; // TODO: maybe geometry shader for this
		std::vector<uint16_t> buf_index_data{};

		for (auto idx = 0; idx < tex_font.m_uvs.size(); ++idx)
		{
			auto grid_x = idx % r::g_grid_size.x;
			auto grid_y = idx / r::g_grid_size.x;

			auto size = glm::vec2(font.m_glyph_size);
			auto screen = glm::vec2(grid_x, grid_y) * size;
			auto uv = tex_font.m_uvs[idx];
			auto start = static_cast<uint16_t>(buf_static_data.size());

			buf_static_data.emplace_back(screen);
			buf_static_data.emplace_back(screen + glm::vec2(size.x, 0));
			buf_static_data.emplace_back(screen + size);
			buf_static_data.emplace_back(screen + glm::vec2(0, size.y));

			buf_dynamic_data.emplace_back(uv.origin);
			buf_dynamic_data.emplace_back(uv.origin + glm::vec2(uv.size.x, 0));
			buf_dynamic_data.emplace_back(uv.origin + uv.size);
			buf_dynamic_data.emplace_back(uv.origin + glm::vec2(0, uv.size.y));

			buf_index_data.emplace_back(start + 0);
			buf_index_data.emplace_back(start + 1);
			buf_index_data.emplace_back(start + 2);

			buf_index_data.emplace_back(start + 0);
			buf_index_data.emplace_back(start + 2);
			buf_index_data.emplace_back(start + 3);
		}

		auto buf_static = gl::create<gl::Buffer<r::VertexStatic>>("buf_static");
		auto buf_dynamic = gl::create<gl::Buffer<r::VertexDynamic>>("buf_dynamic");
		auto buf_index = gl::create<gl::Buffer<uint16_t>>("buf_index");

		buf_static.allocate(buf_static_data);
		buf_dynamic.allocate(buf_dynamic_data, gl::BufferUsage::DynamicStorage);
		buf_index.allocate(buf_index_data);

		auto vao = gl::create<gl::VertexArray>("vao");

		auto vao_static = vao.bind(buf_static);
		auto vao_dynamic = vao.bind(buf_dynamic);

		vao.add(vao_static, gl::AttribSize::Two, gl::AttribType::Float, offsetof(r::VertexStatic, position));
		vao.add(vao_dynamic, gl::AttribSize::Two, gl::AttribType::Float, offsetof(r::VertexDynamic, uv));
		vao.add(vao_dynamic, gl::AttribSize::Four, gl::AttribType::Float, offsetof(r::VertexDynamic, color));

		auto shader_vertex = gl::create<gl::VertexShader>("shader_vertex");
		auto shader_fragment = gl::create<gl::FragmentShader>("shader_fragment");
		auto program = gl::create<gl::Program>("program");

		shader_vertex.compile(read_file("data/shader_vertex.glsl"));
		shader_fragment.compile(read_file("data/shader_fragment.glsl"));
		program.link(shader_vertex, shader_fragment);

		vao.bind();
		buf_index.bind_to(gl::BufferTarget::ElementArray);
		tex_font.m_texture.bind_to(0);
		program.use();

		auto time = glfwGetTime();
		while (!glfwWindowShouldClose(window.m_handle))
		{
			auto new_time = glfwGetTime();
			auto dt = new_time - time;
			time = new_time;

			glfwPollEvents();

			gl::clear(gl::Clear::Color);
			gl::draw_elements(static_cast<GLsizei>(buf_index_data.size()));
			glfwSwapBuffers(window.m_handle);
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
