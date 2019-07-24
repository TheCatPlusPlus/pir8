#pragma once

#include <type_traits>
#include <string_view>

#include <gsl/span>

#include <glad/glad.h>
#include <glm/glm.hpp>

#include <pir8/utils.hpp>

namespace pir8::gl
{
	enum class MagFilter : GLint
	{
		Nearest = GL_NEAREST,
		Linear = GL_LINEAR,
		NearestMipmapNearest = GL_NEAREST_MIPMAP_NEAREST,
		LinearMipmapNearest = GL_LINEAR_MIPMAP_NEAREST,
		NearestMipmapLinear = GL_NEAREST_MIPMAP_LINEAR,
		LinearMipmapLinear = GL_LINEAR_MIPMAP_LINEAR,
	};

	enum class MinFilter : GLint
	{
		Nearest = GL_NEAREST,
		Linear = GL_LINEAR,
	};

	enum class Wrap : GLenum
	{
		S = GL_TEXTURE_WRAP_S,
		T = GL_TEXTURE_WRAP_T,
		R = GL_TEXTURE_WRAP_R,
	};

	enum class WrapMode : GLint
	{
		ClampToEdge = GL_CLAMP_TO_EDGE,
		ClampToBorder = GL_CLAMP_TO_BORDER,
		MirroredRepeat = GL_MIRRORED_REPEAT,
		Repeat = GL_REPEAT,
		MirrorClampToEdge = GL_MIRROR_CLAMP_TO_EDGE,
	};

	enum class TextureFormat : GLenum
	{
		RGB8 = GL_RGB8,
	};

	enum class PixelFormat : GLenum
	{
		RGB = GL_RGB,
		Depth = GL_DEPTH_COMPONENT,
		Stencil = GL_STENCIL_INDEX,
	};

	enum class AttribType : GLenum
	{
		Float = GL_FLOAT,
	};

	enum class AttribSize : GLint
	{
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
	};

	enum class BufferUsage : GLbitfield
	{
		None = 0,
		DynamicStorage = GL_DYNAMIC_STORAGE_BIT,
		MapRead = GL_MAP_READ_BIT,
		MapWrite = GL_MAP_WRITE_BIT,
		MapPersistent = GL_MAP_PERSISTENT_BIT,
		MapCoherent = GL_MAP_COHERENT_BIT,
		ClientStorage = GL_CLIENT_STORAGE_BIT,
	};

	enum class Clear : GLbitfield
	{
		None = 0,
		Color = GL_COLOR_BUFFER_BIT,
		Depth = GL_DEPTH_BUFFER_BIT,
		Stencil = GL_STENCIL_BUFFER_BIT
	};

	enum class DebugSource : GLenum
	{
		API = GL_DEBUG_SOURCE_API,
		Application = GL_DEBUG_SOURCE_APPLICATION,
		WindowSystem = GL_DEBUG_SOURCE_WINDOW_SYSTEM,
		ThirdParty = GL_DEBUG_SOURCE_THIRD_PARTY,
		ShaderCompiler = GL_DEBUG_SOURCE_SHADER_COMPILER,
		Other = GL_DEBUG_SOURCE_OTHER,
	};

	enum class DebugType : GLenum
	{
		Error = GL_DEBUG_TYPE_ERROR,
		DeprecatedBehavior = GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR,
		UndefinedBehavior = GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR,
		Portability = GL_DEBUG_TYPE_PORTABILITY,
		Performance = GL_DEBUG_TYPE_PERFORMANCE,
		Marker = GL_DEBUG_TYPE_MARKER,
		PushGroup = GL_DEBUG_TYPE_PUSH_GROUP,
		PopGroup = GL_DEBUG_TYPE_POP_GROUP,
		Other = GL_DEBUG_TYPE_OTHER,
	};

	enum class DebugSeverity : GLenum
	{
		High = GL_DEBUG_SEVERITY_HIGH,
		Medium = GL_DEBUG_SEVERITY_MEDIUM,
		Low = GL_DEBUG_SEVERITY_LOW,
		Notification = GL_DEBUG_SEVERITY_NOTIFICATION,
	};

	enum class BufferTarget : GLenum
	{
		ElementArray = GL_ELEMENT_ARRAY_BUFFER,
	};

	enum class DrawMode : GLenum
	{
		Points = GL_POINTS,
		LineStrip = GL_LINE_STRIP,
		LineLoop = GL_LINE_LOOP,
		Lines = GL_LINES,
		LineStripAdjacency = GL_LINE_STRIP_ADJACENCY,
		TriangleStrip = GL_TRIANGLE_STRIP,
		TriangleFan = GL_TRIANGLE_FAN,
		Triangles = GL_TRIANGLES,
		TriangleStripAdjacency = GL_TRIANGLE_STRIP_ADJACENCY,
		Patches = GL_PATCHES,
	};

