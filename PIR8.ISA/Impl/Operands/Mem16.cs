using System;

namespace PIR8.ISA.Impl.Operands
{
	public sealed class Mem16 : Operand
	{
		public ushort Get(Instruction insn)
		{
			try
			{
				return checked((ushort)insn.Operands[Index]);
			}
			catch (OverflowException)
			{
				throw new InvalidInstruction("Mem16 operand value too large");
			}
		}
	}
}
