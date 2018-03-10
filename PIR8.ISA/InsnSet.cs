using System;

using JetBrains.Annotations;

using PIR8.ISA.Impl;
using PIR8.ISA.Impl.Operands;
using PIR8.ISA.Set;
using PIR8.ISA.Set.ALU;
using PIR8.ISA.Set.Jumps;
using PIR8.ISA.Set.Stack;

namespace PIR8.ISA
{
	public static class InsnSet
	{
		public static readonly IInsnImpl[] Known =
		{
			// ALU
			new Add(),
			new ArithmeticShift.Left(),
			new ArithmeticShift.Right(),
			new BitAnd(),
			new BitNot(),
			new BitOr(),
			new BitXor(),
			new LogicalShift.Left(),
			new LogicalShift.Right(),
			new Rotate.Left(),
			new Rotate.Right(),
			new RotateWithCarry.Left(),
			new RotateWithCarry.Right(),
			new Subtract(),

			// jumps
			new Call(),
			new Jump(),
			new JumpCarry(),
			new JumpGreater(),
			new JumpParity(),
			new JumpZero(),
			new JumpZeroGreater(),
			new JumpZeroNotGreater(),

			// stack ops
			new PopAB(),
			new PopCD(),
			new PushAB(),
			new PushCD(),

			// registers
			new ClearFlags(),
			new Compare(),
			new Move(),

			// memory
			new LoadImm(),
			new LoadMem(),
			new Save(),

			// control
			new Halt()
		};

		[CanBeNull]
		public static IInsnImpl Match(
			string mnemonic, [CanBeNull] Type operand1, [CanBeNull] Type operand2, [CanBeNull] Type operand3)
		{
			Console.WriteLine($"Trying to match {mnemonic}, {operand1}, {operand2}, {operand3}");

			foreach (var insn in Known)
			{
				Console.WriteLine($"\tcandidate: {insn.GetType().Name} ({insn.Mnemonic}, {insn.GetType().BaseType.Name})");

				if (string.Compare(insn.Mnemonic, mnemonic, StringComparison.OrdinalIgnoreCase) != 0)
				{
					Console.WriteLine($"\t\tmnemonic doesn't match");
					continue;
				}

				var operands = insn.GetType().BaseType.GenericTypeArguments;
				var none = typeof(None);
				operand1 = operand1 ?? none;
				operand2 = operand2 ?? none;
				operand3 = operand3 ?? none;

				if (operands[0] != operand1)
				{
					Console.WriteLine($"\t\toperand1 ({operands[0].Name}) doesn't match ({operand1.Name})");
					continue;
				}

				if (operands[1] != operand2)
				{
					Console.WriteLine($"\t\toperand2 ({operands[1].Name}) doesn't match ({operand2.Name})");
					continue;
				}

				if (operands[2] != operand3)
				{
					Console.WriteLine($"\t\toperand1 ({operands[2].Name}) doesn't match ({operand3.Name})");
					continue;
				}

				return insn;
			}

			return null;
		}
	}
}
