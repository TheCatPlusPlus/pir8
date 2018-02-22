namespace PIR8.ISA.Set.ALU
{
	public sealed class Subtract : BaseALU
	{
		public override string Mnemonic => "sub";
		protected override string Pattern => "0101";
		public override byte Op(byte x, byte y) => unchecked((byte)(x - y));
	}
}
