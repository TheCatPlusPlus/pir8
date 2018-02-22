namespace PIR8.ISA.Set.Jumps
{
	public sealed class JumpZero : BaseJump
	{
		public override string Mnemonic => "jmp.z";
		protected override string Pattern => "000";
		protected override bool CheckJump(CPU cpu) => cpu.Flags.Has(Flags.Zero);
	}
}
