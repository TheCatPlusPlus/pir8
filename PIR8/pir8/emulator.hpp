#pragma once

#include <string>
#include <optional>
#include <cstdint>

#include <gsl/span>

namespace pir8
{
	struct Emulator
	{
		Emulator(const Emulator& other) = delete;
		Emulator(Emulator&& other) noexcept = delete;
		Emulator& operator=(const Emulator& other) = delete;
		Emulator& operator=(Emulator&& other) noexcept = delete;

		Emulator() = default;

		void load(std::string path);

		void clock_set(bool enabled);
		void clock_pulse();

		void break_set(int32_t offset);
		void break_clear(int32_t offset);

		uint8_t io_get(uint8_t port);
		void io_put(uint8_t port, uint8_t value);

		uint8_t memory_get(uint16_t addr);
		void memory_put(uint16_t addr, uint8_t value);
		void memory_put(uint16_t start_addr, gsl::span<uint8_t> values);

		void run();

	private:
		void draw();

		void draw_menu(int x, int y, int width, int height);
		void draw_status_bar(int x, int y, int width, int height);
		void draw_memory(int x, int y, int width, int height);
		void draw_cpu(int x, int y, int width, int height);
		void draw_disassembly(int x, int y, int width, int height);
		void draw_io(int x, int y, int width, int height);
	};

	void tool_emulator(std::optional<std::string> image);
}
