using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;
using PIR8.ISA.Assembly.Pipeline;

namespace PIR8.ISA.Assembly.Visitors
{
	public sealed class RootVisitor : GrammarBaseVisitor<RootNode>
	{
		private readonly ErrorListener _errors;

		public RootVisitor(ErrorListener errors)
		{
			_errors = errors;
		}

		[NotNull]
		public override RootNode VisitFile([NotNull] GrammarParser.FileContext context)
		{
			var visitor = new FileVisitor(_errors);
			return visitor.VisitChildren(context);
		}
	}
}
