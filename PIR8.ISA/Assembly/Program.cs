using System.Collections.Generic;

namespace PIR8.ISA.Assembly
{
	public sealed class Program
	{

		public Dictionary<string, uint> Constants { get; }

		public Program()
		{
			Constants = new Dictionary<string, uint>();
		}
	}
}
