using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;

namespace PIR8.ISA.Assembly.Visitors
{
	public sealed class InstructionVisitor : GrammarBaseVisitor<InstructionNode>
	{
		[NotNull]
		protected override InstructionNode DefaultResult => new InstructionNode();

		[NotNull]
		public override InstructionNode VisitLabel([NotNull] GrammarParser.LabelContext context)
		{
			return new InstructionNode
			{
				Label = context.LABEL().GetText(),
				Start = context.Start,
				End = context.Stop
			};
		}

		[NotNull]
		public override InstructionNode VisitMnemonic([NotNull] GrammarParser.MnemonicContext context)
		{
			return new InstructionNode
			{
				Mnemonic = context.LABEL().GetText(),
				Start = context.Start,
				End = context.Stop
			};
		}

		[NotNull]
		public override InstructionNode VisitOperands([NotNull] GrammarParser.OperandsContext context)
		{
			var visitor = new OperandVisitor();
			var node = new InstructionNode
			{
				Start = context.Start,
				End = context.Stop
			};
			node.Operands.AddRange(visitor.VisitChildren(context));
			return node;
		}

		[NotNull]
		protected override InstructionNode AggregateResult(
			[NotNull] InstructionNode aggregate, [NotNull] InstructionNode nextResult)
		{
			if (!string.IsNullOrEmpty(nextResult.Label))
			{
				aggregate.Label = nextResult.Label;
			}

			if (!string.IsNullOrEmpty(nextResult.Mnemonic))
			{
				aggregate.Mnemonic = nextResult.Mnemonic;
			}

			if (nextResult.Start.TokenIndex < (aggregate.Start?.TokenIndex ?? int.MaxValue))
			{
				aggregate.Start = nextResult.Start;
			}

			if (nextResult.End.TokenIndex > (aggregate.End?.TokenIndex ?? int.MinValue))
			{
				aggregate.End = nextResult.End;
			}

			aggregate.Operands.AddRange(nextResult.Operands);
			return aggregate;
		}
	}
}
