using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set
{
	public sealed class ClearFlags : Impl.Impl
	{
		public override string Mnemonic => "clrf";

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			buffer.Size = 1;
			return buffer.Match("11111110", BitTag.Instruction);
		}

		public override void Dispatch(Instruction insn, CPU cpu)
		{
			cpu.Flags = Flags.None;
		}
	}
}
