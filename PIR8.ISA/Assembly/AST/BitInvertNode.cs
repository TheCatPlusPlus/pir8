namespace PIR8.ISA.Assembly.AST
{
	public sealed class BitInvertNode : UnaryExprNode
	{
		public BitInvertNode(ExprNode operand)
			: base(operand)
		{
		}
	}
}
