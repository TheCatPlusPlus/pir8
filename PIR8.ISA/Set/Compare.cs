using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set
{
	public sealed class Compare : Impl<Reg>
	{
		public override string Mnemonic => "cmp";

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			buffer.Size = 1;

			if (!buffer.Match("11110", BitTag.Instruction))
			{
				return false;
			}

			buffer.Bits(3, ref insn.Operands[0], BitTag.Operand1);
			return true;
		}

		public override void Dispatch(Instruction insn, CPU cpu)
		{
			var reg = Operand1.Get(insn);
			var left = cpu.S;
			var right = cpu[reg];

			cpu.Flags = cpu.Flags
				.Update(Flags.Zero, left == 0)
				.Update(Flags.Parity, Parity(left))
				.Update(Flags.Equals, left == right)
				.Update(Flags.Greater, left > right);
		}

		private bool Parity(byte value)
		{
			// TODO maybe get POPCNT

			var count = 0;
			for (var idx = 0; idx < 8; idx++)
			{
				count += value & (1 << idx);
			}

			return (count % 2) == 0;
		}
	}
}
