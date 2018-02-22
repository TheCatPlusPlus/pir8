using PIR8.ISA.Utils;

namespace PIR8.ISA.Impl.Operands
{
	public sealed class Reg : Operand
	{
		public Register Get(Instruction insn)
		{
			var value = (Register)insn.Operands[Index];
			if (!EnumExt.IsDefined(value))
			{
				throw new InvalidInstruction($"Invalid register value {value}");
			}

			return value;
		}
	}
}
