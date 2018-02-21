namespace PIR8.ISA.Assembly.AST
{
	public abstract class BinaryExprNode : ExprNode
	{
		public ExprNode Left { get; }
		public ExprNode Right { get; }

		protected BinaryExprNode(ExprNode left, ExprNode right)
		{
			Left = left;
			Right = right;
		}
	}
}
