#include <pir8/pch.hpp>
#include <pir8/emulator.hpp>

#include <curses.h>

namespace pir8
{
	void tool_emulator(std::optional<std::string> image)
	{
		initscr();
		cbreak();
		noecho();
		nodelay(stdscr, true);
		refresh();


	}
}
