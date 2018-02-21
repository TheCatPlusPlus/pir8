namespace PIR8.ISA.Utils
{
	public static class UIntExt
	{
		public static uint TwoComplement(this uint value)
		{
			return unchecked(~value + 1);
		}
	}
}
