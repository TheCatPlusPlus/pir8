using System.Collections.Generic;

using JetBrains.Annotations;

namespace PIR8.ISA.Assembly.AST
{
	public sealed class InstructionNode : EncodableNode
	{
		[CanBeNull]
		public string Mnemonic { get; set; }
		[NotNull]
		[ItemCanBeNull]
		public List<OperandNode> Operands { get; }

		public InstructionNode()
		{
			Operands = new List<OperandNode>();
		}
	}
}
