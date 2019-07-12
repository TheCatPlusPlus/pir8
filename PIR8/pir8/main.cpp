#include <pir8/pch.hpp>

#include <vector>
#include <string>
#include <optional>

#include <pir8/emulator.hpp>

namespace pir8
{
	void main(std::vector<std::string> args)
	{
		tool_emulator(args.size() > 0 ? args[0] : std::nullopt);
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
