using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set.ALU
{
	public abstract class BaseShift : InsnImpl
	{
		protected abstract bool Bit { get; }
		protected abstract bool ShiftLeft { get; }

		private string DirectionMnemonic => ShiftLeft ? "l" : "r";
		public override string Mnemonic => $"sh{DirectionMnemonic}.{Bit}";

		public override void Codec(BitBuffer buffer, ref InsnData insn)
		{
			buffer.Size = 1;

			buffer.Bits(BaseALU.BasePattern, BitTag.InstructionGroup1);
			buffer.Bits("11", BitTag.InstructionGroup2);
			buffer.Bits(ShiftLeft ? "0" : "1", BitTag.Instruction);
			buffer.Bits(Bit ? "1" : "0", BitTag.Instruction);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			var value = cpu.X;
			var bit = Bit ? 1 : 0;
			bool carry;

			if (ShiftLeft)
			{
				carry = (value & (1 << 7)) != 0;
				value = (byte)((value << 1) | bit);
			}
			else
			{
				carry = (value & 1) != 0;
				value = (byte)((value >> 1) | (bit << 7));
			}

			cpu.Flags = cpu.Flags.Update(Flags.Carry, carry);
			cpu.S = value;
		}
	}
}
