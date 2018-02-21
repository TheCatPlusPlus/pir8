namespace PIR8.ISA.Assembly.AST
{
	public sealed class ConstantDefNode : Node
	{
		public string Name { get; set; }
		public ExprNode Value { get; set; }
	}
}
