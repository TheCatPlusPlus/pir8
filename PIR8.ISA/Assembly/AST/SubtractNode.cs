namespace PIR8.ISA.Assembly.AST
{
	public sealed class SubtractNode : BinaryExprNode
	{
		public SubtractNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
