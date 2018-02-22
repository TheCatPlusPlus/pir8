namespace PIR8.ISA.Set.ALU
{
	public sealed class BitOr : BaseALU
	{
		public override string Mnemonic => "or";
		protected override string Pattern => "1001";
		public override byte Op(byte x, byte y) => unchecked((byte)(x | y));
	}
}
