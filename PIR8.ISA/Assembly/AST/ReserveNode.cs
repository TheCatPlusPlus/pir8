using System.Collections.Generic;

namespace PIR8.ISA.Assembly.AST
{
	public sealed class ReserveNode : EncodableNode
	{
		public string Type { get; }
		public List<ExprNode> Data { get; }

		public ReserveNode(string type)
		{
			Type = type.ToLowerInvariant();
			Data = new List<ExprNode>();
		}
	}
}
