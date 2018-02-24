using System;

namespace PIR8.ISA.Impl.Operands
{
	public sealed class Imm16 : Operand
	{
		public ushort Get(in InsnData insn)
		{
			try
			{
				return checked((ushort)insn[Index]);
			}
			catch (OverflowException)
			{
				throw new InvalidInstruction("Imm16 operand value too large");
			}
		}
	}
}
