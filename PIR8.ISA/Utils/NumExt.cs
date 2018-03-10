using System;
using System.Runtime.CompilerServices;

using PIR8.ISA.Set.ALU;

namespace PIR8.ISA.Utils
{
	public static class NumExt
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint TwoComplement(this uint value)
		{
			return unchecked(~value + 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (byte, byte) Split(this ushort value)
		{
			return (value.Hi(), value.Lo());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort Merge(byte hi, byte lo)
		{
			return (ushort)((hi << 8) | lo);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte Hi(this ushort value)
		{
			return (byte)((value >> 8) & 0xFFu);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte Lo(this ushort value)
		{
			return (byte)(value & 0xFFu);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Parity(this byte value)
		{
			// TODO maybe get POPCNT

			var count = 0;
			for (var idx = 0; idx < 8; idx++)
			{
				count += value & (1 << idx);
			}

			return (count % 2) == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (byte, bool) Shift(this byte value, bool carry, ShiftDirection direction, ShiftType type)
		{
			var left = direction == ShiftDirection.Left;

			switch (type)
			{
				case ShiftType.Logical:
					return left
						? value.ShiftLeft()
						: value.ShiftRight();
				case ShiftType.Arithmetic:
					return left
						? value.ShiftLeft()
						: value.ArithmeticShiftRight();
				case ShiftType.RotateWithCarry:
					return left
						? value.RotateCarryLeft(carry)
						: value.RotateCarryRight(carry);
				case ShiftType.Rotate:
					return left
						? value.RotateLeft()
						: value.RotateRight();
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (byte, bool) ShiftLeft(this byte value)
		{
			var carry = (value & (1 << 7)) != 0;
			value = (byte)(value << 1);
			return (value, carry);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (byte, bool) ShiftRight(this byte value)
		{
			var carry = (value & 1) != 0;
			value = (byte)(value >> 1);
			return (value, carry);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (byte, bool) ArithmeticShiftRight(this byte value)
		{
			var sign = (value & (1 << 7)) != 0;
			bool carry;
			(value, carry) = value.ShiftRight();
			value |= (byte)((sign ? 1 : 0) << 7);
			return (value, carry);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (byte, bool) RotateCarryLeft(this byte value, bool carry)
		{
			var extended = (ushort)((value << 1) | (carry ? 1 : 0));
			ushort newValue;
			(newValue, carry) = extended.DoRotateLeft(9);
			return ((byte)((newValue >> 1) & 0xFF), carry);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (byte, bool) RotateCarryRight(this byte value, bool carry)
		{
			var extended = (ushort)((value << 1) | (carry ? 1 : 0));
			ushort newValue;
			(newValue, carry) = extended.DoRotateRight(9);
			return ((byte)((newValue >> 1) & 0xFF), carry);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (byte, bool) RotateLeft(this byte value)
		{
			(var newValue, var carry) = ((ushort)value).DoRotateLeft(8);
			return ((byte)(newValue & 0xFF), carry);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static (byte, bool) RotateRight(this byte value)
		{
			(var newValue, var carry) = ((ushort)value).DoRotateRight(8);
			return ((byte)(newValue & 0xFF), carry);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static (ushort, bool) DoRotateLeft(this ushort value, int bits)
		{
			var mask = (int)Math.Pow(2, bits) - 1;
			var newValue = ((value << 1) | (value >> (bits - 1))) & mask;
			var carry = (newValue & 1) != 0;
			return ((ushort)newValue, carry);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static (ushort, bool) DoRotateRight(this ushort value, int bits)
		{
			var mask = (int)Math.Pow(2, bits) - 1;
			var newValue = ((value >> 1) | (value << (bits - 1))) & mask;
			var carry = (newValue & 1) != 0;
			return ((ushort)newValue, carry);
		}
	}
}
