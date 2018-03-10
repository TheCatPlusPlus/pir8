using System.Collections.Generic;

namespace PIR8.ISA.Assembly
{
	public sealed class ProgramSection
	{
		public List<InsnData> Instructions { get; }
		public Dictionary<string, uint> Labels { get; }

		public ProgramSection()
		{
			Instructions = new List<InsnData>();
			Labels = new Dictionary<string, uint>();
		}
	}
}
