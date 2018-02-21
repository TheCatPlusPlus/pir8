namespace PIR8.ISA.Assembly.AST
{
	public sealed class BitAndNode : BinaryExprNode
	{
		public BitAndNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
