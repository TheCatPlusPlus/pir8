using System.IO;

using Antlr4.Runtime;

using JetBrains.Annotations;

namespace PIR8.ISA.Assembly.Pipeline
{
	public sealed class ErrorListener : BaseErrorListener
	{
		private readonly string _file;
		public bool HasErrors { get; private set; }

		public ErrorListener(string file)
		{
			_file = file;
		}

		public override void SyntaxError(
			[NotNull] TextWriter output, [NotNull] IRecognizer recognizer, [NotNull] IToken offendingSymbol, int line,
			int charPositionInLine, [NotNull] string msg, [NotNull] RecognitionException e)
		{
			Diagnostics.SyntaxError(_file, offendingSymbol, msg);
			HasErrors = true;
		}

		public void SyntaxError(ParserRuleContext context, string message)
		{
			Diagnostics.SyntaxError(_file, context.Start, message);
			HasErrors = true;
		}
	}
}
