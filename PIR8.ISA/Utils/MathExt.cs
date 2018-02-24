namespace PIR8.ISA.Utils
{
	public static class MathExt
	{
		public static long Mod(long x, long m)
		{
			return (x % m + m) % m;
		}
	}
}
