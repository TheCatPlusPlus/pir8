using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Impl.Operands
{
	public abstract class Operand
	{
		public int Index { get; set; }
		public BitTag Tag { get; set; }
	}
}
