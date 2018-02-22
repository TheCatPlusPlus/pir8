using System;
using System.Runtime.Serialization;

namespace PIR8.ISA
{
	[Serializable]
	public sealed class InvalidInstruction : Exception
	{
		public InvalidInstruction()
		{
		}

		public InvalidInstruction(string message)
			: base(message)
		{
		}

		public InvalidInstruction(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		private InvalidInstruction(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
