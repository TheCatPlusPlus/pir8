namespace PIR8.ISA.Set.ALU
{
	public abstract class Rotate : BaseShift
	{
		public sealed class Left : Rotate
		{
			protected override ShiftDirection Direction => ShiftDirection.Left;
		}

		public sealed class Right : Rotate
		{
			protected override ShiftDirection Direction => ShiftDirection.Right;
		}

		protected override ShiftType Type => ShiftType.Rotate;
		protected override string ShiftPattern => "11";
		protected override string ShiftMnemonic => "ro";
	}
}
