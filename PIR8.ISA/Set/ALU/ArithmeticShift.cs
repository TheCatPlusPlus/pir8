namespace PIR8.ISA.Set.ALU
{
	public abstract class ArithmeticShift : BaseShift
	{
		public sealed class Left : ArithmeticShift
		{
			protected override ShiftDirection Direction => ShiftDirection.Left;
		}

		public sealed class Right : ArithmeticShift
		{
			protected override ShiftDirection Direction => ShiftDirection.Right;
		}

		protected override ShiftType Type => ShiftType.Arithmetic;
		protected override string ShiftPattern => "01";
		protected override string ShiftMnemonic => "sa";
	}
}
