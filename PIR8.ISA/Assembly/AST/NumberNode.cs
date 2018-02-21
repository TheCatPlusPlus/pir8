namespace PIR8.ISA.Assembly.AST
{
	public sealed class NumberNode : ExprNode
	{
		public uint Value { get; }
		public string RawValue { get; }

		public NumberNode(string value)
		{
			RawValue = value;
		}
	}
}
