using System;
using System.IO;

using JetBrains.Annotations;

using PIR8.ISA.Assembly.AST;

namespace PIR8.ISA.Assembly.Pipeline
{
	public static class DisassemblerPipeline
	{
		public static void Run(string file, BinaryReader input, [CanBeNull] BinaryReader debug, StreamWriter output)
		{
			var program = Decode(file, input, debug);
			var root = Disassemble(program);
			Unparse(file, root, output);
		}

		private static Program Decode(string file, BinaryReader input, [CanBeNull] BinaryReader debug)
		{
			throw new NotImplementedException();
		}

		private static RootNode Disassemble(Program program)
		{
			throw new NotImplementedException();
		}

		private static void Unparse(string file, RootNode root, StreamWriter output)
		{
			output.WriteLine($"; disassembly of {file}");
		}
	}
}
