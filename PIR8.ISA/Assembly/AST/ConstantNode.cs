namespace PIR8.ISA.Assembly.AST
{
	public sealed class ConstantNode : ExprNode
	{
		public string Name { get; }

		public ConstantNode(string name)
		{
			Name = name;
		}
	}
}
