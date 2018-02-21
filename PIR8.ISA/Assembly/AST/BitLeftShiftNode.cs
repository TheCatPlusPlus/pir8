namespace PIR8.ISA.Assembly.AST
{
	public sealed class BitLeftShiftNode :BinaryExprNode
	{
		public BitLeftShiftNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
