using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set
{
	public sealed class LoadImm : Impl<Reg, Imm8>
	{
		public override string Mnemonic => "load";

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			buffer.Size = 2;

			if (!buffer.Match("00011", BitTag.Instruction))
			{
				return false;
			}

			buffer.Bits(3, ref insn.Operands[0], BitTag.Operand1);
			buffer.Bits(8, ref insn.Operands[1], BitTag.Operand2);

			return true;
		}

		public override void Dispatch(Instruction insn, CPU cpu)
		{
			var reg = Operand1.Get(insn);
			var value = Operand2.Get(insn);
			cpu[reg] = value;
		}
	}
}
