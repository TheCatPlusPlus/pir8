namespace PIR8.ISA
{
	public sealed class Instruction
	{
		public string Mnemonic { get; set; }
		public uint[] Operands { get; }

		public Instruction()
		{
			Operands = new uint[3];
		}
	}
}
