namespace PIR8.ISA.Impl.Codec
{
	public sealed class BitBuffer
	{
		public int Size { get; set; }

		public bool Match(string bits, BitTag tag)
		{
			// TODO maybe throw instead of returning bool
			return false;
		}

		public void Bits(int bits, ref uint value, BitTag tag)
		{
		}
	}
}
