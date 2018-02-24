using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set
{
	public sealed class ClearFlags : InsnImpl
	{
		public override string Mnemonic => "clrf";

		public override void Codec(BitBuffer buffer, ref InsnData insn)
		{
			buffer.Size = 1;
			buffer.Bits("1111 1110", BitTag.Instruction);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			cpu.Flags = Flags.None;
		}
	}
}
