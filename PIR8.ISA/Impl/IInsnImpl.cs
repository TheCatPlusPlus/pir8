using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Impl
{
	public interface IInsnImpl
	{
		string Mnemonic { get; }
		void Codec(BitBuffer buffer, ref InsnData insn);
		void Dispatch(CPU cpu, in InsnData insn);
	}
}
