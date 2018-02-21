//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Numbers.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace PIR8.ISA.Assembly.Gen {
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class NumbersParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SIGN=1, HEX_INTRO=2, OCT_INTRO=3, BIN_INTRO=4, HEX_DIGITS=5, DIGITS=6;
	public const int
		RULE_number = 0;
	public static readonly string[] ruleNames = {
		"number"
	};

	private static readonly string[] _LiteralNames = {
		null, "'-'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SIGN", "HEX_INTRO", "OCT_INTRO", "BIN_INTRO", "HEX_DIGITS", "DIGITS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Numbers.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static NumbersParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public NumbersParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public NumbersParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}
	public partial class NumberContext : ParserRuleContext {
		public NumberContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_number; } }
	 
		public NumberContext() { }
		public virtual void CopyFrom(NumberContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class OctContext : NumberContext {
		public ITerminalNode OCT_INTRO() { return GetToken(NumbersParser.OCT_INTRO, 0); }
		public ITerminalNode DIGITS() { return GetToken(NumbersParser.DIGITS, 0); }
		public ITerminalNode SIGN() { return GetToken(NumbersParser.SIGN, 0); }
		public OctContext(NumberContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			INumbersVisitor<TResult> typedVisitor = visitor as INumbersVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitOct(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class DecContext : NumberContext {
		public ITerminalNode DIGITS() { return GetToken(NumbersParser.DIGITS, 0); }
		public DecContext(NumberContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			INumbersVisitor<TResult> typedVisitor = visitor as INumbersVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDec(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class BinContext : NumberContext {
		public ITerminalNode BIN_INTRO() { return GetToken(NumbersParser.BIN_INTRO, 0); }
		public ITerminalNode DIGITS() { return GetToken(NumbersParser.DIGITS, 0); }
		public BinContext(NumberContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			INumbersVisitor<TResult> typedVisitor = visitor as INumbersVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBin(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class HexContext : NumberContext {
		public ITerminalNode HEX_INTRO() { return GetToken(NumbersParser.HEX_INTRO, 0); }
		public ITerminalNode HEX_DIGITS() { return GetToken(NumbersParser.HEX_DIGITS, 0); }
		public ITerminalNode SIGN() { return GetToken(NumbersParser.SIGN, 0); }
		public HexContext(NumberContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			INumbersVisitor<TResult> typedVisitor = visitor as INumbersVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitHex(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public NumberContext number() {
		NumberContext _localctx = new NumberContext(Context, State);
		EnterRule(_localctx, 0, RULE_number);
		int _la;
		try {
			State = 15;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
			case 1:
				_localctx = new HexContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 3;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==SIGN) {
					{
					State = 2; Match(SIGN);
					}
				}

				State = 5; Match(HEX_INTRO);
				State = 6; Match(HEX_DIGITS);
				}
				break;
			case 2:
				_localctx = new OctContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 8;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==SIGN) {
					{
					State = 7; Match(SIGN);
					}
				}

				State = 10; Match(OCT_INTRO);
				State = 11; Match(DIGITS);
				}
				break;
			case 3:
				_localctx = new BinContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 12; Match(BIN_INTRO);
				State = 13; Match(DIGITS);
				}
				break;
			case 4:
				_localctx = new DecContext(_localctx);
				EnterOuterAlt(_localctx, 4);
				{
				State = 14; Match(DIGITS);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\b', '\x14', '\x4', '\x2', '\t', '\x2', '\x3', '\x2', 
		'\x5', '\x2', '\x6', '\n', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x5', '\x2', '\v', '\n', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\x5', '\x2', '\x12', '\n', '\x2', '\x3', 
		'\x2', '\x2', '\x2', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', '\x2', 
		'\x11', '\x3', '\x2', '\x2', '\x2', '\x4', '\x6', '\a', '\x3', '\x2', 
		'\x2', '\x5', '\x4', '\x3', '\x2', '\x2', '\x2', '\x5', '\x6', '\x3', 
		'\x2', '\x2', '\x2', '\x6', '\a', '\x3', '\x2', '\x2', '\x2', '\a', '\b', 
		'\a', '\x4', '\x2', '\x2', '\b', '\x12', '\a', '\a', '\x2', '\x2', '\t', 
		'\v', '\a', '\x3', '\x2', '\x2', '\n', '\t', '\x3', '\x2', '\x2', '\x2', 
		'\n', '\v', '\x3', '\x2', '\x2', '\x2', '\v', '\f', '\x3', '\x2', '\x2', 
		'\x2', '\f', '\r', '\a', '\x5', '\x2', '\x2', '\r', '\x12', '\a', '\b', 
		'\x2', '\x2', '\xE', '\xF', '\a', '\x6', '\x2', '\x2', '\xF', '\x12', 
		'\a', '\b', '\x2', '\x2', '\x10', '\x12', '\a', '\b', '\x2', '\x2', '\x11', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x11', '\n', '\x3', '\x2', '\x2', 
		'\x2', '\x11', '\xE', '\x3', '\x2', '\x2', '\x2', '\x11', '\x10', '\x3', 
		'\x2', '\x2', '\x2', '\x12', '\x3', '\x3', '\x2', '\x2', '\x2', '\x5', 
		'\x5', '\n', '\x11',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace PIR8.ISA.Assembly.Gen
