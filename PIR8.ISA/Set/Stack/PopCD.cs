namespace PIR8.ISA.Set.Stack
{
	public sealed class PopCD : BaseStack
	{
		protected override bool Push => false;
		protected override bool AB => false;
	}
}
