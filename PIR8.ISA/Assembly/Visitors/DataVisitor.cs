using System.Collections.Generic;

using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;

namespace PIR8.ISA.Assembly.Visitors
{
	public sealed class DataVisitor : GrammarBaseVisitor<List<ExprNode>>
	{
		[NotNull]
		protected override List<ExprNode> DefaultResult => new List<ExprNode>();

		[NotNull]
		public override List<ExprNode> VisitDatum([NotNull] GrammarParser.DatumContext context)
		{
			var visitor = new ExprVisitor();
			return new List<ExprNode>
			{
				visitor.Visit(context.expr())
			};
		}

		[NotNull]
		protected override List<ExprNode> AggregateResult(
			[NotNull] List<ExprNode> aggregate, [NotNull] List<ExprNode> nextResult)
		{
			aggregate.AddRange(nextResult);
			return aggregate;
		}
	}
}
