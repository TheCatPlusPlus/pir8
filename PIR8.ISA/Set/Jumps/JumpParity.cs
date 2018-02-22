namespace PIR8.ISA.Set.Jumps
{
	public sealed class JumpParity : BaseJump
	{
		public override string Mnemonic => "jmp.p";
		protected override string Pattern => "001";
		protected override bool CheckJump(CPU cpu) => cpu.Flags.Has(Flags.Parity);
	}
}
