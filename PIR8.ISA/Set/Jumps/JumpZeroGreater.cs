namespace PIR8.ISA.Set.Jumps
{
	public sealed class JumpZeroGreater : BaseJump
	{
		public override string Mnemonic => "jmp.zg";
		protected override string Pattern => "100";
		protected override bool CheckJump(CPU cpu) => cpu.Flags.Has(Flags.Zero | Flags.Greater);
	}
}
