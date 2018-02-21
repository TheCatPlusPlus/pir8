using System.Collections.Generic;

namespace PIR8.ISA.Assembly.AST
{
	public sealed class RootNode : Node
	{
		public List<Node> Children { get; }

		public RootNode()
		{
			Children = new List<Node>();
		}
	}
}
