namespace PIR8.ISA.Set.Jumps
{
	public sealed class Jump : BaseJump
	{
		public override string Mnemonic => "jmp";
		protected override string Pattern => "111";
		protected override bool CheckJump(CPU cpu) => true;
	}
}
