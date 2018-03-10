using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set
{
	public sealed class ClearFlags : InsnImpl
	{
		public override string Mnemonic => "clrf";

		public override void Codec(IBitCodec codec, ref InsnData insn)
		{
			codec.Size = 1;
			codec.Bits("1111 1110", BitTag.Instruction);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			cpu.Flags = Flags.None;
		}
	}
}
