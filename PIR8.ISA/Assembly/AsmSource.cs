using System;
using System.IO;

using Antlr4.Runtime;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;
using PIR8.ISA.Assembly.Visitors;
using PIR8.ISA.Utils;

namespace PIR8.ISA.Assembly
{
	public sealed class AsmSource
	{
		private AsmSource(RootNode root)
		{
			Console.WriteLine(root.ToFormattedString());
		}

		public static AsmSource Parse(StreamReader reader)
		{
			var input = new AntlrInputStream(reader);
			var lexer = new GrammarLexer(input);
			var tokens = new CommonTokenStream(lexer);
			var parser = new GrammarParser(tokens);

			var ctx = parser.file();
			var visitor = new RootVisitor();
			var root = visitor.Visit(ctx);
			return new AsmSource(root);
		}
	}
}
