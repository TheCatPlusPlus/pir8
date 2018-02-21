namespace PIR8.ISA.Assembly.AST
{
	public sealed class VariableNode : ExprNode
	{
		public string Name { get; }

		public VariableNode(string name)
		{
			Name = name;
		}
	}
}
