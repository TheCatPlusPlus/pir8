#include <pir8/pch.hpp>

#include <gsl/span>

#include <stb.h>

#include <pir8/utils.hpp>

namespace pir8
{
	std::vector<std::byte> read_file(fs::path path)
	{
		auto path_str = path.string();
		size_t length{};

		auto bytes = stb_fileu(&path_str[0], &length);
		PIR8_ENSUREF(bytes, "stb_file({})", path);
		auto bytes_span = gsl::as_bytes(gsl::span(bytes, bytes + length));

		std::vector<std::byte> result{};
		result.assign(bytes_span.begin(), bytes_span.end());
		free(bytes);

		return result;
	}
}
