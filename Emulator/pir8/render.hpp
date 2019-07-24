#pragma once

#include <type_traits>
#include <string_view>
#include <vector>

#include <glad/glad.h>
#include <glm/glm.hpp>
#include <GLFW/glfw3.h>

#include <boost/filesystem.hpp>

#include <pir8/gl.hpp>

namespace pir8::r
{
	struct VertexStatic
	{
		explicit VertexStatic(glm::vec2 position)
			: position{position}
		{
		}

		glm::vec2 position;
	};

	static_assert(std::is_standard_layout_v<VertexStatic>);

	struct VertexDynamic
	{
		explicit VertexDynamic(glm::vec2 uv, glm::vec4 color = glm::vec4(1.0f, 1.0f, 1.0f, 1.0f))
			: uv{uv}
			, color{color}
		{
		}

		glm::vec2 uv;
		glm::vec4 color;
	};

	static_assert(std::is_standard_layout_v<VertexDynamic>);

	struct Rect
	{
		Rect(glm::vec2 origin, glm::vec2 size)
			: origin{origin}
			, size{size}
		{
		}

		Rect(float x, float y, float width, float height)
			: origin{x, y}
			, size{width, height}
		{
		}

		glm::vec2 origin{};
		glm::vec2 size{};
	};

	struct Font
	{
		Font(const Font& other) = delete;
		Font(Font&& other) noexcept = default;
		Font& operator=(const Font& other) = delete;
		Font& operator=(Font&& other) noexcept = default;

		explicit Font(fs::path path);

		glm::ivec2 m_glyph_size{};
		glm::ivec2 m_size{};
		int m_channels{};
		std::vector<std::byte> m_pixels{};
	};

	struct FontTexture
	{
		FontTexture(const FontTexture& other) = delete;
		FontTexture(FontTexture&& other) noexcept = default;
		FontTexture& operator=(const FontTexture& other) = delete;
		FontTexture& operator=(FontTexture&& other) noexcept = default;

		explicit FontTexture(const Font& font);

		gl::Texture m_texture;
		std::vector<Rect> m_uvs;
	};

	struct Window
	{
		Window(const Window& other) = delete;
		Window(Window&& other) noexcept = delete;
		Window& operator=(const Window& other) = delete;
		Window& operator=(Window&& other) noexcept = delete;

		explicit Window(glm::ivec2 size);

		GLFWwindow* m_handle{};
	};

	constexpr glm::ivec2 g_grid_size = {128, 45};
}
