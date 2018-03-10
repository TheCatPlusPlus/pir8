using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;
using PIR8.ISA.Utils;

namespace PIR8.ISA.Set
{
	public sealed class Compare : InsnImpl<Reg>
	{
		public override string Mnemonic => "cmp";

		public override void Codec(IBitCodec codec, ref InsnData insn)
		{
			codec.Size = 1;

			codec.Bits("1111 0", BitTag.Instruction);
			codec.Bits(3, ref insn, Operand1);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			var reg = Operand1.Get(in insn);
			var left = cpu.S;
			var right = cpu[reg];

			cpu.Flags = cpu.Flags
				.Update(Flags.Zero, left == 0)
				.Update(Flags.Parity, left.Parity())
				.Update(Flags.Equals, left == right)
				.Update(Flags.Greater, left > right);
		}
	}
}
