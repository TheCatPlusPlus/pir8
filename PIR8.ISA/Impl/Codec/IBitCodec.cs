using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Impl.Codec
{
	public interface IBitCodec
	{
		int Size { get; set; }
		void Bits(string bits, BitTag tag);
		void Bits(int bits, ref InsnData insn, Operand operand);
	}
}