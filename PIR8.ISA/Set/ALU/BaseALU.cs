using System.Diagnostics;

using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Utils;

namespace PIR8.ISA.Set.ALU
{
	public abstract class BaseALU : InsnImpl
	{
		public static readonly string BasePattern = "0011";
		protected abstract string Pattern { get; }

		public override void Codec(IBitCodec codec, ref InsnData insn)
		{
			Debug.Assert(Pattern.Length == 4);
			codec.Size = 1;

			codec.Bits(BasePattern, BitTag.InstructionGroup1);
			codec.Bits(Pattern, BitTag.Instruction);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			cpu.S = Op(cpu.X, cpu.Y);
			UpdateFlags(cpu);
		}

		internal static void UpdateFlags(CPU cpu)
		{
			cpu.Flags = cpu.Flags
				.Update(Flags.Zero, cpu.S == 0)
				.Update(Flags.Parity, cpu.S.Parity());
		}

		public abstract byte Op(byte x, byte y);
	}
}
