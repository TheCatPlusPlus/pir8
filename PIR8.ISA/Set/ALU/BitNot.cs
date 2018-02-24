namespace PIR8.ISA.Set.ALU
{
	public sealed class BitNot : BaseALU
	{
		public override string Mnemonic => "not";
		protected override string Pattern => "0010";
		public override byte Op(byte x, byte y) => unchecked((byte)~x);
	}
}
