using System;

namespace PIR8.ISA.Assembly.Pipeline.AssemblerPasses
{
	internal abstract class AssemblerPass
	{
		protected AssemblerState State { get; }
		public string Name { get; }

		protected AssemblerPass(string name, AssemblerState state)
		{
			State = state;
			Name = name;
		}

		public void Run()
		{
			Console.WriteLine($"starting pass {State.Passes + 1}: {Name}");
			DoRun();
			State.Passes++;

			if (State.Errors > 0)
			{
				throw new Stop();
			}
		}

		protected abstract void DoRun();
	}
}
