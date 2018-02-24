namespace PIR8.ISA.Set.ALU
{
	public sealed class BitXor : BaseALU
	{
		public override string Mnemonic => "xor";
		protected override string Pattern => "0101";
		public override byte Op(byte x, byte y) => unchecked((byte)(x ^ y));
	}
}
