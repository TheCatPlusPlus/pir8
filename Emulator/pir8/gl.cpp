#include <pir8/pch.hpp>

#include <pir8/gl.hpp>

namespace pir8::gl
{
	std::string_view to_string(DebugSource source)
	{
		switch (source)
		{
		case DebugSource::API:
			return "API";
		case DebugSource::Application:
			return "Application";
		case DebugSource::WindowSystem:
			return "WindowSystem";
		case DebugSource::ThirdParty:
			return "ThirdParty";
		case DebugSource::ShaderCompiler:
			return "ShaderCompiler";
		case DebugSource::Other:
			return "Other";
		default:
			return "<unknown>";
		}
	}

	std::string_view to_string(DebugType type)
	{
		switch (type)
		{
		case DebugType::Error:
			return "Error";
		case DebugType::DeprecatedBehavior:
			return "DeprecatedBehavior";
		case DebugType::UndefinedBehavior:
			return "UndefinedBehavior";
		case DebugType::Portability:
			return "Portability";
		case DebugType::Performance:
			return "Performance";
		case DebugType::Marker:
			return "Marker";
		case DebugType::PushGroup:
			return "PushGroup";
		case DebugType::PopGroup:
			return "PopGroup";
		case DebugType::Other:
			return "Other";
		default:
			return "<unknown>";
		}
	}

	std::string_view to_string(DebugSeverity severity)
	{
		switch (severity)
		{
		case DebugSeverity::High:
			return "High";
		case DebugSeverity::Medium:
			return "Medium";
		case DebugSeverity::Low:
			return "Low";
		case DebugSeverity::Notification:
			return "Notification";
		default:
			return "<unknown>";
		}
	}

	void set_debug_callback(DebugCallbackPtr callback)
	{
		auto&& wrapper = [](
			GLenum raw_source,
			GLenum raw_type,
			GLuint id,
			GLenum raw_severity,
			GLsizei length,
			const GLchar* raw_message,
			const void* user_data)
		{
			auto callback = static_cast<DebugCallbackPtr>(const_cast<void*>(user_data));
			auto source = static_cast<DebugSource>(raw_source);
			auto type = static_cast<DebugType>(raw_type);
			auto severity = static_cast<DebugSeverity>(raw_severity);
			auto message = length < 0 ? std::string_view(raw_message) : std::string_view(raw_message, static_cast<size_t>(length));

			callback(id, source, type, severity, message);
		};

		glDebugMessageCallback(wrapper, callback);
		glEnable(GL_DEBUG_OUTPUT_SYNCHRONOUS);
		glEnable(GL_DEBUG_OUTPUT);
	}
}
