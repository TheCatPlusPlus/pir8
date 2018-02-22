using System;

namespace PIR8.ISA.Impl.Operands
{
	public sealed class Imm8 : Operand
	{
		public byte Get(Instruction insn)
		{
			try
			{
				return checked((byte)insn.Operands[Index]);
			}
			catch (OverflowException)
			{
				throw new InvalidInstruction("Imm8 operand value too large");
			}
		}
	}
}
