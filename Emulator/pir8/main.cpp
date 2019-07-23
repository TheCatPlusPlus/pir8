#include <pir8/pch.hpp>

#include <vector>
#include <string>
#include <optional>

namespace pir8
{
	void main(std::vector<std::string> args)
	{
		std::optional<std::string> image{};

		if (args.size() > 0)
		{
			image = args[0];
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
