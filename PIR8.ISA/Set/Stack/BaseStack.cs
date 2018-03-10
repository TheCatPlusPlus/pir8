using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set.Stack
{
	public abstract class BaseStack : InsnImpl
	{
		protected abstract bool Push { get; }
		protected abstract bool AB { get; }

		private string OpMnemonic => Push ? "push" : "pop";
		private string PairMnemonic => AB ? "ab" : "cd";
		public override string Mnemonic => $"{OpMnemonic}.{PairMnemonic}";

		public override void Codec(IBitCodec codec, ref InsnData insn)
		{
			codec.Size = 1;

			codec.Bits("1111 10", BitTag.InstructionGroup1);
			codec.Bits(Push ? "0" : "1", BitTag.Instruction);
			codec.Bits(AB ? "0" : "1", BitTag.Instruction);
		}

		public override void Dispatch(CPU cpu, in InsnData insn)
		{
			var sp = cpu.SP;

			if (Push)
			{
				var hi = AB ? cpu.A : cpu.C;
				var lo = AB ? cpu.B : cpu.D;

				sp -= 2;
				cpu.RAM[sp] = hi;
				cpu.RAM[sp + 1] = lo;
			}
			else
			{
				var hi = cpu.RAM[sp];
				var lo = cpu.RAM[sp + 1];
				sp += 2;

				if (AB)
				{
					cpu.A = hi;
					cpu.B = lo;
				}
				else
				{
					cpu.C = hi;
					cpu.D = lo;
				}
			}

			cpu.SP = sp;
		}
	}
}
