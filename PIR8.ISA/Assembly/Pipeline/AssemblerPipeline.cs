using System;
using System.IO;

using Antlr4.Runtime;

using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Assembly.Gen;
using PIR8.ISA.Assembly.Pipeline.AssemblerPasses;
using PIR8.ISA.Assembly.Visitors;

namespace PIR8.ISA.Assembly.Pipeline
{
	public static class AssemblerPipeline
	{
		public static void Run(string file, StreamReader input, BinaryWriter output, [CanBeNull] BinaryWriter debug)
		{
			var root = Parse(file, input);
			var program = Assemble(file, root);
			Encode(program, output, debug);
		}

		public static RootNode Parse(string file, StreamReader reader)
		{
			var input = new AntlrInputStream(reader);
			var lexer = new GrammarLexer(input);
			var tokens = new CommonTokenStream(lexer);
			var parser = new GrammarParser(tokens);
			var errors = new ErrorListener(file);

			parser.RemoveErrorListeners();
			parser.AddErrorListener(errors);

			var ctx = parser.file();
			var visitor = new RootVisitor(errors);
			var root = visitor.Visit(ctx);

			if (errors.HasErrors)
			{
				Environment.Exit(1);
			}

			return root;
		}

		public static Program Assemble(string file, RootNode source)
		{
			var state = new AssemblerState(file, source);
			var passes = new AssemblerPass[]
			{
				new Collect(state)
			};

			try
			{
				foreach (var pass in passes)
				{
					pass.Run();
				}
			}
			catch (Stop)
			{
			}

			return state.Program;
		}

		public static void Encode(Program program, BinaryWriter output, [CanBeNull] BinaryWriter debug)
		{
		}
	}
}
