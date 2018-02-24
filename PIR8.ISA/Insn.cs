using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA
{
	public sealed class Insn
	{
		public BitBuffer Bits { get; }
		public IInsnImpl Impl { get; }
	}
}
