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
		VertexStatic() = default;

		explicit VertexStatic(glm::vec2 position)
			: m_position{position}
		{
		}

		glm::vec2 m_position{};
	};

	static_assert(std::is_standard_layout_v<VertexStatic>);
	static_assert(std::is_default_constructible_v<VertexStatic>);

	struct VertexDynamic
	{
		VertexDynamic() = default;

		explicit VertexDynamic(glm::vec2 uv, glm::vec4 color = glm::vec4(1.0f, 1.0f, 1.0f, 1.0f))
			: m_uv{uv}
			, m_color{color}
		{
		}

		glm::vec2 m_uv{};
		glm::vec4 m_color{};
	};

	static_assert(std::is_standard_layout_v<VertexDynamic>);
	static_assert(std::is_default_constructible_v<VertexDynamic>);

	struct Rect
	{
		Rect(glm::vec2 origin, glm::vec2 size)
			: m_origin{origin}
			, m_size{size}
		{
		}

		Rect(float x, float y, float width, float height)
			: m_origin{x, y}
			, m_size{width, height}
		{
		}

		glm::vec2 m_origin{};
		glm::vec2 m_size{};
	};

	struct Quad
	{
		explicit Quad(Rect rect)
			: m_top_left(rect.m_origin)
			, m_top_right(rect.m_origin + glm::vec2(rect.m_size.x, 0))
			, m_bottom_left{rect.m_origin + glm::vec2(0, rect.m_size.y)}
			, m_bottom_right{rect.m_origin + rect.m_size}
		{
		}

		Quad(glm::vec2 origin, glm::vec2 size)
			: Quad(Rect(origin, size))
		{
		}

		Quad(float x, float y, float width, float height)
			: Quad(Rect(x, y, width, height))
		{
		}

		glm::vec2 m_top_left{};
		glm::vec2 m_top_right{};
		glm::vec2 m_bottom_left{};
		glm::vec2 m_bottom_right{};
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
		std::vector<Quad> m_glyphs;
	};

	struct Window
	{
		Window(const Window& other) = delete;
		Window(Window&& other) noexcept = delete;
		Window& operator=(const Window& other) = delete;
		Window& operator=(Window&& other) noexcept = delete;

		explicit Window(glm::ivec2 size);

		GLFWwindow* m_handle{};
		glm::ivec2 m_size{};
		glm::mat4 m_projection{};
	};

	struct Grid
	{
		Grid(const Grid& other) = delete;
		Grid(Grid&& other) noexcept = delete;
		Grid& operator=(const Grid& other) = delete;
		Grid& operator=(Grid&& other) noexcept = delete;

		explicit Grid(fs::path font_path, glm::ivec2 grid_size);

		void put(int x, int y, int ch, glm::vec4 color);
		void put(glm::ivec2 position, int ch, glm::vec4 color);
		void draw();

		glm::ivec2 m_grid_size;

		Font m_font;
		Window m_window;
		FontTexture m_font_texture;

		gl::Program m_program;
		gl::VertexArray m_vao;
		gl::Buffer<r::VertexStatic> m_buffer_static;
		gl::Buffer<r::VertexDynamic> m_buffer_dynamic;
		gl::Buffer<uint16_t> m_buffer_index;
		GLsizei m_element_count{};

		bool m_is_dirty{};
		std::vector<r::VertexDynamic> m_data_dynamic{}; // TODO: maybe geometry shader for this
	};

	constexpr glm::ivec2 g_grid_size = {128, 45};
}
