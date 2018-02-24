using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set
{
	public sealed class Compare : InsnImpl<Reg>
	{
		public override string Mnemonic => "cmp";

		public override void Codec(BitBuffer buffer, ref InsnData insn)
		{
			buffer.Size = 1;

			buffer.Bits("1111 0", BitTag.Instruction);
			buffer.Bits(3, ref insn, Operand1);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			var reg = Operand1.Get(in insn);
			var left = cpu.S;
			var right = cpu[reg];

			cpu.Flags = cpu.Flags
				.Update(Flags.Zero, left == 0)
				.Update(Flags.Parity, Parity(left))
				.Update(Flags.Equals, left == right)
				.Update(Flags.Greater, left > right);
		}

		private static bool Parity(byte value)
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
