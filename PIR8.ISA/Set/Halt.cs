using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set
{
	public sealed class Halt : InsnImpl
	{
		public override string Mnemonic => "halt";

		public override void Codec(BitBuffer buffer, ref InsnData insn)
		{
			buffer.Size = 1;
			buffer.Bits("1111 1111", BitTag.Instruction);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			cpu.Halt = true;
		}
	}
}
