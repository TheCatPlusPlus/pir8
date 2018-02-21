namespace PIR8.ISA.Assembly.AST
{
	public sealed class ModuloNode : BinaryExprNode
	{
		public ModuloNode(ExprNode left, ExprNode right)
			: base(left, right)
		{
		}
	}
}
