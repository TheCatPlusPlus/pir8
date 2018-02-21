using Antlr4.Runtime;

namespace PIR8.ISA.Assembly.AST
{
	public abstract class Node
	{
		// TODO
		public IToken Start { get; set; }
		public IToken End { get; set; }
	}
}
