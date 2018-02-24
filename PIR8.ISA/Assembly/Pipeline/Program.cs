using System.Collections.Generic;

namespace PIR8.ISA.Assembly.Pipeline
{
	public sealed class Program
	{
		public List<InsnData> Instructions { get; }
		public Dictionary<string, uint> Constants { get; }
		public Dictionary<string, uint> Labels { get; }

		public Program()
		{
			Instructions = new List<InsnData>();
			Constants = new Dictionary<string, uint>();
			Labels = new Dictionary<string, uint>();
		}
	}
}
