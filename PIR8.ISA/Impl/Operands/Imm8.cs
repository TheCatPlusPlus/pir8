using System;

namespace PIR8.ISA.Impl.Operands
{
	public sealed class Imm8 : Operand
	{
		public byte Get(in InsnData insn)
		{
			try
			{
				return checked((byte)insn[Index]);
			}
			catch (OverflowException)
			{
				throw new InvalidInstruction("Imm8 operand value too large");
			}
		}
	}
}
