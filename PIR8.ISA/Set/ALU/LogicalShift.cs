namespace PIR8.ISA.Set.ALU
{
	public abstract class LogicalShift : BaseShift
	{
		public sealed class Left : LogicalShift
		{
			protected override ShiftDirection Direction => ShiftDirection.Left;
		}

		public sealed class Right : LogicalShift
		{
			protected override ShiftDirection Direction => ShiftDirection.Right;
		}

		protected override ShiftType Type => ShiftType.Logical;
		protected override string ShiftPattern => "00";
		protected override string ShiftMnemonic => "sh";
	}
}
