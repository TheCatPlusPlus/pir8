using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Impl.Codec
{
	public sealed class BitCodec : IBitCodec
	{
		public int Size { get; set; }

		public void Bits(string bits, BitTag tag)
		{
		}

		public void Bits(int bits, ref InsnData insn, Operand operand)
		{
		}
	}
}
