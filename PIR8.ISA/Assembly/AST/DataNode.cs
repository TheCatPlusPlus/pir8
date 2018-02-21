using System.Collections.Generic;

namespace PIR8.ISA.Assembly.AST
{
	public sealed class DataNode : EncodableNode
	{
		public string Type { get; }
		public List<ExprNode> Data { get; }

		public DataNode(string type)
		{
			Type = type;
			Data = new List<ExprNode>();
		}
	}
}
