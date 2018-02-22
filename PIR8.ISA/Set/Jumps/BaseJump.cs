using System.Diagnostics;

using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set.Jumps
{
	public abstract class BaseJump : Impl<Imm16>
	{
		protected abstract string Pattern { get; }

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			Debug.Assert(Pattern.Length == 3);
			buffer.Size = 1;

			if (!buffer.Match("00010", BitTag.InstructionGroup1))
			{
				return false;
			}

			if (!buffer.Match(Pattern, BitTag.Instruction))
			{
				return false;
			}

			return true;
		}

		public override void Dispatch(Instruction insn, CPU cpu)
		{
			var addr = Operand1.Get(insn);
			if (CheckJump(cpu))
			{
				cpu.PC = addr;
			}
		}

		protected abstract bool CheckJump(CPU cpu);
	}
}
