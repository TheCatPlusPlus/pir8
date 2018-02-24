namespace PIR8.ISA.Set.ALU
{
	public sealed class Add : BaseALU
	{
		public override string Mnemonic => "add";
		protected override string Pattern => "0000";
		public override byte Op(byte x, byte y) => unchecked((byte)(x + y));
	}
}
