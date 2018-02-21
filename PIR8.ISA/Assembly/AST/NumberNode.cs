using System;

using JetBrains.Annotations;

using PIR8.ISA.Utils;

namespace PIR8.ISA.Assembly.AST
{
	public sealed class NumberNode : ExprNode
	{
		public string RawValue { get; }
		public int Radix { get; }
		public string Digits { get; }
		public bool IsNegative { get; }

		public uint? Value { get; }
		public int? SignedValue { get; }
		[CanBeNull]
		public string BinaryValue => Value != null
			? Convert.ToString(Value.Value, 2)
			: null;

		public NumberNode(string raw, bool negative, string digits, int radix)
		{
			RawValue = raw;
			Digits = digits;
			IsNegative = negative;
			Radix = radix;

			Value = TryParse();
			SignedValue = TryMakeSigned();
		}

		private uint? TryParse()
		{
			try
			{
				var value = Convert.ToUInt32(Digits, Radix);
				return IsNegative ? value.TwoComplement() : value;
			}
			catch (FormatException)
			{
				return null;
			}
		}

		private int? TryMakeSigned()
		{
			if (Value == null)
			{
				return null;
			}

			if (IsNegative)
			{
				return -(int)Value.Value.TwoComplement();
			}

			return (int)Value;
		}
	}
}
