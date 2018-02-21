using Antlr4.Runtime;

using PIR8.ISA.Assembly.AST;

namespace PIR8.ISA.Utils
{
	public static class NodeExt
	{
		public static string GetLocation(this Node node)
		{
			return node.Start.GetLocation();
		}

		public static string GetLocation(this IToken token)
		{
			return $"{token.Line}:{token.Column}";
		}
	}
}
