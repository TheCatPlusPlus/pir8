using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set
{
	public sealed class Move : Impl<Reg, Reg>
	{
		public override string Mnemonic => "mov";

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			buffer.Size = 1;

			if (!buffer.Match("01", BitTag.Instruction))
			{
				return false;
			}

			buffer.Bits(3, ref insn.Operands[0], BitTag.Operand1);
			buffer.Bits(3, ref insn.Operands[1], BitTag.Operand2);

			return true;
		}

		public override void Dispatch(Instruction insn, CPU cpu)
		{
			var dest = Operand1.Get(insn);
			var src = Operand2.Get(insn);
			cpu[dest] = cpu[src];
		}
	}
}
