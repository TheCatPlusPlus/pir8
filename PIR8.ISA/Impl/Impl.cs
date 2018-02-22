using System.Diagnostics.CodeAnalysis;

using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Impl
{
	[SuppressMessage("ReSharper", "UnusedTypeParameter")]
	public abstract class Impl<TOp1, TOp2, TOp3> : IImpl
		where TOp1 : Operand, new()
		where TOp2 : Operand, new()
		where TOp3 : Operand, new()
	{
		public abstract string Mnemonic { get; }
		protected TOp1 Operand1 { get; }
		protected TOp2 Operand2 { get; }
		protected TOp3 Operand3 { get; }

		protected Impl()
		{
			Operand1 = new TOp1
			{
				Index = 0
			};

			Operand2 = new TOp2
			{
				Index = 1
			};

			Operand3 = new TOp3
			{
				Index = 2
			};
		}

		public abstract bool Codec(BitBuffer buffer, Instruction insn);
		public abstract void Dispatch(Instruction insn, CPU cpu);
	}

	public abstract class Impl<TOp1, TOp2> : Impl<TOp1, TOp2, None>
		where TOp1 : Operand, new()
		where TOp2 : Operand, new()
	{
	}

	public abstract class Impl<TOp1> : Impl<TOp1, None, None>
		where TOp1 : Operand, new()
	{
	}

	public abstract class Impl : Impl<None, None, None>
	{
	}
}
