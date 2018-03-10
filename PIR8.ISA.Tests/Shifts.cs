using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PIR8.ISA.Utils;

namespace PIR8.ISA.Tests
{
	[TestClass]
	public sealed class Shifts
	{
		private const byte TestValue1 = 0b1100_0011;
		private const byte TestValue2 = 0b0011_1100;
		private const byte TestValue3 = 0b1100_0000;
		private const byte TestValue4 = 0b0000_0011;

		[DataTestMethod]
		[DataRow(0b100_00110, true, TestValue1)]
		[DataRow(0b011_11000, false, TestValue2)]
		[DataRow(0b100_00000, true, TestValue3)]
		[DataRow(0b000_00110, false, TestValue4)]
		public void TestLogicShiftLeft(int expectedValue, bool expectedCarry, byte testValue)
		{
			CheckShift(expectedValue, expectedCarry, testValue, x => x.ShiftLeft());
		}

		[DataTestMethod]
		[DataRow(0b01100_001, true, TestValue1)]
		[DataRow(0b00011_110, false, TestValue2)]
		[DataRow(0b01100_000, false, TestValue3)]
		[DataRow(0b00000_001, true, TestValue4)]
		public void TestLogicShiftRight(int expectedValue, bool expectedCarry, byte testValue)
		{
			CheckShift(expectedValue, expectedCarry, testValue, x => x.ShiftRight());
		}

		[DataTestMethod]
		[DataRow(0b11100_001, true, TestValue1)]
		[DataRow(0b00011_110, false, TestValue2)]
		[DataRow(0b11100_000, false, TestValue3)]
		[DataRow(0b00000_001, true, TestValue4)]
		public void TestArithmeticShiftRight(int expectedValue, bool expectedCarry, byte testValue)
		{
			CheckShift(expectedValue, expectedCarry, testValue, x => x.ArithmeticShiftRight());
		}

		[DataTestMethod]
		[DataRow(0b100_00111, true, TestValue1, true)]
		[DataRow(0b011_11001, false, TestValue2, true)]
		[DataRow(0b100_00001, true, TestValue3, true)]
		[DataRow(0b000_00111, false, TestValue4, true)]
		[DataRow(0b100_00110, true, TestValue1, false)]
		[DataRow(0b011_11000, false, TestValue2, false)]
		[DataRow(0b100_00000, true, TestValue3, false)]
		[DataRow(0b000_00110, false, TestValue4, false)]
		public void TestRotateCarryLeft(int expectedValue, bool expectedCarry, byte testValue, bool testCarry)
		{
			CheckShift(expectedValue, expectedCarry, testValue, x => x.RotateCarryLeft(testCarry));
		}

		[DataTestMethod]
		[DataRow(0b11100_001, true, TestValue1, true)]
		[DataRow(0b10011_110, false, TestValue2, true)]
		[DataRow(0b11100_000, false, TestValue3, true)]
		[DataRow(0b10000_001, true, TestValue4, true)]
		[DataRow(0b01100_001, true, TestValue1, false)]
		[DataRow(0b00011_110, false, TestValue2, false)]
		[DataRow(0b01100_000, false, TestValue3, false)]
		[DataRow(0b00000_001, true, TestValue4, false)]
		public void TestRotateCarryRight(int expectedValue, bool expectedCarry, byte testValue, bool testCarry)
		{
			CheckShift(expectedValue, expectedCarry, testValue, x => x.RotateCarryRight(testCarry));
		}

		[DataTestMethod]
		[DataRow(0b100_00111, true, TestValue1)]
		[DataRow(0b011_11000, false, TestValue2)]
		[DataRow(0b100_00001, true, TestValue3)]
		[DataRow(0b000_00110, false, TestValue4)]
		public void TestRotateLeft(int expectedValue, bool expectedCarry, byte testValue)
		{
			CheckShift(expectedValue, expectedCarry, testValue, x => x.RotateLeft());
		}

		[DataTestMethod]
		[DataRow(0b11100_001, true, TestValue1)]
		[DataRow(0b00011_110, false, TestValue2)]
		[DataRow(0b01100_000, false, TestValue3)]
		[DataRow(0b10000_001, true, TestValue4)]
		public void TestRotateRight(int expectedValue, bool expectedCarry, byte testValue)
		{
			CheckShift(expectedValue, expectedCarry, testValue, x => x.RotateRight());
		}

		private static void Check(byte expected, byte actual)
		{
			Assert.AreEqual(expected, actual);
		}

		private static void Check(bool expected, bool actual)
		{
			Assert.AreEqual(expected, actual);
		}

		private static void CheckShift(int expectedValue, bool expectedCarry, byte testValue, Func<byte, (byte, bool)> shift)
		{
			(var value, var carry) = shift(testValue);
			Check((byte)expectedValue, value);
			Check(expectedCarry, carry);
		}
	}
}
