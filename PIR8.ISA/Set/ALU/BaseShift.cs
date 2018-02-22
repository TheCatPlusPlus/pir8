using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set.ALU
{
	public abstract class BaseShift : Impl.Impl
	{
		protected abstract bool Bit { get; }
		protected abstract bool ShiftLeft { get; }

		private string DirectionMnemonic => ShiftLeft ? "l" : "r";
		public override string Mnemonic => $"sh{DirectionMnemonic}.{Bit}";

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			buffer.Size = 1;

			if (!buffer.Match(BaseALU.BasePattern, BitTag.InstructionGroup1))
			{
				return false;
			}

			if (!buffer.Match("11", BitTag.InstructionGroup2))
			{
				return false;
			}

			if (!buffer.Match(ShiftLeft ? "0" : "1", BitTag.Instruction))
			{
				return false;
			}

			if (!buffer.Match(Bit ? "1" : "0", BitTag.Instruction))
			{
				return false;
			}

			return true;
		}

		public override void Dispatch(Instruction insn, CPU cpu)
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
