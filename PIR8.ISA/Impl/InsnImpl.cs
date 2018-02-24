using PIR8.ISA.Impl.Codec;
using PIR8.ISA.Impl.Operands;

namespace PIR8.ISA.Impl
{
	public abstract class BaseInsnImpl<TOp1, TOp2, TOp3> : IInsnImpl
		where TOp1 : Operand, new()
		where TOp2 : Operand, new()
		where TOp3 : Operand, new()
	{
		public abstract string Mnemonic { get; }
		protected TOp1 Operand1 { get; }
		protected TOp2 Operand2 { get; }
		protected TOp3 Operand3 { get; }

		protected BaseInsnImpl()
		{
			Operand1 = new TOp1
			{
				Index = 0,
				Tag = BitTag.Operand1
			};

			Operand2 = new TOp2
			{
				Index = 1,
				Tag = BitTag.Operand2
			};

			Operand3 = new TOp3
			{
				Index = 2,
				Tag = BitTag.Operand3
			};
		}

		public abstract void Codec(BitBuffer buffer, ref InsnData insn);
		public abstract void Dispatch(CPU cpu, in InsnData insn);
	}

	public abstract class InsnImpl<TOp1, TOp2, TOp3> : BaseInsnImpl<TOp1, TOp2, TOp3>
		where TOp1 : Operand, new()
		where TOp2 : Operand, new()
		where TOp3 : Operand, new()
	{
	}

	public abstract class InsnImpl<TOp1, TOp2> : BaseInsnImpl<TOp1, TOp2, None>
		where TOp1 : Operand, new()
		where TOp2 : Operand, new()
	{
	}

	public abstract class InsnImpl<TOp1> : BaseInsnImpl<TOp1, None, None>
		where TOp1 : Operand, new()
	{
	}

	public abstract class InsnImpl : BaseInsnImpl<None, None, None>
	{
	}
}
