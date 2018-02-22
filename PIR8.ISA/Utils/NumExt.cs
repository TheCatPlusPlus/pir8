namespace PIR8.ISA.Utils
{
	public static class NumExt
	{
		public static uint TwoComplement(this uint value)
		{
			return unchecked(~value + 1);
		}

		public static (byte, byte) Split(this ushort value)
		{
			return (value.Hi(), value.Lo());
		}

		public static ushort Merge(byte hi, byte lo)
		{
			return (ushort)((hi << 8) | lo);
		}

		public static byte Hi(this ushort value)
		{
			return (byte)((value >> 8) & 0xFFu);
		}

		public static byte Lo(this ushort value)
		{
			return (byte)(value & 0xFFu);
		}
	}
}
