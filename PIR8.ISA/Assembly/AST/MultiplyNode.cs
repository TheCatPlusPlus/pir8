namespace PIR8.ISA.Assembly.AST
{
	public sealed class MultiplyNode : BinaryExprNode
	{
		public MultiplyNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
