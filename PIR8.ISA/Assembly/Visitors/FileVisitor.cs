using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;
using PIR8.ISA.Assembly.Pipeline;

namespace PIR8.ISA.Assembly.Visitors
{
	public sealed class FileVisitor : GrammarBaseVisitor<RootNode>
	{
		private readonly ErrorListener _errors;

		[NotNull]
		protected override RootNode DefaultResult => new RootNode();

		public FileVisitor(ErrorListener errors)
		{
			_errors = errors;
		}

		[NotNull]
		public override RootNode VisitLabel([NotNull] GrammarParser.LabelContext context)
		{
			var label = context.LABEL().GetText();

			if (string.IsNullOrEmpty(label))
			{
				_errors.SyntaxError(context, "empty label not permitted");
			}

			var node = new LabelNode
			{
				Name = label,
				Start = context.Start,
				End = context.Stop
			};

			return Make(node);
		}

		[NotNull]
		public override RootNode VisitInstruction([NotNull] GrammarParser.InstructionContext context)
		{
			var visitor = new InstructionVisitor(_errors);
			var node = visitor.Visit(context);
			return Make(node);
		}

		[NotNull]
		public override RootNode VisitData([NotNull] GrammarParser.DataContext context)
		{
			var visitor = new DataVisitor(_errors);
			var node = new DataNode(context.type().GetText())
			{
				Start = context.Start,
				End = context.Stop
			};

			node.Data.AddRange(visitor.VisitChildren(context));
			return Make(node);
		}

		[NotNull]
		public override RootNode VisitConstant([NotNull] GrammarParser.ConstantContext context)
		{
			var name = context.constName().GetText();

			if (string.IsNullOrEmpty(name))
			{
				_errors.SyntaxError(context, "empty constant name not permitted");
			}

			if (name.Contains("."))
			{
				_errors.SyntaxError(context, "constant names cannot contain any dots");
			}

			var visitor = new ExprVisitor(_errors);
			var node = new ConstantDefNode
			{
				Name = name,
				Value = visitor.Visit(context.expr()),
				Start = context.Start,
				End = context.Stop
			};

			return Make(node);
		}

		public override RootNode VisitSection([NotNull] GrammarParser.SectionContext context)
		{
			var name = context.LABEL().GetText();
			var node = new SectionNode
			{
				Name = name,
				Start = context.Start,
				End = context.Stop
			};

			return Make(node);
		}

		public override RootNode VisitFormat([NotNull] GrammarParser.FormatContext context)
		{
			var name = context.LABEL().GetText();
			var node = new FormatNode
			{
				Name = name,
				Start = context.Start,
				End = context.Stop
			};

			return Make(node);
		}

		public override RootNode VisitReserve([NotNull] GrammarParser.ReserveContext context)
		{
			var visitor = new DataVisitor(_errors);
			var node = new ReserveNode(context.type().GetText())
			{
				Start = context.Start,
				End = context.Stop
			};

			node.Data.AddRange(visitor.VisitChildren(context));
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
