using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;

namespace PIR8.ISA.Assembly.Visitors
{
	public sealed class FileVisitor : GrammarBaseVisitor<RootNode>
	{
		[NotNull]
		protected override RootNode DefaultResult => new RootNode();

		[NotNull]
		public override RootNode VisitInstruction([NotNull] GrammarParser.InstructionContext context)
		{
			var visitor = new InstructionVisitor();
			var node = visitor.Visit(context);
			return Make(node);
		}

		[NotNull]
		public override RootNode VisitData([NotNull] GrammarParser.DataContext context)
		{
			var visitor = new DataVisitor();
			var node = new DataNode(context.type().GetText());
			node.Data.AddRange(visitor.VisitChildren(context));

			return Make(node);
		}

		[NotNull]
		public override RootNode VisitConstant([NotNull] GrammarParser.ConstantContext context)
		{
			var visitor = new ExprVisitor();
			var node = new ConstantDefNode
			{
				BadLabel = context.label()?.GetText(),
				Name = context.constName().GetText(),
				Value = visitor.Visit(context.expr())
			};

			return Make(node);
		}

		[NotNull]
		protected override RootNode AggregateResult([NotNull] RootNode aggregate, [NotNull] RootNode nextResult)
		{
			aggregate.Children.AddRange(nextResult.Children);
			return aggregate;
		}

		private static RootNode Make(Node child)
		{
			var node = new RootNode();
			node.Children.Add(child);
			return node;
		}
	}
}