	enum class IndexType : GLenum
	{
		U8 = GL_UNSIGNED_BYTE,
		U16 = GL_UNSIGNED_SHORT,
		U32 = GL_UNSIGNED_INT,
	};

	PIR8_FLAGS(BufferUsage)

	template <typename T>
	struct Buffer
	{
		explicit Buffer(GLuint id)
			: m_id{id}
		{
		}

		void allocate(gsl::span<const T> data, BufferUsage flags = BufferUsage::None)
		{
			PIR8_ENSURE(m_size == 0);
			PIR8_ENSURE(!data.empty());

			auto data_bytes = gsl::as_bytes(data);
			m_size = static_cast<GLsizeiptr>(data_bytes.size());
			glNamedBufferStorage(m_id, m_size, data_bytes.data(), static_cast<GLbitfield>(flags));
		}

		void allocate(GLsizeiptr size, BufferUsage flags = BufferUsage::None)
		{
			PIR8_ENSURE(m_size == 0);
			PIR8_ENSURE(size > 0);

			m_size = size;
			glNamedBufferStorage(m_id, size, nullptr, static_cast<GLbitfield>(flags));
		}

		void upload(gsl::span<const T> data, GLintptr offset = 0)
		{
			PIR8_ENSURE(m_size != 0);
			PIR8_ENSURE(!data.empty());
			PIR8_ENSURE(offset + data.size_bytes() <= m_size);

			auto data_bytes = gsl::as_bytes(data);
			glNamedBufferSubData(m_id, offset, static_cast<GLsizeiptr>(data_bytes.size()), data_bytes.data());
		}

		void bind_to(BufferTarget target)
		{
			glBindBuffer(static_cast<GLenum>(target), m_id);
		}

		GLuint m_id{};
		GLsizeiptr m_size{};
	};

	struct Texture
	{
		explicit Texture(GLuint id)
			: m_id{id}
		{
		}

		void set(MagFilter filter)
		{
			glTextureParameteri(m_id, GL_TEXTURE_MAG_FILTER, static_cast<GLint>(filter));
		}

		void set(MinFilter filter)
		{
			glTextureParameteri(m_id, GL_TEXTURE_MIN_FILTER, static_cast<GLint>(filter));
		}

		void set(Wrap wrap, WrapMode mode)
		{
			glTextureParameteri(m_id, static_cast<GLenum>(wrap), static_cast<GLint>(mode));
		}

		void allocate(TextureFormat format, GLsizei width, GLsizei height, GLint levels = 1)
		{
			PIR8_ENSURE(m_width == 0 && m_height == 0);
			m_width = width;
			m_height = height;
			m_levels = levels;
			glTextureStorage2D(m_id, levels, static_cast<GLenum>(format), width, height);
		}

		void upload(gsl::span<const std::byte> data, PixelFormat format = PixelFormat::RGB, GLint level = 0)
		{
			PIR8_ENSURE(level >= 0 && level < m_levels);
			PIR8_ENSURE(m_width != 0 && m_height != 0);
			glTextureSubImage2D(m_id, level, 0, 0, m_width, m_height, static_cast<GLenum>(format), GL_UNSIGNED_BYTE, data.data());
		}

		void bind_to(GLuint unit)
		{
			PIR8_ENSURE(m_width != 0 && m_height != 0);
			glBindTextureUnit(unit, m_id);
		}

		GLuint m_id{};
		GLsizei m_width{};
		GLsizei m_height{};
		GLint m_levels{};
	};

	struct VertexArrayAttrib
	{
		VertexArrayAttrib(GLuint vao, GLuint index)
			: m_vao{vao}
			, m_index{index}
		{
		}

		GLuint m_vao{};
		GLuint m_index{};
	};

	struct VertexArrayBuffer
	{
		VertexArrayBuffer(GLuint vao, GLuint index)
			: m_vao{vao}
			, m_index{index}
		{
		}

		GLuint m_vao{};
		GLuint m_index{};
	};

	struct VertexArray
	{
		explicit VertexArray(GLuint id)
			: m_id{id}
		{
		}

		VertexArrayAttrib add(VertexArrayBuffer buffer, AttribSize size, AttribType type, GLuint offset)
		{
			PIR8_ENSURE(buffer.m_vao == m_id);

			auto attrib_index = m_next_attrib++;
			glEnableVertexArrayAttrib(m_id, attrib_index);
			glVertexArrayAttribFormat(m_id, attrib_index, static_cast<GLint>(size), static_cast<GLenum>(type), GL_FALSE, offset);
			glVertexArrayAttribBinding(m_id, attrib_index, buffer.m_index);
			return VertexArrayAttrib(m_id, attrib_index);
		}

