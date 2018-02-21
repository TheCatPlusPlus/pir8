namespace PIR8.ISA.Assembly.AST
{
	public sealed class BitOrNode : BinaryExprNode
	{
		public BitOrNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
