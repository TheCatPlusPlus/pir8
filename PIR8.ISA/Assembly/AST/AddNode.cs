namespace PIR8.ISA.Assembly.AST
{
	public sealed class AddNode : BinaryExprNode
	{
		public AddNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
