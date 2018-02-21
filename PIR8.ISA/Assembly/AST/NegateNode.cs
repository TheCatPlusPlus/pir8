namespace PIR8.ISA.Assembly.AST
{
	public sealed class NegateNode : UnaryExprNode
	{
		public NegateNode(ExprNode operand)
			: base(operand)
		{
		}
	}
}
