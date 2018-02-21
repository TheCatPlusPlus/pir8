namespace PIR8.ISA.Assembly.AST
{
	public abstract class UnaryExprNode : ExprNode
	{
		public ExprNode Operand { get; }

		protected UnaryExprNode(ExprNode operand)
		{
			Operand = operand;
		}
	}
}
