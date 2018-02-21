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
		REGISTER=28, LABEL=29, WHITESPACE=30;
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
		"REGISTER", "LABEL", "WHITESPACE"
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
		"REGISTER", "LABEL", "WHITESPACE"
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
		'\x5964', '\x2', ' ', '\xF1', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
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
		'\t', '&', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\a', 
		'\x2', 'R', '\n', '\x2', '\f', '\x2', '\xE', '\x2', 'U', '\v', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x3', '\x3', '\x3', '\a', '\x3', '^', '\n', '\x3', '\f', '\x3', 
		'\xE', '\x3', '\x61', '\v', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\a', '\x4', 'i', '\n', 
		'\x4', '\f', '\x4', '\xE', '\x4', 'l', '\v', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\a', '\x5', '\a', 'u', '\n', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x6', '\a', 'z', '\n', '\a', '\r', '\a', '\xE', '\a', '{', '\x3', '\b', 
		'\x5', '\b', '\x7F', '\n', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', 
		'\x6', '\b', '\x84', '\n', '\b', '\r', '\b', '\xE', '\b', '\x85', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x6', '\t', '\x8B', '\n', '\t', '\r', 
		'\t', '\xE', '\t', '\x8C', '\x3', '\n', '\x5', '\n', '\x90', '\n', '\n', 
		'\x3', '\n', '\x6', '\n', '\x93', '\n', '\n', '\r', '\n', '\xE', '\n', 
		'\x94', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x5', '\v', 
		'\x9B', '\n', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', 
		'\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', 
		'\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', 
		'\x3', '\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', 
		'\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', 
		'\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', ' ', '\x3', ' ', '\x3', 
		' ', '\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', '!', '\x3', '\"', '\x3', 
		'\"', '\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '$', '\x3', 
		'$', '\x6', '$', '\xDB', '\n', '$', '\r', '$', '\xE', '$', '\xDC', '\x3', 
		'$', '\x3', '$', '\x6', '$', '\xE1', '\n', '$', '\r', '$', '\xE', '$', 
		'\xE2', '\x5', '$', '\xE5', '\n', '$', '\x3', '%', '\x3', '%', '\a', '%', 
		'\xE9', '\n', '%', '\f', '%', '\xE', '%', '\xEC', '\v', '%', '\x3', '&', 
		'\x3', '&', '\x3', '&', '\x3', '&', '\x3', 'S', '\x2', '\'', '\x3', '\x3', 
		'\x5', '\x4', '\a', '\x5', '\t', '\x2', '\v', '\x2', '\r', '\x2', '\xF', 
		'\x2', '\x11', '\x2', '\x13', '\x2', '\x15', '\x6', '\x17', '\a', '\x19', 
		'\b', '\x1B', '\t', '\x1D', '\n', '\x1F', '\v', '!', '\f', '#', '\r', 
		'%', '\xE', '\'', '\xF', ')', '\x10', '+', '\x11', '-', '\x12', '/', '\x13', 
		'\x31', '\x14', '\x33', '\x15', '\x35', '\x16', '\x37', '\x17', '\x39', 
		'\x18', ';', '\x19', '=', '\x2', '?', '\x1A', '\x41', '\x1B', '\x43', 
		'\x1C', '\x45', '\x1D', 'G', '\x1E', 'I', '\x1F', 'K', ' ', '\x3', '\x2', 
		'\x13', '\x4', '\x2', '\f', '\f', '\xF', '\xF', '\x5', '\x2', '\x32', 
		';', '\x43', 'H', '\x63', 'h', '\x3', '\x2', '\x32', ';', '\x4', '\x2', 
		'Z', 'Z', 'z', 'z', '\x4', '\x2', 'Q', 'Q', 'q', 'q', '\x4', '\x2', '\x44', 
		'\x44', '\x64', '\x64', '\x4', '\x2', 'Y', 'Y', 'y', 'y', '\x4', '\x2', 
		'T', 'T', 't', 't', '\x4', '\x2', '\x46', '\x46', '\x66', '\x66', '\x4', 
		'\x2', '[', '[', '{', '{', '\x4', '\x2', 'V', 'V', 'v', 'v', '\x4', '\x2', 
		'G', 'G', 'g', 'g', '\x4', '\x2', 'S', 'S', 's', 's', '\x3', '\x2', '\x43', 
		'\\', '\x6', '\x2', '\x30', '\x30', '\x43', '\\', '\x61', '\x61', '\x63', 
		'|', '\a', '\x2', '\x30', '\x30', '\x32', ';', '\x43', '\\', '\x61', '\x61', 
		'\x63', '|', '\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x2', 
		'\xFA', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x35', '\x3', '\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '?', '\x3', '\x2', '\x2', '\x2', '\x2', '\x41', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x43', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x45', '\x3', '\x2', '\x2', '\x2', '\x2', 'G', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'I', '\x3', '\x2', '\x2', '\x2', '\x2', 'K', '\x3', '\x2', '\x2', 
		'\x2', '\x3', 'M', '\x3', '\x2', '\x2', '\x2', '\x5', '[', '\x3', '\x2', 
		'\x2', '\x2', '\a', '\x64', '\x3', '\x2', '\x2', '\x2', '\t', 'o', '\x3', 
		'\x2', '\x2', '\x2', '\v', 'q', '\x3', '\x2', '\x2', '\x2', '\r', 't', 
		'\x3', '\x2', '\x2', '\x2', '\xF', '~', '\x3', '\x2', '\x2', '\x2', '\x11', 
		'\x87', '\x3', '\x2', '\x2', '\x2', '\x13', '\x8F', '\x3', '\x2', '\x2', 
		'\x2', '\x15', '\x9A', '\x3', '\x2', '\x2', '\x2', '\x17', '\x9C', '\x3', 
		'\x2', '\x2', '\x2', '\x19', '\x9E', '\x3', '\x2', '\x2', '\x2', '\x1B', 
		'\xA0', '\x3', '\x2', '\x2', '\x2', '\x1D', '\xA2', '\x3', '\x2', '\x2', 
		'\x2', '\x1F', '\xA4', '\x3', '\x2', '\x2', '\x2', '!', '\xA8', '\x3', 
		'\x2', '\x2', '\x2', '#', '\xAB', '\x3', '\x2', '\x2', '\x2', '%', '\xAE', 
		'\x3', '\x2', '\x2', '\x2', '\'', '\xB0', '\x3', '\x2', '\x2', '\x2', 
		')', '\xB2', '\x3', '\x2', '\x2', '\x2', '+', '\xB4', '\x3', '\x2', '\x2', 
		'\x2', '-', '\xB6', '\x3', '\x2', '\x2', '\x2', '/', '\xB8', '\x3', '\x2', 
		'\x2', '\x2', '\x31', '\xBA', '\x3', '\x2', '\x2', '\x2', '\x33', '\xBC', 
		'\x3', '\x2', '\x2', '\x2', '\x35', '\xBE', '\x3', '\x2', '\x2', '\x2', 
		'\x37', '\xC0', '\x3', '\x2', '\x2', '\x2', '\x39', '\xC2', '\x3', '\x2', 
		'\x2', '\x2', ';', '\xC4', '\x3', '\x2', '\x2', '\x2', '=', '\xC6', '\x3', 
		'\x2', '\x2', '\x2', '?', '\xCB', '\x3', '\x2', '\x2', '\x2', '\x41', 
		'\xD0', '\x3', '\x2', '\x2', '\x2', '\x43', '\xD2', '\x3', '\x2', '\x2', 
		'\x2', '\x45', '\xD5', '\x3', '\x2', '\x2', '\x2', 'G', '\xE4', '\x3', 
		'\x2', '\x2', '\x2', 'I', '\xE6', '\x3', '\x2', '\x2', '\x2', 'K', '\xED', 
		'\x3', '\x2', '\x2', '\x2', 'M', 'N', '\a', '\x31', '\x2', '\x2', 'N', 
		'O', '\a', ',', '\x2', '\x2', 'O', 'S', '\x3', '\x2', '\x2', '\x2', 'P', 
		'R', '\v', '\x2', '\x2', '\x2', 'Q', 'P', '\x3', '\x2', '\x2', '\x2', 
		'R', 'U', '\x3', '\x2', '\x2', '\x2', 'S', 'T', '\x3', '\x2', '\x2', '\x2', 
		'S', 'Q', '\x3', '\x2', '\x2', '\x2', 'T', 'V', '\x3', '\x2', '\x2', '\x2', 
		'U', 'S', '\x3', '\x2', '\x2', '\x2', 'V', 'W', '\a', ',', '\x2', '\x2', 
		'W', 'X', '\a', '\x31', '\x2', '\x2', 'X', 'Y', '\x3', '\x2', '\x2', '\x2', 
		'Y', 'Z', '\b', '\x2', '\x2', '\x2', 'Z', '\x4', '\x3', '\x2', '\x2', 
		'\x2', '[', '_', '\a', '=', '\x2', '\x2', '\\', '^', '\n', '\x2', '\x2', 
		'\x2', ']', '\\', '\x3', '\x2', '\x2', '\x2', '^', '\x61', '\x3', '\x2', 
		'\x2', '\x2', '_', ']', '\x3', '\x2', '\x2', '\x2', '_', '`', '\x3', '\x2', 
		'\x2', '\x2', '`', '\x62', '\x3', '\x2', '\x2', '\x2', '\x61', '_', '\x3', 
		'\x2', '\x2', '\x2', '\x62', '\x63', '\b', '\x3', '\x2', '\x2', '\x63', 
		'\x6', '\x3', '\x2', '\x2', '\x2', '\x64', '\x65', '\a', '\x31', '\x2', 
		'\x2', '\x65', '\x66', '\a', '\x31', '\x2', '\x2', '\x66', 'j', '\x3', 
		'\x2', '\x2', '\x2', 'g', 'i', '\n', '\x2', '\x2', '\x2', 'h', 'g', '\x3', 
		'\x2', '\x2', '\x2', 'i', 'l', '\x3', '\x2', '\x2', '\x2', 'j', 'h', '\x3', 
		'\x2', '\x2', '\x2', 'j', 'k', '\x3', '\x2', '\x2', '\x2', 'k', 'm', '\x3', 
		'\x2', '\x2', '\x2', 'l', 'j', '\x3', '\x2', '\x2', '\x2', 'm', 'n', '\b', 
		'\x4', '\x2', '\x2', 'n', '\b', '\x3', '\x2', '\x2', '\x2', 'o', 'p', 
		'\t', '\x3', '\x2', '\x2', 'p', '\n', '\x3', '\x2', '\x2', '\x2', 'q', 
		'r', '\t', '\x4', '\x2', '\x2', 'r', '\f', '\x3', '\x2', '\x2', '\x2', 
		's', 'u', '\a', '/', '\x2', '\x2', 't', 's', '\x3', '\x2', '\x2', '\x2', 
		't', 'u', '\x3', '\x2', '\x2', '\x2', 'u', 'v', '\x3', '\x2', '\x2', '\x2', 
		'v', 'w', '\a', '\x32', '\x2', '\x2', 'w', 'y', '\t', '\x5', '\x2', '\x2', 
		'x', 'z', '\x5', '\t', '\x5', '\x2', 'y', 'x', '\x3', '\x2', '\x2', '\x2', 
		'z', '{', '\x3', '\x2', '\x2', '\x2', '{', 'y', '\x3', '\x2', '\x2', '\x2', 
		'{', '|', '\x3', '\x2', '\x2', '\x2', '|', '\xE', '\x3', '\x2', '\x2', 
		'\x2', '}', '\x7F', '\a', '/', '\x2', '\x2', '~', '}', '\x3', '\x2', '\x2', 
		'\x2', '~', '\x7F', '\x3', '\x2', '\x2', '\x2', '\x7F', '\x80', '\x3', 
		'\x2', '\x2', '\x2', '\x80', '\x81', '\a', '\x32', '\x2', '\x2', '\x81', 
		'\x83', '\t', '\x6', '\x2', '\x2', '\x82', '\x84', '\x5', '\v', '\x6', 
		'\x2', '\x83', '\x82', '\x3', '\x2', '\x2', '\x2', '\x84', '\x85', '\x3', 
		'\x2', '\x2', '\x2', '\x85', '\x83', '\x3', '\x2', '\x2', '\x2', '\x85', 
		'\x86', '\x3', '\x2', '\x2', '\x2', '\x86', '\x10', '\x3', '\x2', '\x2', 
		'\x2', '\x87', '\x88', '\a', '\x32', '\x2', '\x2', '\x88', '\x8A', '\t', 
		'\a', '\x2', '\x2', '\x89', '\x8B', '\x5', '\v', '\x6', '\x2', '\x8A', 
		'\x89', '\x3', '\x2', '\x2', '\x2', '\x8B', '\x8C', '\x3', '\x2', '\x2', 
		'\x2', '\x8C', '\x8A', '\x3', '\x2', '\x2', '\x2', '\x8C', '\x8D', '\x3', 
		'\x2', '\x2', '\x2', '\x8D', '\x12', '\x3', '\x2', '\x2', '\x2', '\x8E', 
		'\x90', '\a', '/', '\x2', '\x2', '\x8F', '\x8E', '\x3', '\x2', '\x2', 
		'\x2', '\x8F', '\x90', '\x3', '\x2', '\x2', '\x2', '\x90', '\x92', '\x3', 
		'\x2', '\x2', '\x2', '\x91', '\x93', '\x5', '\v', '\x6', '\x2', '\x92', 
		'\x91', '\x3', '\x2', '\x2', '\x2', '\x93', '\x94', '\x3', '\x2', '\x2', 
		'\x2', '\x94', '\x92', '\x3', '\x2', '\x2', '\x2', '\x94', '\x95', '\x3', 
		'\x2', '\x2', '\x2', '\x95', '\x14', '\x3', '\x2', '\x2', '\x2', '\x96', 
		'\x9B', '\x5', '\r', '\a', '\x2', '\x97', '\x9B', '\x5', '\xF', '\b', 
		'\x2', '\x98', '\x9B', '\x5', '\x11', '\t', '\x2', '\x99', '\x9B', '\x5', 
		'\x13', '\n', '\x2', '\x9A', '\x96', '\x3', '\x2', '\x2', '\x2', '\x9A', 
		'\x97', '\x3', '\x2', '\x2', '\x2', '\x9A', '\x98', '\x3', '\x2', '\x2', 
		'\x2', '\x9A', '\x99', '\x3', '\x2', '\x2', '\x2', '\x9B', '\x16', '\x3', 
		'\x2', '\x2', '\x2', '\x9C', '\x9D', '\a', '*', '\x2', '\x2', '\x9D', 
		'\x18', '\x3', '\x2', '\x2', '\x2', '\x9E', '\x9F', '\a', '+', '\x2', 
		'\x2', '\x9F', '\x1A', '\x3', '\x2', '\x2', '\x2', '\xA0', '\xA1', '\a', 
		']', '\x2', '\x2', '\xA1', '\x1C', '\x3', '\x2', '\x2', '\x2', '\xA2', 
		'\xA3', '\a', '_', '\x2', '\x2', '\xA3', '\x1E', '\x3', '\x2', '\x2', 
		'\x2', '\xA4', '\xA5', '\a', '@', '\x2', '\x2', '\xA5', '\xA6', '\a', 
		'@', '\x2', '\x2', '\xA6', '\xA7', '\a', '@', '\x2', '\x2', '\xA7', ' ', 
		'\x3', '\x2', '\x2', '\x2', '\xA8', '\xA9', '\a', '@', '\x2', '\x2', '\xA9', 
		'\xAA', '\a', '@', '\x2', '\x2', '\xAA', '\"', '\x3', '\x2', '\x2', '\x2', 
		'\xAB', '\xAC', '\a', '>', '\x2', '\x2', '\xAC', '\xAD', '\a', '>', '\x2', 
		'\x2', '\xAD', '$', '\x3', '\x2', '\x2', '\x2', '\xAE', '\xAF', '\a', 
		'(', '\x2', '\x2', '\xAF', '&', '\x3', '\x2', '\x2', '\x2', '\xB0', '\xB1', 
		'\a', '~', '\x2', '\x2', '\xB1', '(', '\x3', '\x2', '\x2', '\x2', '\xB2', 
		'\xB3', '\a', ',', '\x2', '\x2', '\xB3', '*', '\x3', '\x2', '\x2', '\x2', 
		'\xB4', '\xB5', '\a', '\x31', '\x2', '\x2', '\xB5', ',', '\x3', '\x2', 
		'\x2', '\x2', '\xB6', '\xB7', '\a', '\'', '\x2', '\x2', '\xB7', '.', '\x3', 
		'\x2', '\x2', '\x2', '\xB8', '\xB9', '\a', '-', '\x2', '\x2', '\xB9', 
		'\x30', '\x3', '\x2', '\x2', '\x2', '\xBA', '\xBB', '\a', '/', '\x2', 
		'\x2', '\xBB', '\x32', '\x3', '\x2', '\x2', '\x2', '\xBC', '\xBD', '\a', 
		'`', '\x2', '\x2', '\xBD', '\x34', '\x3', '\x2', '\x2', '\x2', '\xBE', 
		'\xBF', '\a', '\x80', '\x2', '\x2', '\xBF', '\x36', '\x3', '\x2', '\x2', 
		'\x2', '\xC0', '\xC1', '\a', '<', '\x2', '\x2', '\xC1', '\x38', '\x3', 
		'\x2', '\x2', '\x2', '\xC2', '\xC3', '\a', '.', '\x2', '\x2', '\xC3', 
		':', '\x3', '\x2', '\x2', '\x2', '\xC4', '\xC5', '\a', '?', '\x2', '\x2', 
		'\xC5', '<', '\x3', '\x2', '\x2', '\x2', '\xC6', '\xC7', '\t', '\b', '\x2', 
		'\x2', '\xC7', '\xC8', '\t', '\x6', '\x2', '\x2', '\xC8', '\xC9', '\t', 
		'\t', '\x2', '\x2', '\xC9', '\xCA', '\t', '\n', '\x2', '\x2', '\xCA', 
		'>', '\x3', '\x2', '\x2', '\x2', '\xCB', '\xCC', '\t', '\a', '\x2', '\x2', 
		'\xCC', '\xCD', '\t', '\v', '\x2', '\x2', '\xCD', '\xCE', '\t', '\f', 
		'\x2', '\x2', '\xCE', '\xCF', '\t', '\r', '\x2', '\x2', '\xCF', '@', '\x3', 
		'\x2', '\x2', '\x2', '\xD0', '\xD1', '\x5', '=', '\x1F', '\x2', '\xD1', 
		'\x42', '\x3', '\x2', '\x2', '\x2', '\xD2', '\xD3', '\t', '\n', '\x2', 
		'\x2', '\xD3', '\xD4', '\x5', '=', '\x1F', '\x2', '\xD4', '\x44', '\x3', 
		'\x2', '\x2', '\x2', '\xD5', '\xD6', '\t', '\xE', '\x2', '\x2', '\xD6', 
		'\xD7', '\x5', '=', '\x1F', '\x2', '\xD7', '\x46', '\x3', '\x2', '\x2', 
		'\x2', '\xD8', '\xDA', '\t', '\t', '\x2', '\x2', '\xD9', '\xDB', '\t', 
		'\x4', '\x2', '\x2', '\xDA', '\xD9', '\x3', '\x2', '\x2', '\x2', '\xDB', 
		'\xDC', '\x3', '\x2', '\x2', '\x2', '\xDC', '\xDA', '\x3', '\x2', '\x2', 
		'\x2', '\xDC', '\xDD', '\x3', '\x2', '\x2', '\x2', '\xDD', '\xE5', '\x3', 
		'\x2', '\x2', '\x2', '\xDE', '\xE0', '\t', '\t', '\x2', '\x2', '\xDF', 
		'\xE1', '\t', '\xF', '\x2', '\x2', '\xE0', '\xDF', '\x3', '\x2', '\x2', 
		'\x2', '\xE1', '\xE2', '\x3', '\x2', '\x2', '\x2', '\xE2', '\xE0', '\x3', 
		'\x2', '\x2', '\x2', '\xE2', '\xE3', '\x3', '\x2', '\x2', '\x2', '\xE3', 
		'\xE5', '\x3', '\x2', '\x2', '\x2', '\xE4', '\xD8', '\x3', '\x2', '\x2', 
		'\x2', '\xE4', '\xDE', '\x3', '\x2', '\x2', '\x2', '\xE5', 'H', '\x3', 
		'\x2', '\x2', '\x2', '\xE6', '\xEA', '\t', '\x10', '\x2', '\x2', '\xE7', 
		'\xE9', '\t', '\x11', '\x2', '\x2', '\xE8', '\xE7', '\x3', '\x2', '\x2', 
		'\x2', '\xE9', '\xEC', '\x3', '\x2', '\x2', '\x2', '\xEA', '\xE8', '\x3', 
		'\x2', '\x2', '\x2', '\xEA', '\xEB', '\x3', '\x2', '\x2', '\x2', '\xEB', 
		'J', '\x3', '\x2', '\x2', '\x2', '\xEC', '\xEA', '\x3', '\x2', '\x2', 
		'\x2', '\xED', '\xEE', '\t', '\x12', '\x2', '\x2', '\xEE', '\xEF', '\x3', 
		'\x2', '\x2', '\x2', '\xEF', '\xF0', '\b', '&', '\x3', '\x2', '\xF0', 
		'L', '\x3', '\x2', '\x2', '\x2', '\x12', '\x2', 'S', '_', 'j', 't', '{', 
		'~', '\x85', '\x8C', '\x8F', '\x94', '\x9A', '\xDC', '\xE2', '\xE4', '\xEA', 
		'\x4', '\x2', '\x3', '\x2', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace PIR8.ISA.Assembly.Gen
