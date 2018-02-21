using System;
using System.Runtime.Serialization;

namespace PIR8.ISA.Assembly.Pipeline
{
	[Serializable]
	internal sealed class Stop : Exception
	{
		public Stop()
		{
		}

		public Stop(string message)
			: base(message)
		{
		}

		public Stop(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		private Stop(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
