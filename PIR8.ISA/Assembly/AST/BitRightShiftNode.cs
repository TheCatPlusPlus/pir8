namespace PIR8.ISA.Assembly.AST
{
	public sealed class BitRightShiftNode : BinaryExprNode
	{
		public BitRightShiftNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
