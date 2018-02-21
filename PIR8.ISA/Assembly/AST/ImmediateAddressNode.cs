namespace PIR8.ISA.Assembly.AST
{
	public sealed class ImmediateAddressNode : OperandNode
	{
		public ExprNode Value { get; set; }
	}
}
