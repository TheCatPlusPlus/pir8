#pragma once

// ReSharper disable CppUnusedIncludeDirective

#include <iostream>
#include <utility>
#include <functional>

#include <fmt/format.h>
#include <fmt/ostream.h>

#include <boost/exception/all.hpp>
#include <boost/stacktrace/stacktrace.hpp>
#include <boost/filesystem.hpp>

#include <glm/gtx/io.hpp>

#define PIR8_FAIL(msg) \
	do { \
		throw ::boost::enable_error_info(::pir8::FatalError(msg)) << \
			::pir8::StackTrace(::boost::stacktrace::stacktrace()); \
	} while (false)

#define PIR8_FAILF(msg, ...) \
	PIR8_FAIL(::fmt::format(msg, __VA_ARGS__))

#define PIR8_DO_ENSURE(expr, msg) \
	do { if (!(expr)) { PIR8_FAIL(msg); } } while (false)

#define PIR8_ENSURE(expr) \
	PIR8_DO_ENSURE(expr, #expr)

#define PIR8_ENSUREM(expr, msg) \
	PIR8_DO_ENSURE(expr, (::fmt::format("{}: {}", #expr, msg)))

#define PIR8_ENSUREF(expr, msg, ...) \
	PIR8_ENSUREM(expr, ::fmt::format(msg, __VA_ARGS__))

#define PIR8_FLAGS(T) \
	constexpr T operator|(T left, T right) noexcept \
	{ \
		using U = std::underlying_type<T>::type; \
		return static_cast<T>(static_cast<U>(left) | static_cast<U>(right)); \
	} \
	constexpr T operator&(T left, T right) noexcept \
	{ \
		using U = std::underlying_type<T>::type; \
		return static_cast<T>(static_cast<U>(left) & static_cast<U>(right)); \
	} \
	constexpr T operator~(T value) noexcept \
	{ \
		using U = std::underlying_type<T>::type; \
		return static_cast<T>(~static_cast<U>(value)); \
	}

namespace pir8
{
	struct FatalError final : virtual std::exception, virtual boost::exception
	{
		explicit FatalError(std::string message)
			: m_message{std::move(message)}
		{
		}

		char const* what() const override
		{
			return m_message.c_str();
		}

	private:
		std::string m_message;
	};

	using StackTrace = boost::error_info<struct TagStackTrace, boost::stacktrace::stacktrace>;

	template <typename T>
	using Ptr = T*;

	std::vector<std::byte> read_file(fs::path path);
}
