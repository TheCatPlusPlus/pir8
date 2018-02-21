namespace PIR8.ISA.Assembly.AST
{
	public sealed class BitArithmeticShiftNode : BinaryExprNode
	{
		public BitArithmeticShiftNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
