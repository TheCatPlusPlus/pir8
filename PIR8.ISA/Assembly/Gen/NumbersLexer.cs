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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class NumbersLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SIGN=1, HEX_INTRO=2, OCT_INTRO=3, BIN_INTRO=4, HEX_DIGITS=5, DIGITS=6;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"SIGN", "HEX_INTRO", "OCT_INTRO", "BIN_INTRO", "HEX_DIGITS", "DIGITS"
	};


	public NumbersLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public NumbersLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static NumbersLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\b', '$', '\b', '\x1', '\x4', '\x2', '\t', '\x2', '\x4', 
		'\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', 
		'\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x3', 
		'\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x6', '\x6', '\x6', '\x1C', '\n', '\x6', '\r', '\x6', '\xE', '\x6', '\x1D', 
		'\x3', '\a', '\x6', '\a', '!', '\n', '\a', '\r', '\a', '\xE', '\a', '\"', 
		'\x2', '\x2', '\b', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', 
		'\v', '\a', '\r', '\b', '\x3', '\x2', '\a', '\x4', '\x2', 'Z', 'Z', 'z', 
		'z', '\x4', '\x2', 'Q', 'Q', 'q', 'q', '\x4', '\x2', '\x44', '\x44', '\x64', 
		'\x64', '\x5', '\x2', '\x32', ';', '\x43', 'H', '\x63', 'h', '\x3', '\x2', 
		'\x32', ';', '\x2', '%', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x3', '\xF', '\x3', '\x2', 
		'\x2', '\x2', '\x5', '\x11', '\x3', '\x2', '\x2', '\x2', '\a', '\x14', 
		'\x3', '\x2', '\x2', '\x2', '\t', '\x17', '\x3', '\x2', '\x2', '\x2', 
		'\v', '\x1B', '\x3', '\x2', '\x2', '\x2', '\r', ' ', '\x3', '\x2', '\x2', 
		'\x2', '\xF', '\x10', '\a', '/', '\x2', '\x2', '\x10', '\x4', '\x3', '\x2', 
		'\x2', '\x2', '\x11', '\x12', '\a', '\x32', '\x2', '\x2', '\x12', '\x13', 
		'\t', '\x2', '\x2', '\x2', '\x13', '\x6', '\x3', '\x2', '\x2', '\x2', 
		'\x14', '\x15', '\a', '\x32', '\x2', '\x2', '\x15', '\x16', '\t', '\x3', 
		'\x2', '\x2', '\x16', '\b', '\x3', '\x2', '\x2', '\x2', '\x17', '\x18', 
		'\a', '\x32', '\x2', '\x2', '\x18', '\x19', '\t', '\x4', '\x2', '\x2', 
		'\x19', '\n', '\x3', '\x2', '\x2', '\x2', '\x1A', '\x1C', '\t', '\x5', 
		'\x2', '\x2', '\x1B', '\x1A', '\x3', '\x2', '\x2', '\x2', '\x1C', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', '\x1D', '\x1B', '\x3', '\x2', '\x2', '\x2', 
		'\x1D', '\x1E', '\x3', '\x2', '\x2', '\x2', '\x1E', '\f', '\x3', '\x2', 
		'\x2', '\x2', '\x1F', '!', '\t', '\x6', '\x2', '\x2', ' ', '\x1F', '\x3', 
		'\x2', '\x2', '\x2', '!', '\"', '\x3', '\x2', '\x2', '\x2', '\"', ' ', 
		'\x3', '\x2', '\x2', '\x2', '\"', '#', '\x3', '\x2', '\x2', '\x2', '#', 
		'\xE', '\x3', '\x2', '\x2', '\x2', '\x5', '\x2', '\x1D', '\"', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace PIR8.ISA.Assembly.Gen
