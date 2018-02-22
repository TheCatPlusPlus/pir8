using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set
{
	public sealed class Halt : Impl.Impl
	{
		public override string Mnemonic => "halt";

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			buffer.Size = 1;
			return buffer.Match("11111111", BitTag.Instruction);
		}

		public override void Dispatch(Instruction insn, CPU cpu)
		{
			cpu.Halt = true;
		}
	}
}
