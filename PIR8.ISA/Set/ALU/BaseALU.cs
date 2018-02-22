using System.Diagnostics;

using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set.ALU
{
	public abstract class BaseALU : Impl.Impl
	{
		public static readonly string BasePattern = "0011";
		protected abstract string Pattern { get; }

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			Debug.Assert(Pattern.Length == 4);
			buffer.Size = 1;

			if (!buffer.Match(BasePattern, BitTag.InstructionGroup1))
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
			cpu.S = Op(cpu.X, cpu.Y);
		}

		public abstract byte Op(byte x, byte y);
	}
}
