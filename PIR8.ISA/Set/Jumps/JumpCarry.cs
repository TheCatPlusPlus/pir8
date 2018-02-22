namespace PIR8.ISA.Set.Jumps
{
	public sealed class JumpCarry : BaseJump
	{
		public override string Mnemonic => "jmp.c";
		protected override string Pattern => "011";
		protected override bool CheckJump(CPU cpu) => cpu.Flags.Has(Flags.Carry);
	}
}
