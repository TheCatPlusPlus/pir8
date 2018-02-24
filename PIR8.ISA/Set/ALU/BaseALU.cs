using System.Diagnostics;

using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set.ALU
{
	public abstract class BaseALU : InsnImpl
	{
		public static readonly string BasePattern = "0011";
		protected abstract string Pattern { get; }

		public override void Codec(BitBuffer buffer, ref InsnData insn)
		{
			Debug.Assert(Pattern.Length == 4);
			buffer.Size = 1;

			buffer.Bits(BasePattern, BitTag.InstructionGroup1);
			buffer.Bits(Pattern, BitTag.Instruction);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			cpu.S = Op(cpu.X, cpu.Y);
		}

		public abstract byte Op(byte x, byte y);
	}
}
