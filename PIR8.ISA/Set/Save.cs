using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set
{
	public sealed class Save : Impl<Mem16, Reg>
	{
		public override string Mnemonic => "save";

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			buffer.Size = 3;

			if (!buffer.Match("00101", BitTag.Instruction))
			{
				return false;
			}

			buffer.Bits(3, ref insn.Operands[1], BitTag.Operand2);
			buffer.Bits(16, ref insn.Operands[0], BitTag.Operand1);

			return true;
		}

		public override void Dispatch(Instruction insn, CPU cpu)
		{
			var addr = Operand1.Get(insn);
			var reg = Operand2.Get(insn);
			cpu.RAM[addr] = cpu[reg];
		}
	}
}
