using JetBrains.Annotations;

using PIR8.ISA.Impl;

namespace PIR8.ISA
{
	public sealed class Insn
	{
		[CanBeNull]
		public IInsnImpl Impl { get; }
	}
}
