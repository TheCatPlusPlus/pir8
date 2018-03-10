using System.Diagnostics;

using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Set.Jumps
{
	public abstract class BaseJump : InsnImpl<Imm16>
	{
		protected abstract string Pattern { get; }

		public override void Codec(IBitCodec codec, ref InsnData insn)
		{
			Debug.Assert(Pattern.Length == 3);
			codec.Size = 1;
			codec.Bits("0001 0", BitTag.InstructionGroup1);
			codec.Bits(Pattern, BitTag.Instruction);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			var addr = Operand1.Get(in insn);
			if (CheckJump(cpu))
			{
				cpu.PC = addr;
			}
		}

		protected abstract bool CheckJump(CPU cpu);
	}
}
