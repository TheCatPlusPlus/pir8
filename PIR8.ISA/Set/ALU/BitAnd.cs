namespace PIR8.ISA.Set.ALU
{
	public sealed class BitAnd : BaseALU
	{
		public override string Mnemonic => "and";
		protected override string Pattern => "0110";
		public override byte Op(byte x, byte y) => unchecked((byte)(x & y));
	}
}
