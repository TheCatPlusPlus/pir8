using System;

using PIR8.ISA.Utils;

namespace PIR8.ISA.Assembly.AST
{
	public sealed class NumberNode : ExprNode
	{
		public string RawValue { get; }
		public int Radix { get; }
		public string Digits { get; }
		public bool IsNegative { get; }

		public uint Value { get; }
		public int SignedValue { get; }
		public string BinaryValue => Convert.ToString(Value, 2);

		public NumberNode(string raw, bool negative, string digits, int radix)
		{
			RawValue = raw;
			Digits = digits;
			IsNegative = negative;
			Radix = radix;

			var value = Convert.ToUInt32(Digits, Radix);

			Value = IsNegative
				? value.TwoComplement()
				: value;
			SignedValue = IsNegative
				? -(int)value
				: (int)value;
		}
	}
}
