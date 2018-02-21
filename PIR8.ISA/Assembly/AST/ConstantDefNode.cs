namespace PIR8.ISA.Assembly.AST
{
	public sealed class ConstantDefNode : Node
	{
		public string Name { get; set; }
		public ExprNode Value { get; set; }

		// if not empty, warning should be issued and label ignored
		public string BadLabel { get; set; }
	}
}
