using PIR8.ISA.Utils;

namespace PIR8.ISA.Set.Jumps
{
	public sealed class Call : BaseJump
	{
		public override string Mnemonic => "call";
		protected override string Pattern => "110";
		protected override bool CheckJump(CPU cpu) => true;

		public override void Dispatch(Instruction insn, CPU cpu)
		{
			// XXX make sure fetching increments PC by buffer.Size
			var ret = cpu.PC;
			(cpu.S, cpu.F) = ret.Split();
			base.Dispatch(insn, cpu);
		}
	}
}
