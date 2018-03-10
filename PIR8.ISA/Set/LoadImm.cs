using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set
{
	public sealed class LoadImm : InsnImpl<Reg, Imm8>
	{
		public override string Mnemonic => "load";

		public override void Codec(IBitCodec codec, ref InsnData insn)
		{
			codec.Size = 2;

			codec.Bits("0001 1", BitTag.Instruction);
			codec.Bits(3, ref insn, Operand1);
			codec.Bits(8, ref insn, Operand2);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			var reg = Operand1.Get(in insn);
			var value = Operand2.Get(in insn);
			cpu[reg] = value;
		}
	}
}
