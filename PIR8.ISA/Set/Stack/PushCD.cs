namespace PIR8.ISA.Set.Stack
{
	public sealed class PushCD : BaseStack
	{
		protected override bool Push => true;
		protected override bool AB => false;
	}
}
