using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Set.Stack
{
	public abstract class BaseStack : Impl.Impl
	{
		protected abstract bool Push { get; }
		protected abstract bool AB { get; }

		private string OpMnemonic => Push ? "push" : "pop";
		private string PairMnemonic => AB ? "ab" : "cd";
		public override string Mnemonic => $"{OpMnemonic}.{PairMnemonic}";

		public override bool Codec(BitBuffer buffer, Instruction insn)
		{
			buffer.Size = 1;

			if (!buffer.Match("111110", BitTag.InstructionGroup1))
			{
				return false;
			}

			if (!buffer.Match(Push ? "0" : "1", BitTag.Instruction))
			{
				return false;
			}

			if (!buffer.Match(AB ? "0" : "1", BitTag.Instruction))
			{
				return false;
			}

			return true;
		}

		public override void Dispatch(Instruction insn, CPU cpu)
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
