using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;

namespace PIR8.ISA.Assembly.Visitors
{
	public sealed class RootVisitor : GrammarBaseVisitor<RootNode>
	{
		[NotNull]
		public override RootNode VisitFile([NotNull] GrammarParser.FileContext context)
		{
			var visitor = new FileVisitor();
			return visitor.VisitChildren(context);
		}
	}
}
