using System;

namespace PIR8.ISA
{
	[Flags]
	public enum Flags : byte
	{
		None = 0,
		Zero = 1 << 0,
		Carry = 1 << 1,
		Parity = 1 << 2,
		Equals = 1 << 3,
		Greater = 1 << 4
	}

	public static class FlagsExt
	{
		public static bool Has(this Flags flags, Flags flag)
		{
			return (flags & flag) != 0;
		}

		public static Flags Update(this Flags flags, Flags flag, bool condition)
		{
			return condition
				? flags | flag
				: flags & ~flag;
		}
	}
}
