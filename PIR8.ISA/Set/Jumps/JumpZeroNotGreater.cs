namespace PIR8.ISA.Set.Jumps
{
	public sealed class JumpZeroNotGreater : BaseJump
	{
		public override string Mnemonic => "jmp.zng";
		protected override string Pattern => "101";
		protected override bool CheckJump(CPU cpu) => cpu.Flags.Has(Flags.Zero) || !cpu.Flags.Has(Flags.Greater);
	}
}
