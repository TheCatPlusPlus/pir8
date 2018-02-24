namespace PIR8.ISA.Set.ALU
{
	public abstract class RotateWithCarry : BaseShift
	{
		public sealed class Left : RotateWithCarry
		{
			protected override ShiftDirection Direction => ShiftDirection.Left;
		}

		public sealed class Right : RotateWithCarry
		{
			protected override ShiftDirection Direction => ShiftDirection.Right;
		}

		protected override ShiftType Type => ShiftType.RotateWithCarry;
		protected override string ShiftPattern => "10";
		protected override string ShiftMnemonic => "rc";
	}
}
