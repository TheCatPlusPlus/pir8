using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set
{
	public sealed class LoadMem : InsnImpl<Reg, Mem16>
	{
		public override string Mnemonic => "load";

		public override void Codec(BitBuffer buffer, ref InsnData insn)
		{
			buffer.Size = 3;

			buffer.Bits("0010 0", BitTag.Instruction);
			buffer.Bits(3, ref insn, Operand1);
			buffer.Bits(16, ref insn, Operand2);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			var reg = Operand1.Get(in insn);
			var addr = Operand2.Get(in insn);
			cpu[reg] = cpu.RAM[addr];
		}
	}
}
