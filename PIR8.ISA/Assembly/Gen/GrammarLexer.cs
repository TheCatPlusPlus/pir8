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
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class GrammarLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		COMMENT=1, LINE_COMMENT_1=2, LINE_COMMENT_2=3, NUMBER=4, LPAREN=5, RPAREN=6, 
		LBRACKET=7, RBRACKET=8, ARITH_RSHIFT=9, RSHIFT=10, LSHIFT=11, AND=12, 
		OR=13, MULTIPLY=14, DIVIDE=15, MODULO=16, ADD=17, MINUS=18, XOR=19, NOT=20, 
		COLON=21, COMMA=22, ASSIGN=23, KW_BYTE=24, KW_WORD=25, KW_DWORD=26, KW_QWORD=27, 
		KW_SECTION=28, KW_RESERVE=29, KW_FORMAT=30, REGISTER=31, LABEL=32, WHITESPACE=33;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"COMMENT", "LINE_COMMENT_1", "LINE_COMMENT_2", "HEX_DIGIT", "DIGIT", "HEX_NUMBER", 
		"OCT_NUMBER", "BIN_NUMBER", "DEC_NUMBER", "NUMBER", "LPAREN", "RPAREN", 
		"LBRACKET", "RBRACKET", "ARITH_RSHIFT", "RSHIFT", "LSHIFT", "AND", "OR", 
		"MULTIPLY", "DIVIDE", "MODULO", "ADD", "MINUS", "XOR", "NOT", "COLON", 
		"COMMA", "ASSIGN", "WORD", "KW_BYTE", "KW_WORD", "KW_DWORD", "KW_QWORD", 
		"KW_SECTION", "KW_RESERVE", "KW_FORMAT", "REGISTER", "LABEL", "WHITESPACE"
	};


	public GrammarLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public GrammarLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, null, null, "'('", "')'", "'['", "']'", "'>>>'", "'>>'", 
		"'<<'", "'&'", "'|'", "'*'", "'/'", "'%'", "'+'", "'-'", "'^'", "'~'", 
		"':'", "','", "'='"
	};
	private static readonly string[] _SymbolicNames = {
		null, "COMMENT", "LINE_COMMENT_1", "LINE_COMMENT_2", "NUMBER", "LPAREN", 
		"RPAREN", "LBRACKET", "RBRACKET", "ARITH_RSHIFT", "RSHIFT", "LSHIFT", 
		"AND", "OR", "MULTIPLY", "DIVIDE", "MODULO", "ADD", "MINUS", "XOR", "NOT", 
		"COLON", "COMMA", "ASSIGN", "KW_BYTE", "KW_WORD", "KW_DWORD", "KW_QWORD", 
		"KW_SECTION", "KW_RESERVE", "KW_FORMAT", "REGISTER", "LABEL", "WHITESPACE"
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

	public override string GrammarFileName { get { return "Grammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static GrammarLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '#', '\x10E', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\a', 
		'\x2', 'X', '\n', '\x2', '\f', '\x2', '\xE', '\x2', '[', '\v', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x3', '\x3', '\x3', '\a', '\x3', '\x64', '\n', '\x3', '\f', '\x3', 
		'\xE', '\x3', 'g', '\v', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\a', '\x4', 'o', '\n', '\x4', 
		'\f', '\x4', '\xE', '\x4', 'r', '\v', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x5', 
		'\a', '{', '\n', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x6', '\a', 
		'\x80', '\n', '\a', '\r', '\a', '\xE', '\a', '\x81', '\x3', '\b', '\x5', 
		'\b', '\x85', '\n', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x6', 
		'\b', '\x8A', '\n', '\b', '\r', '\b', '\xE', '\b', '\x8B', '\x3', '\t', 
		'\x3', '\t', '\x3', '\t', '\x6', '\t', '\x91', '\n', '\t', '\r', '\t', 
		'\xE', '\t', '\x92', '\x3', '\n', '\x5', '\n', '\x96', '\n', '\n', '\x3', 
		'\n', '\x6', '\n', '\x99', '\n', '\n', '\r', '\n', '\xE', '\n', '\x9A', 
		'\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x5', '\v', '\xA1', 
		'\n', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', 
		'\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', '\x3', 
		'\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', 
		'\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', 
		'\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', 
		'\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', ' ', 
		'\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', '!', '\x3', '\"', '\x3', '\"', 
		'\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '$', '\x3', '$', 
		'\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', 
		'\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', 
		'\x3', '%', '\x3', '%', '\x3', '&', '\x3', '&', '\x3', '&', '\x3', '&', 
		'\x3', '&', '\x3', '&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x6', '\'', 
		'\xF8', '\n', '\'', '\r', '\'', '\xE', '\'', '\xF9', '\x3', '\'', '\x3', 
		'\'', '\x6', '\'', '\xFE', '\n', '\'', '\r', '\'', '\xE', '\'', '\xFF', 
		'\x5', '\'', '\x102', '\n', '\'', '\x3', '(', '\x3', '(', '\a', '(', '\x106', 
		'\n', '(', '\f', '(', '\xE', '(', '\x109', '\v', '(', '\x3', ')', '\x3', 
		')', '\x3', ')', '\x3', ')', '\x3', 'Y', '\x2', '*', '\x3', '\x3', '\x5', 
		'\x4', '\a', '\x5', '\t', '\x2', '\v', '\x2', '\r', '\x2', '\xF', '\x2', 
		'\x11', '\x2', '\x13', '\x2', '\x15', '\x6', '\x17', '\a', '\x19', '\b', 
		'\x1B', '\t', '\x1D', '\n', '\x1F', '\v', '!', '\f', '#', '\r', '%', '\xE', 
		'\'', '\xF', ')', '\x10', '+', '\x11', '-', '\x12', '/', '\x13', '\x31', 
		'\x14', '\x33', '\x15', '\x35', '\x16', '\x37', '\x17', '\x39', '\x18', 
		';', '\x19', '=', '\x2', '?', '\x1A', '\x41', '\x1B', '\x43', '\x1C', 
		'\x45', '\x1D', 'G', '\x1E', 'I', '\x1F', 'K', ' ', 'M', '!', 'O', '\"', 
		'Q', '#', '\x3', '\x2', '\x1B', '\x4', '\x2', '\f', '\f', '\xF', '\xF', 
		'\x5', '\x2', '\x32', ';', '\x43', 'H', '\x63', 'h', '\x3', '\x2', '\x32', 
		';', '\x4', '\x2', 'Z', 'Z', 'z', 'z', '\x4', '\x2', 'Q', 'Q', 'q', 'q', 
		'\x4', '\x2', '\x44', '\x44', '\x64', '\x64', '\x4', '\x2', 'Y', 'Y', 
		'y', 'y', '\x4', '\x2', 'T', 'T', 't', 't', '\x4', '\x2', '\x46', '\x46', 
		'\x66', '\x66', '\x4', '\x2', '[', '[', '{', '{', '\x4', '\x2', 'V', 'V', 
		'v', 'v', '\x4', '\x2', 'G', 'G', 'g', 'g', '\x4', '\x2', 'S', 'S', 's', 
		's', '\x4', '\x2', 'U', 'U', 'u', 'u', '\x4', '\x2', '\x45', '\x45', '\x65', 
		'\x65', '\x4', '\x2', 'K', 'K', 'k', 'k', '\x4', '\x2', 'P', 'P', 'p', 
		'p', '\x4', '\x2', 'X', 'X', 'x', 'x', '\x4', '\x2', 'H', 'H', 'h', 'h', 
		'\x4', '\x2', 'O', 'O', 'o', 'o', '\x4', '\x2', '\x43', '\x43', '\x63', 
		'\x63', '\x3', '\x2', '\x43', '\\', '\x6', '\x2', '\x30', '\x30', '\x43', 
		'\\', '\x61', '\x61', '\x63', '|', '\a', '\x2', '\x30', '\x30', '\x32', 
		';', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\x5', '\x2', '\v', '\f', 
		'\xF', '\xF', '\"', '\"', '\x2', '\x117', '\x2', '\x3', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', '\x2', 
		'\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '/', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', '\x3', 
		'\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', '\x2', '\x2', '?', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x41', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x43', '\x3', '\x2', '\x2', '\x2', '\x2', '\x45', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'G', '\x3', '\x2', '\x2', '\x2', '\x2', 'I', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'K', '\x3', '\x2', '\x2', '\x2', '\x2', 'M', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'O', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'Q', '\x3', '\x2', '\x2', '\x2', '\x3', 'S', '\x3', '\x2', '\x2', '\x2', 
		'\x5', '\x61', '\x3', '\x2', '\x2', '\x2', '\a', 'j', '\x3', '\x2', '\x2', 
		'\x2', '\t', 'u', '\x3', '\x2', '\x2', '\x2', '\v', 'w', '\x3', '\x2', 
		'\x2', '\x2', '\r', 'z', '\x3', '\x2', '\x2', '\x2', '\xF', '\x84', '\x3', 
		'\x2', '\x2', '\x2', '\x11', '\x8D', '\x3', '\x2', '\x2', '\x2', '\x13', 
		'\x95', '\x3', '\x2', '\x2', '\x2', '\x15', '\xA0', '\x3', '\x2', '\x2', 
		'\x2', '\x17', '\xA2', '\x3', '\x2', '\x2', '\x2', '\x19', '\xA4', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', '\xA6', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'\xA8', '\x3', '\x2', '\x2', '\x2', '\x1F', '\xAA', '\x3', '\x2', '\x2', 
		'\x2', '!', '\xAE', '\x3', '\x2', '\x2', '\x2', '#', '\xB1', '\x3', '\x2', 
		'\x2', '\x2', '%', '\xB4', '\x3', '\x2', '\x2', '\x2', '\'', '\xB6', '\x3', 
		'\x2', '\x2', '\x2', ')', '\xB8', '\x3', '\x2', '\x2', '\x2', '+', '\xBA', 
		'\x3', '\x2', '\x2', '\x2', '-', '\xBC', '\x3', '\x2', '\x2', '\x2', '/', 
		'\xBE', '\x3', '\x2', '\x2', '\x2', '\x31', '\xC0', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\xC2', '\x3', '\x2', '\x2', '\x2', '\x35', '\xC4', '\x3', 
		'\x2', '\x2', '\x2', '\x37', '\xC6', '\x3', '\x2', '\x2', '\x2', '\x39', 
		'\xC8', '\x3', '\x2', '\x2', '\x2', ';', '\xCA', '\x3', '\x2', '\x2', 
		'\x2', '=', '\xCC', '\x3', '\x2', '\x2', '\x2', '?', '\xD1', '\x3', '\x2', 
		'\x2', '\x2', '\x41', '\xD6', '\x3', '\x2', '\x2', '\x2', '\x43', '\xD8', 
		'\x3', '\x2', '\x2', '\x2', '\x45', '\xDB', '\x3', '\x2', '\x2', '\x2', 
		'G', '\xDE', '\x3', '\x2', '\x2', '\x2', 'I', '\xE6', '\x3', '\x2', '\x2', 
		'\x2', 'K', '\xEE', '\x3', '\x2', '\x2', '\x2', 'M', '\x101', '\x3', '\x2', 
		'\x2', '\x2', 'O', '\x103', '\x3', '\x2', '\x2', '\x2', 'Q', '\x10A', 
		'\x3', '\x2', '\x2', '\x2', 'S', 'T', '\a', '\x31', '\x2', '\x2', 'T', 
		'U', '\a', ',', '\x2', '\x2', 'U', 'Y', '\x3', '\x2', '\x2', '\x2', 'V', 
		'X', '\v', '\x2', '\x2', '\x2', 'W', 'V', '\x3', '\x2', '\x2', '\x2', 
		'X', '[', '\x3', '\x2', '\x2', '\x2', 'Y', 'Z', '\x3', '\x2', '\x2', '\x2', 
		'Y', 'W', '\x3', '\x2', '\x2', '\x2', 'Z', '\\', '\x3', '\x2', '\x2', 
		'\x2', '[', 'Y', '\x3', '\x2', '\x2', '\x2', '\\', ']', '\a', ',', '\x2', 
		'\x2', ']', '^', '\a', '\x31', '\x2', '\x2', '^', '_', '\x3', '\x2', '\x2', 
		'\x2', '_', '`', '\b', '\x2', '\x2', '\x2', '`', '\x4', '\x3', '\x2', 
		'\x2', '\x2', '\x61', '\x65', '\a', '=', '\x2', '\x2', '\x62', '\x64', 
		'\n', '\x2', '\x2', '\x2', '\x63', '\x62', '\x3', '\x2', '\x2', '\x2', 
		'\x64', 'g', '\x3', '\x2', '\x2', '\x2', '\x65', '\x63', '\x3', '\x2', 
		'\x2', '\x2', '\x65', '\x66', '\x3', '\x2', '\x2', '\x2', '\x66', 'h', 
		'\x3', '\x2', '\x2', '\x2', 'g', '\x65', '\x3', '\x2', '\x2', '\x2', 'h', 
		'i', '\b', '\x3', '\x2', '\x2', 'i', '\x6', '\x3', '\x2', '\x2', '\x2', 
		'j', 'k', '\a', '\x31', '\x2', '\x2', 'k', 'l', '\a', '\x31', '\x2', '\x2', 
		'l', 'p', '\x3', '\x2', '\x2', '\x2', 'm', 'o', '\n', '\x2', '\x2', '\x2', 
		'n', 'm', '\x3', '\x2', '\x2', '\x2', 'o', 'r', '\x3', '\x2', '\x2', '\x2', 
		'p', 'n', '\x3', '\x2', '\x2', '\x2', 'p', 'q', '\x3', '\x2', '\x2', '\x2', 
		'q', 's', '\x3', '\x2', '\x2', '\x2', 'r', 'p', '\x3', '\x2', '\x2', '\x2', 
		's', 't', '\b', '\x4', '\x2', '\x2', 't', '\b', '\x3', '\x2', '\x2', '\x2', 
		'u', 'v', '\t', '\x3', '\x2', '\x2', 'v', '\n', '\x3', '\x2', '\x2', '\x2', 
		'w', 'x', '\t', '\x4', '\x2', '\x2', 'x', '\f', '\x3', '\x2', '\x2', '\x2', 
		'y', '{', '\a', '/', '\x2', '\x2', 'z', 'y', '\x3', '\x2', '\x2', '\x2', 
		'z', '{', '\x3', '\x2', '\x2', '\x2', '{', '|', '\x3', '\x2', '\x2', '\x2', 
		'|', '}', '\a', '\x32', '\x2', '\x2', '}', '\x7F', '\t', '\x5', '\x2', 
		'\x2', '~', '\x80', '\x5', '\t', '\x5', '\x2', '\x7F', '~', '\x3', '\x2', 
		'\x2', '\x2', '\x80', '\x81', '\x3', '\x2', '\x2', '\x2', '\x81', '\x7F', 
		'\x3', '\x2', '\x2', '\x2', '\x81', '\x82', '\x3', '\x2', '\x2', '\x2', 
		'\x82', '\xE', '\x3', '\x2', '\x2', '\x2', '\x83', '\x85', '\a', '/', 
		'\x2', '\x2', '\x84', '\x83', '\x3', '\x2', '\x2', '\x2', '\x84', '\x85', 
		'\x3', '\x2', '\x2', '\x2', '\x85', '\x86', '\x3', '\x2', '\x2', '\x2', 
		'\x86', '\x87', '\a', '\x32', '\x2', '\x2', '\x87', '\x89', '\t', '\x6', 
		'\x2', '\x2', '\x88', '\x8A', '\x5', '\v', '\x6', '\x2', '\x89', '\x88', 
		'\x3', '\x2', '\x2', '\x2', '\x8A', '\x8B', '\x3', '\x2', '\x2', '\x2', 
		'\x8B', '\x89', '\x3', '\x2', '\x2', '\x2', '\x8B', '\x8C', '\x3', '\x2', 
		'\x2', '\x2', '\x8C', '\x10', '\x3', '\x2', '\x2', '\x2', '\x8D', '\x8E', 
		'\a', '\x32', '\x2', '\x2', '\x8E', '\x90', '\t', '\a', '\x2', '\x2', 
		'\x8F', '\x91', '\x5', '\v', '\x6', '\x2', '\x90', '\x8F', '\x3', '\x2', 
		'\x2', '\x2', '\x91', '\x92', '\x3', '\x2', '\x2', '\x2', '\x92', '\x90', 
		'\x3', '\x2', '\x2', '\x2', '\x92', '\x93', '\x3', '\x2', '\x2', '\x2', 
		'\x93', '\x12', '\x3', '\x2', '\x2', '\x2', '\x94', '\x96', '\a', '/', 
		'\x2', '\x2', '\x95', '\x94', '\x3', '\x2', '\x2', '\x2', '\x95', '\x96', 
		'\x3', '\x2', '\x2', '\x2', '\x96', '\x98', '\x3', '\x2', '\x2', '\x2', 
		'\x97', '\x99', '\x5', '\v', '\x6', '\x2', '\x98', '\x97', '\x3', '\x2', 
		'\x2', '\x2', '\x99', '\x9A', '\x3', '\x2', '\x2', '\x2', '\x9A', '\x98', 
		'\x3', '\x2', '\x2', '\x2', '\x9A', '\x9B', '\x3', '\x2', '\x2', '\x2', 
		'\x9B', '\x14', '\x3', '\x2', '\x2', '\x2', '\x9C', '\xA1', '\x5', '\r', 
		'\a', '\x2', '\x9D', '\xA1', '\x5', '\xF', '\b', '\x2', '\x9E', '\xA1', 
		'\x5', '\x11', '\t', '\x2', '\x9F', '\xA1', '\x5', '\x13', '\n', '\x2', 
		'\xA0', '\x9C', '\x3', '\x2', '\x2', '\x2', '\xA0', '\x9D', '\x3', '\x2', 
		'\x2', '\x2', '\xA0', '\x9E', '\x3', '\x2', '\x2', '\x2', '\xA0', '\x9F', 
		'\x3', '\x2', '\x2', '\x2', '\xA1', '\x16', '\x3', '\x2', '\x2', '\x2', 
		'\xA2', '\xA3', '\a', '*', '\x2', '\x2', '\xA3', '\x18', '\x3', '\x2', 
		'\x2', '\x2', '\xA4', '\xA5', '\a', '+', '\x2', '\x2', '\xA5', '\x1A', 
		'\x3', '\x2', '\x2', '\x2', '\xA6', '\xA7', '\a', ']', '\x2', '\x2', '\xA7', 
		'\x1C', '\x3', '\x2', '\x2', '\x2', '\xA8', '\xA9', '\a', '_', '\x2', 
		'\x2', '\xA9', '\x1E', '\x3', '\x2', '\x2', '\x2', '\xAA', '\xAB', '\a', 
		'@', '\x2', '\x2', '\xAB', '\xAC', '\a', '@', '\x2', '\x2', '\xAC', '\xAD', 
		'\a', '@', '\x2', '\x2', '\xAD', ' ', '\x3', '\x2', '\x2', '\x2', '\xAE', 
		'\xAF', '\a', '@', '\x2', '\x2', '\xAF', '\xB0', '\a', '@', '\x2', '\x2', 
		'\xB0', '\"', '\x3', '\x2', '\x2', '\x2', '\xB1', '\xB2', '\a', '>', '\x2', 
		'\x2', '\xB2', '\xB3', '\a', '>', '\x2', '\x2', '\xB3', '$', '\x3', '\x2', 
		'\x2', '\x2', '\xB4', '\xB5', '\a', '(', '\x2', '\x2', '\xB5', '&', '\x3', 
		'\x2', '\x2', '\x2', '\xB6', '\xB7', '\a', '~', '\x2', '\x2', '\xB7', 
		'(', '\x3', '\x2', '\x2', '\x2', '\xB8', '\xB9', '\a', ',', '\x2', '\x2', 
		'\xB9', '*', '\x3', '\x2', '\x2', '\x2', '\xBA', '\xBB', '\a', '\x31', 
		'\x2', '\x2', '\xBB', ',', '\x3', '\x2', '\x2', '\x2', '\xBC', '\xBD', 
		'\a', '\'', '\x2', '\x2', '\xBD', '.', '\x3', '\x2', '\x2', '\x2', '\xBE', 
		'\xBF', '\a', '-', '\x2', '\x2', '\xBF', '\x30', '\x3', '\x2', '\x2', 
		'\x2', '\xC0', '\xC1', '\a', '/', '\x2', '\x2', '\xC1', '\x32', '\x3', 
		'\x2', '\x2', '\x2', '\xC2', '\xC3', '\a', '`', '\x2', '\x2', '\xC3', 
		'\x34', '\x3', '\x2', '\x2', '\x2', '\xC4', '\xC5', '\a', '\x80', '\x2', 
		'\x2', '\xC5', '\x36', '\x3', '\x2', '\x2', '\x2', '\xC6', '\xC7', '\a', 
		'<', '\x2', '\x2', '\xC7', '\x38', '\x3', '\x2', '\x2', '\x2', '\xC8', 
		'\xC9', '\a', '.', '\x2', '\x2', '\xC9', ':', '\x3', '\x2', '\x2', '\x2', 
		'\xCA', '\xCB', '\a', '?', '\x2', '\x2', '\xCB', '<', '\x3', '\x2', '\x2', 
		'\x2', '\xCC', '\xCD', '\t', '\b', '\x2', '\x2', '\xCD', '\xCE', '\t', 
		'\x6', '\x2', '\x2', '\xCE', '\xCF', '\t', '\t', '\x2', '\x2', '\xCF', 
		'\xD0', '\t', '\n', '\x2', '\x2', '\xD0', '>', '\x3', '\x2', '\x2', '\x2', 
		'\xD1', '\xD2', '\t', '\a', '\x2', '\x2', '\xD2', '\xD3', '\t', '\v', 
		'\x2', '\x2', '\xD3', '\xD4', '\t', '\f', '\x2', '\x2', '\xD4', '\xD5', 
		'\t', '\r', '\x2', '\x2', '\xD5', '@', '\x3', '\x2', '\x2', '\x2', '\xD6', 
		'\xD7', '\x5', '=', '\x1F', '\x2', '\xD7', '\x42', '\x3', '\x2', '\x2', 
		'\x2', '\xD8', '\xD9', '\t', '\n', '\x2', '\x2', '\xD9', '\xDA', '\x5', 
		'=', '\x1F', '\x2', '\xDA', '\x44', '\x3', '\x2', '\x2', '\x2', '\xDB', 
		'\xDC', '\t', '\xE', '\x2', '\x2', '\xDC', '\xDD', '\x5', '=', '\x1F', 
		'\x2', '\xDD', '\x46', '\x3', '\x2', '\x2', '\x2', '\xDE', '\xDF', '\t', 
		'\xF', '\x2', '\x2', '\xDF', '\xE0', '\t', '\r', '\x2', '\x2', '\xE0', 
		'\xE1', '\t', '\x10', '\x2', '\x2', '\xE1', '\xE2', '\t', '\f', '\x2', 
		'\x2', '\xE2', '\xE3', '\t', '\x11', '\x2', '\x2', '\xE3', '\xE4', '\t', 
		'\x6', '\x2', '\x2', '\xE4', '\xE5', '\t', '\x12', '\x2', '\x2', '\xE5', 
		'H', '\x3', '\x2', '\x2', '\x2', '\xE6', '\xE7', '\t', '\t', '\x2', '\x2', 
		'\xE7', '\xE8', '\t', '\r', '\x2', '\x2', '\xE8', '\xE9', '\t', '\xF', 
		'\x2', '\x2', '\xE9', '\xEA', '\t', '\r', '\x2', '\x2', '\xEA', '\xEB', 
		'\t', '\t', '\x2', '\x2', '\xEB', '\xEC', '\t', '\x13', '\x2', '\x2', 
		'\xEC', '\xED', '\t', '\r', '\x2', '\x2', '\xED', 'J', '\x3', '\x2', '\x2', 
		'\x2', '\xEE', '\xEF', '\t', '\x14', '\x2', '\x2', '\xEF', '\xF0', '\t', 
		'\x6', '\x2', '\x2', '\xF0', '\xF1', '\t', '\t', '\x2', '\x2', '\xF1', 
		'\xF2', '\t', '\x15', '\x2', '\x2', '\xF2', '\xF3', '\t', '\x16', '\x2', 
		'\x2', '\xF3', '\xF4', '\t', '\f', '\x2', '\x2', '\xF4', 'L', '\x3', '\x2', 
		'\x2', '\x2', '\xF5', '\xF7', '\t', '\t', '\x2', '\x2', '\xF6', '\xF8', 
		'\t', '\x4', '\x2', '\x2', '\xF7', '\xF6', '\x3', '\x2', '\x2', '\x2', 
		'\xF8', '\xF9', '\x3', '\x2', '\x2', '\x2', '\xF9', '\xF7', '\x3', '\x2', 
		'\x2', '\x2', '\xF9', '\xFA', '\x3', '\x2', '\x2', '\x2', '\xFA', '\x102', 
		'\x3', '\x2', '\x2', '\x2', '\xFB', '\xFD', '\t', '\t', '\x2', '\x2', 
		'\xFC', '\xFE', '\t', '\x17', '\x2', '\x2', '\xFD', '\xFC', '\x3', '\x2', 
		'\x2', '\x2', '\xFE', '\xFF', '\x3', '\x2', '\x2', '\x2', '\xFF', '\xFD', 
		'\x3', '\x2', '\x2', '\x2', '\xFF', '\x100', '\x3', '\x2', '\x2', '\x2', 
		'\x100', '\x102', '\x3', '\x2', '\x2', '\x2', '\x101', '\xF5', '\x3', 
		'\x2', '\x2', '\x2', '\x101', '\xFB', '\x3', '\x2', '\x2', '\x2', '\x102', 
		'N', '\x3', '\x2', '\x2', '\x2', '\x103', '\x107', '\t', '\x18', '\x2', 
		'\x2', '\x104', '\x106', '\t', '\x19', '\x2', '\x2', '\x105', '\x104', 
		'\x3', '\x2', '\x2', '\x2', '\x106', '\x109', '\x3', '\x2', '\x2', '\x2', 
		'\x107', '\x105', '\x3', '\x2', '\x2', '\x2', '\x107', '\x108', '\x3', 
		'\x2', '\x2', '\x2', '\x108', 'P', '\x3', '\x2', '\x2', '\x2', '\x109', 
		'\x107', '\x3', '\x2', '\x2', '\x2', '\x10A', '\x10B', '\t', '\x1A', '\x2', 
		'\x2', '\x10B', '\x10C', '\x3', '\x2', '\x2', '\x2', '\x10C', '\x10D', 
		'\b', ')', '\x3', '\x2', '\x10D', 'R', '\x3', '\x2', '\x2', '\x2', '\x12', 
		'\x2', 'Y', '\x65', 'p', 'z', '\x81', '\x84', '\x8B', '\x92', '\x95', 
		'\x9A', '\xA0', '\xF9', '\xFF', '\x101', '\x107', '\x4', '\x2', '\x3', 
		'\x2', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace PIR8.ISA.Assembly.Gen
