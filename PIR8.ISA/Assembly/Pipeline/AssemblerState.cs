using System.Collections.Generic;

using PIR8.ISA.Assembly.AST;

namespace PIR8.ISA.Assembly.Pipeline
{
	internal sealed class AssemblerState
	{
		private readonly string _file;

		internal readonly RootNode Source;
		internal readonly Dictionary<string, Node> Names;
		internal readonly Dictionary<string, ExprNode> Consts;
		internal readonly Dictionary<string, uint> Labels;
		internal readonly Dictionary<string, ProgramSection> Sections;
		internal readonly Dictionary<EncodableNode, Insn> EncodableReprs;

		public Program Program { get; }

		public int Passes { get; internal set; }
		public int Warnings { get; private set; }
		public int Errors { get; private set; }

		internal AssemblerState(string file, RootNode source)
		{
			_file = file;
			Source = source;
			Names = new Dictionary<string, Node>();
			Consts = new Dictionary<string, ExprNode>();
			Labels = new Dictionary<string, uint>();
			Sections = new Dictionary<string, ProgramSection>();
			EncodableReprs = new Dictionary<EncodableNode, Insn>();

			Program = new Program();
		}

		internal void Warning(Node node, string message)
		{
			Diagnostics.Warning(_file, node, message);
			Warnings++;
		}

		internal void Error(Node node, string message)
		{
			Diagnostics.Error(_file, node, message);
			Errors++;
		}
	}
}
