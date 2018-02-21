using System;

using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;

namespace PIR8.ISA.Assembly.Visitors
{
	public sealed class ExprVisitor : GrammarBaseVisitor<ExprNode>
	{
		[NotNull]
		public override ExprNode VisitConstantLit([NotNull] GrammarParser.ConstantLitContext context)
		{
			return new ConstantNode(context.LABEL().GetText())
			{
				Start = context.Start,
				End = context.Stop
			};
		}

		[NotNull]
		public override ExprNode VisitNumberLit([NotNull] GrammarParser.NumberLitContext context)
		{
			var digits = context.GetText();
			var raw = digits;
			var negative = false;
			var radix = 10;

			if (digits.StartsWith("-"))
			{
				negative = true;
				digits = digits.Substring(1);
			}

			if (digits.StartsWith("0x"))
			{
				radix = 16;
				digits = digits.Substring(2);
			}
			else if (digits.StartsWith("0o"))
			{
				radix = 8;
				digits = digits.Substring(2);
			}
			else if (digits.StartsWith("0b"))
			{
				radix = 2;
				negative = false;
				digits = digits.Substring(2);
			}

			return new NumberNode(raw, negative, digits, radix)
			{
				Start = context.Start,
				End = context.Stop
			};
		}

		[NotNull]
		public override ExprNode VisitParenExpr([NotNull] GrammarParser.ParenExprContext context)
		{
			return Visit(context.expr());
		}

		[NotNull]
		public override ExprNode VisitNegateExpr([NotNull] GrammarParser.NegateExprContext context)
		{
			var operand = Visit(context.expr());
			var negate = context.MINUS();
			var invert = context.NOT();

			if (negate != null)
			{
				return new NegateNode(operand)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			if (invert != null)
			{
				return new BitInvertNode(operand)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			throw new InvalidOperationException();
		}

		[NotNull]
		public override ExprNode VisitAddExpr([NotNull] GrammarParser.AddExprContext context)
		{
			var left = Visit(context.expr(0));
			var right = Visit(context.expr(1));
			var sub = context.MINUS();
			var add = context.ADD();

			if (sub != null)
			{
				return new SubtractNode(left, right)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			if (add != null)
			{
				return new AddNode(left, right)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			throw new InvalidOperationException();
		}

		[NotNull]
		public override ExprNode VisitMultExpr([NotNull] GrammarParser.MultExprContext context)
		{
			var left = Visit(context.expr(0));
			var right = Visit(context.expr(1));
			var multiply = context.MULTIPLY();
			var divide = context.DIVIDE();
			var modulo = context.MODULO();

			if (multiply != null)
			{
				return new MultiplyNode(left, right)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			if (divide != null)
			{
				return new DivideNode(left, right)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			if (modulo != null)
			{
				return new ModuloNode(left, right)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			throw new InvalidOperationException();
		}

		[NotNull]
		public override ExprNode VisitShiftExpr([NotNull] GrammarParser.ShiftExprContext context)
		{
			var left = Visit(context.expr(0));
			var right = Visit(context.expr(1));
			var arithShift = context.ARITH_RSHIFT();
			var rightShift = context.RSHIFT();
			var leftShift = context.LSHIFT();

			if (arithShift != null)
			{
				return new BitArithmeticShiftNode(left, right)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			if (rightShift != null)
			{
				return new BitRightShiftNode(left, right)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			if (leftShift != null)
			{
				return new BitLeftShiftNode(left, right)
				{
					Start = context.Start,
					End = context.Stop
				};
			}

			throw new InvalidOperationException();
		}

		[NotNull]
		public override ExprNode VisitOrExpr([NotNull] GrammarParser.OrExprContext context)
		{
			var left = Visit(context.expr(0));
			var right = Visit(context.expr(1));
			return new BitOrNode(left, right)
			{
				Start = context.Start,
				End = context.Stop
			};
		}

		[NotNull]
		public override ExprNode VisitXorExpr([NotNull] GrammarParser.XorExprContext context)
		{
			var left = Visit(context.expr(0));
			var right = Visit(context.expr(1));
			return new BitXorNode(left, right)
			{
				Start = context.Start,
				End = context.Stop
			};
		}

		[NotNull]
		public override ExprNode VisitAndExpr([NotNull] GrammarParser.AndExprContext context)
		{
			var left = Visit(context.expr(0));
			var right = Visit(context.expr(1));
			return new BitAndNode(left, right)
			{
				Start = context.Start,
				End = context.Stop
			};
		}
	}
}
