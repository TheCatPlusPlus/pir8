//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Grammar.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace PIR8.ISA.Assembly.Gen {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="GrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface IGrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFile([NotNull] GrammarParser.FileContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabel([NotNull] GrammarParser.LabelContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.mnemonic"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMnemonic([NotNull] GrammarParser.MnemonicContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.constName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstName([NotNull] GrammarParser.ConstNameContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>instruction</c>
	/// labeled alternative in <see cref="GrammarParser.entry"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInstruction([NotNull] GrammarParser.InstructionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>data</c>
	/// labeled alternative in <see cref="GrammarParser.entry"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitData([NotNull] GrammarParser.DataContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>constant</c>
	/// labeled alternative in <see cref="GrammarParser.entry"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstant([NotNull] GrammarParser.ConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.operands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperands([NotNull] GrammarParser.OperandsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] GrammarParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>immOp</c>
	/// labeled alternative in <see cref="GrammarParser.operand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImmOp([NotNull] GrammarParser.ImmOpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>regOp</c>
	/// labeled alternative in <see cref="GrammarParser.operand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRegOp([NotNull] GrammarParser.RegOpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>immAddrOp</c>
	/// labeled alternative in <see cref="GrammarParser.operand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImmAddrOp([NotNull] GrammarParser.ImmAddrOpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>immRegOp</c>
	/// labeled alternative in <see cref="GrammarParser.operand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImmRegOp([NotNull] GrammarParser.ImmRegOpContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.datum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDatum([NotNull] GrammarParser.DatumContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>negateExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNegateExpr([NotNull] GrammarParser.NegateExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>addExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddExpr([NotNull] GrammarParser.AddExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>constantLit</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantLit([NotNull] GrammarParser.ConstantLitContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>numberLit</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumberLit([NotNull] GrammarParser.NumberLitContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>orExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrExpr([NotNull] GrammarParser.OrExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultExpr([NotNull] GrammarParser.MultExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>xorExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitXorExpr([NotNull] GrammarParser.XorExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenExpr([NotNull] GrammarParser.ParenExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>shiftExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitShiftExpr([NotNull] GrammarParser.ShiftExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>andExpr</c>
	/// labeled alternative in <see cref="GrammarParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAndExpr([NotNull] GrammarParser.AndExprContext context);
}
} // namespace PIR8.ISA.Assembly.Gen
