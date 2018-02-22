using PIR8.ISA.Impl.Codec;

namespace PIR8.ISA.Impl
{
	public interface IImpl
	{
		string Mnemonic { get; }
		bool Codec(BitBuffer buffer, Instruction insn);
		void Dispatch(Instruction insn, CPU cpu);
	}
}
