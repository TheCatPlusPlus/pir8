using System;

using Antlr4.Runtime;

using PIR8.ISA.Assembly.AST;
using PIR8.ISA.Utils;

namespace PIR8.ISA.Assembly.Pipeline
{
	internal static class Diagnostics
	{
		internal static void Error(string file, Node node, string message)
		{
			Issue(file, node.Start, "error", ConsoleColor.DarkRed, message);
		}

		internal static void Warning(string file, Node node, string message)
		{
			Issue(file, node.Start, "warning", ConsoleColor.DarkYellow, message);
		}

		internal static void SyntaxError(string file, IToken node, string message)
		{
			Issue(file, node, "syntax error", ConsoleColor.DarkRed, message);
		}

		private static void Issue(string file, IToken node, string type, ConsoleColor color, string message)
		{
			var oldColor = Console.ForegroundColor;
			Console.ForegroundColor = color;
			Console.WriteLine($"{file}:{node.GetLocation()}: {type}: {message}");
			Console.ForegroundColor = oldColor;
		}
	}
}
