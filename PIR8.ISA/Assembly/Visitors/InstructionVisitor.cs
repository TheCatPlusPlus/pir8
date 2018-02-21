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
				Label = context.LABEL().GetText()
			};
		}

		[NotNull]
		public override InstructionNode VisitMnemonic([NotNull] GrammarParser.MnemonicContext context)
		{
			return new InstructionNode
			{
				Mnemonic = context.LABEL().GetText()
			};
		}

		[NotNull]
		public override InstructionNode VisitOperands([NotNull] GrammarParser.OperandsContext context)
		{
			var visitor = new OperandVisitor();
			var node = new InstructionNode();
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

			aggregate.Operands.AddRange(nextResult.Operands);
			return aggregate;
		}
	}
}
