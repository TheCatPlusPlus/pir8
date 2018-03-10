using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set
{
	public sealed class Move : InsnImpl<Reg, Reg>
	{
		public override string Mnemonic => "mov";

		public override void Codec(IBitCodec codec, ref InsnData insn)
		{
			codec.Size = 1;

			codec.Bits("01", BitTag.Instruction);
			codec.Bits(3, ref insn, Operand1);
			codec.Bits(3, ref insn, Operand2);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			var dest = Operand1.Get(in insn);
			var src = Operand2.Get(in insn);
			cpu[dest] = cpu[src];
		}
	}
}
