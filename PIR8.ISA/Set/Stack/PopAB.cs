namespace PIR8.ISA.Set.Stack
{
	public sealed class PopAB : BaseStack
	{
		protected override bool Push => false;
		protected override bool AB => true;
	}
}