		template <typename T>
		VertexArrayBuffer bind(Buffer<T> buffer, GLintptr offset = 0)
		{
			auto buffer_index = m_next_buffer++;
			glVertexArrayVertexBuffer(m_id, buffer_index, buffer.m_id, offset, static_cast<GLsizei>(sizeof(T)));
			return VertexArrayBuffer(m_id, buffer_index);
		}

		void bind()
		{
			glBindVertexArray(m_id);
		}

		GLuint m_id{};
		GLuint m_next_buffer{};
		GLuint m_next_attrib{};
	};

	template <GLuint Type>
	struct Shader
	{
		explicit Shader(GLuint id)
			: m_id{id}
		{
		}

		void compile(gsl::span<const std::byte> source)
		{
			auto ptr = reinterpret_cast<const GLchar*>(source.data());
			auto length = static_cast<GLint>(source.size());
			glShaderSource(m_id, 1, &ptr, &length);
			glCompileShader(m_id);

			GLint status{};
			glGetShaderiv(m_id, GL_COMPILE_STATUS, &status);
			PIR8_ENSUREM(status == GL_TRUE, "glCompileShader");
		}

		GLuint m_id;
	};

	using VertexShader = Shader<GL_VERTEX_SHADER>;
	using FragmentShader = Shader<GL_FRAGMENT_SHADER>;

	struct Program
	{
		explicit Program(GLuint id)
			: m_id{id}
		{
		}

		template <typename... Args>
		void link(Args&&... shaders)
		{
			attach(std::forward<Args>(shaders)...);
			glLinkProgram(m_id);
			detach(std::forward<Args>(shaders)...);

			GLint status{};
			glGetProgramiv(m_id, GL_LINK_STATUS, &status);
			PIR8_ENSUREM(status == GL_TRUE, "glLinkProgram");
		}

		void use()
		{
			glUseProgram(m_id);
		}

	private:
		void attach()
		{
		}

		template <typename T, typename... Args>
		void attach(T shader, Args&&... rest)
		{
			glAttachShader(m_id, shader.m_id);
			attach(std::forward<Args>(rest)...);
		}

		void detach()
		{
		}

		template <typename T, typename... Args>
		void detach(T shader, Args&&... rest)
		{
			glDetachShader(m_id, shader.m_id);
			detach(std::forward<Args>(rest)...);
		}

	public:
		GLuint m_id;
	};

	template <typename T>
	struct Namespace
	{
	};

	template <typename T>
	struct Namespace<Buffer<T>>
	{
		static constexpr GLuint value = GL_BUFFER;

		static GLuint create()
		{
			GLuint id{};
			glCreateBuffers(1, &id);
			return id;
		}
	};

	template <>
	struct Namespace<Texture>
	{
		static constexpr GLuint value = GL_TEXTURE;

		static GLuint create()
		{
			GLuint id{};
			glCreateTextures(GL_TEXTURE_2D, 1, &id);
			return id;
		}
	};

	template <>
	struct Namespace<VertexArray>
	{
		static constexpr GLuint value = GL_VERTEX_ARRAY;

		static GLuint create()
		{
			GLuint id{};
			glCreateVertexArrays(1, &id);
			return id;
		}
	};

	template <>
	struct Namespace<Program>
	{
		static constexpr GLuint value = GL_PROGRAM;

		static GLuint create()
		{
			return glCreateProgram();
		}
	};

	template <GLuint Type>
	struct Namespace<Shader<Type>>
	{
		static constexpr GLuint value = GL_SHADER;

		static GLuint create()
		{
			return glCreateShader(Type);
		}
	};

	using DebugCallbackPtr = Ptr<void(GLuint id, DebugSource source, DebugType type, DebugSeverity severity, std::string_view message)>;

	std::string_view to_string(DebugSource source);
	std::string_view to_string(DebugType type);
	std::string_view to_string(DebugSeverity severity);
	void set_debug_callback(DebugCallbackPtr callback);

	template <typename T>
	void set_debug_name(T object, std::string_view name)
	{
		glObjectLabel(Namespace<T>::value, object.m_id, static_cast<GLsizei>(name.size()), name.data());
	}

	template <typename T>
	T create(std::string_view name)
	{
		auto object = T(Namespace<T>::create());
		set_debug_name(object, name);
		return object;
	}

	inline void clear(Clear flags)
	{
		glClear(static_cast<GLbitfield>(flags));
	}

	inline void clear_color(glm::vec4 color)
	{
		glClearColor(color.r, color.g, color.b, color.a);
	}

	inline void viewport(glm::ivec2 size)
	{
		glViewport(0, 0, size.x, size.y);
	}

	inline void viewport(glm::ivec4 size)
	{
		glViewport(size.x, size.y, size.z, size.w);
	}

	inline void draw_elements(GLsizei count, DrawMode mode = DrawMode::TriangleStrip, IndexType type = IndexType::U16)
	{
		glDrawElements(static_cast<GLenum>(mode), count, static_cast<GLenum>(type), nullptr);
	}
}
