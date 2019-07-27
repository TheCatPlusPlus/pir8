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

	static void main(std::vector<std::string> args)
	{
		std::optional<std::string> image{};

		if (!args.empty())
		{
			image = args[0];
		}

		auto grid = r::Grid("data/terminal10x16_gs_ro.png", r::g_grid_size);

		auto ch = 0;
		for (auto y = 0; y < grid.m_grid_size.y; ++y)
		{
			for (auto x = 0; x < grid.m_grid_size.x; ++x)
			{
				grid.put(x, y, ch, glm::vec4(1, 1, 1, 1));
				ch = (ch + 1) % grid.m_font_texture.m_glyphs.size();
			}
		}

		glfwSetKeyCallback(grid.m_window.m_handle, on_key);

		auto time = glfwGetTime();
		while (!glfwWindowShouldClose(grid.m_window.m_handle))
		{
			auto new_time = glfwGetTime();
			auto dt = new_time - time;
			time = new_time;

			glfwPollEvents();
			grid.draw();
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
