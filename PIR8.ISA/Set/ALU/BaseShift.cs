using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Utils;

namespace PIR8.ISA.Set.ALU
{
	public abstract class BaseShift : InsnImpl
	{
		protected abstract ShiftDirection Direction { get; }
		protected abstract ShiftType Type { get; }
		protected abstract string ShiftPattern { get; }
		protected abstract string ShiftMnemonic { get; }

		private string DirectionMnemonic => Direction == ShiftDirection.Left ? "l" : "r";
		public override string Mnemonic => $"{ShiftMnemonic}{DirectionMnemonic}";

		public override void Codec(IBitCodec codec, ref InsnData insn)
		{
			codec.Size = 1;

			codec.Bits(BaseALU.BasePattern, BitTag.InstructionGroup1);
			codec.Bits("1", BitTag.InstructionGroup2);
			codec.Bits(Direction == ShiftDirection.Left ? "1" : "0", BitTag.Instruction);
			codec.Bits(ShiftPattern, BitTag.Instruction);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			(var value, var carry) = Shift(cpu.X, cpu.Flags.Has(Flags.Carry));
			cpu.Flags = cpu.Flags.Update(Flags.Carry, carry);
			cpu.S = value;
			BaseALU.UpdateFlags(cpu);
		}

		protected (byte, bool) Shift(byte value, bool carry)
		{
			return value.Shift(carry, Direction, Type);
		}
	}
}
