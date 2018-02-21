using System.Collections.Generic;

using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;

namespace PIR8.ISA.Assembly.Visitors
{
	public sealed class OperandVisitor : GrammarBaseVisitor<List<OperandNode>>
	{
		[NotNull]
		protected override List<OperandNode> DefaultResult => new List<OperandNode>();

		[NotNull]
		public override List<OperandNode> VisitImmOp([NotNull] GrammarParser.ImmOpContext context)
		{
			var visitor = new ExprVisitor();
			return new List<OperandNode>
			{
				visitor.Visit(context.expr())
			};
		}

		[NotNull]
		public override List<OperandNode> VisitRegOp([NotNull] GrammarParser.RegOpContext context)
		{
			return new List<OperandNode>
			{
				new RegisterNode
				{
					Register = context.REGISTER().GetText()
				}
			};
		}

		[NotNull]
		public override List<OperandNode> VisitImmAddrOp([NotNull] GrammarParser.ImmAddrOpContext context)
		{
			var visitor = new ExprVisitor();
			return new List<OperandNode>
			{
				new ImmediateAddressNode
				{
					Value = visitor.Visit(context.expr())
				}
			};
		}

		[NotNull]
		public override List<OperandNode> VisitImmRegOp([NotNull] GrammarParser.ImmRegOpContext context)
		{
			return new List<OperandNode>
			{
				new RegisterAddressNode
				{
					Register = context.REGISTER().GetText()
				}
			};
		}

		[NotNull]
		protected override List<OperandNode> AggregateResult(
			[NotNull] List<OperandNode> aggregate, [NotNull] List<OperandNode> nextResult)
		{
			aggregate.AddRange(nextResult);
			return aggregate;
		}
	}
}
