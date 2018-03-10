using System;

namespace PIR8.ISA
{
	public struct InsnData
	{
		public string Mnemonic;
		public ulong Operand1;
		public ulong Operand2;
		public ulong Operand3;

		public ulong this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return Operand1;
					case 1:
						return Operand2;
					case 2:
						return Operand3;
					default:
						throw new ArgumentOutOfRangeException(nameof(index), index, $"Operand index {index} out of range");
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						Operand1 = value;
						break;
					case 1:
						Operand2 = value;
						break;
					case 2:
						Operand3 = value;
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(index), index, $"Operand index {index} out of range");
				}
			}
		}
	}
}
