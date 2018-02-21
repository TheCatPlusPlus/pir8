namespace PIR8.ISA.Assembly.AST
{
	public sealed class DivideNode : BinaryExprNode
	{
		public DivideNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
