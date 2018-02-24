using System;
using System.Runtime.Serialization;

namespace PIR8.ISA.Impl.Codec
{
	[Serializable]
	public sealed class NoMatch : Exception
	{
		public NoMatch()
		{
		}

		public NoMatch(string message)
			: base(message)
		{
		}

		public NoMatch(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		private NoMatch(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
