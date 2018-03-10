using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set
{
	public sealed class Save : InsnImpl<Mem16, Reg>
	{
		public override string Mnemonic => "save";

		public override void Codec(IBitCodec codec, ref InsnData insn)
		{
			codec.Size = 3;

			codec.Bits("0010 1", BitTag.Instruction);
			codec.Bits(3, ref insn, Operand2);
			codec.Bits(16, ref insn, Operand1);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			var addr = Operand1.Get(in insn);
			var reg = Operand2.Get(in insn);
			cpu.RAM[addr] = cpu[reg];
		}
	}
}
