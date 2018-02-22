namespace PIR8.ISA.Set.Jumps
{
	public sealed class JumpGreater : BaseJump
	{
		public override string Mnemonic => "jmp.g";
		protected override string Pattern => "010";
		protected override bool CheckJump(CPU cpu) => cpu.Flags.Has(Flags.Greater);
	}
}
