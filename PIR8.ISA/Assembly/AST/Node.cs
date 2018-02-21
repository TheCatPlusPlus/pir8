using Antlr4.Runtime;

namespace PIR8.ISA.Assembly.AST
{
	public abstract class Node
	{
		public IToken Start { get; set; }
		public IToken End { get; set; }
	}
}
