namespace PIR8.ISA.Assembly.AST
{
	public sealed class BitXorNode : BinaryExprNode
	{
		public BitXorNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
