using Microsoft.VisualStudio.TestTools.UnitTesting;

using PIR8.ISA.Utils;

namespace PIR8.ISA.Tests
{
	[TestClass]
	public sealed class Shifts
	{
		private const byte TestValue1 = 0b1100_0011;
		private const byte TestValue2 = 0b0011_1100;

		private static void Check(byte expected, byte actual)
		{
			Assert.AreEqual(expected, actual);
		}

		private static void Check(bool expected, bool actual)
		{
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestLogicShiftLeft1()
		{
			(var value, var carry) = TestValue1.ShiftLeft();
			Check(0b100_00110, value);
			Check(true, carry);
		}

		[TestMethod]
		public void TestLogicShiftLeft2()
		{
			(var value, var carry) = TestValue2.ShiftLeft();
			Check(0b011_11000, value);
			Check(false, carry);
		}

		[TestMethod]
		public void TestLogicShiftRight1()
		{
			(var value, var carry) = TestValue1.ShiftRight();
			Check(0b01100_001, value);
			Check(true, carry);
		}

		[TestMethod]
		public void TestLogicShiftRight2()
		{
			(var value, var carry) = TestValue2.ShiftRight();
			Check(0b00011_110, value);
			Check(false, carry);
		}

		[TestMethod]
		public void TestArithmeticShiftRight1()
		{
			(var value, var carry) = TestValue1.ArithmeticShiftRight();
			Check(0b11100_001, value);
			Check(true, carry);
		}

		[TestMethod]
		public void TestArithmeticShiftRight2()
		{
			(var value, var carry) = TestValue2.ArithmeticShiftRight();
			Check(0b00011_110, value);
			Check(false, carry);
		}

		[TestMethod]
		public void TestRotateCarryLeft1T()
		{
			(var value, var carry) = TestValue1.RotateCarryLeft(true);
			Check(0b100_00111, value);
			Check(true, carry);
		}

		[TestMethod]
		public void TestRotateCarryLeft2T()
		{
			(var value, var carry) = TestValue2.RotateCarryLeft(true);
			Check(0b011_11001, value);
			Check(false, carry);
		}

		[TestMethod]
		public void TestRotateCarryRight1T()
		{
			(var value, var carry) = TestValue1.RotateCarryRight(true);
			Check(0b11100_001, value);
			Check(true, carry);
		}

		[TestMethod]
		public void TestRotateCarryRight2T()
		{
			(var value, var carry) = TestValue2.RotateCarryRight(true);
			Check(0b10011_110, value);
			Check(false, carry);
		}

		[TestMethod]
		public void TestRotateCarryLeft1F()
		{
			(var value, var carry) = TestValue1.RotateCarryLeft(false);
			Check(0b100_00110, value);
			Check(true, carry);
		}

		[TestMethod]
		public void TestRotateCarryLeft2F()
		{
			(var value, var carry) = TestValue2.RotateCarryLeft(false);
			Check(0b011_11000, value);
			Check(false, carry);
		}

		[TestMethod]
		public void TestRotateCarryRight1F()
		{
			(var value, var carry) = TestValue1.RotateCarryRight(false);
			Check(0b01100_001, value);
			Check(true, carry);
		}

		[TestMethod]
		public void TestRotateCarryRight2F()
		{
			(var value, var carry) = TestValue2.RotateCarryRight(false);
			Check(0b00011_110, value);
			Check(false, carry);
		}

		[TestMethod]
		public void TestRotateLeft1()
		{
			(var value, var carry) = TestValue1.RotateLeft();
			Check(0b100_00111, value);
			Check(true, carry);
		}

		[TestMethod]
		public void TestRotateLeft2()
		{
			(var value, var carry) = TestValue2.RotateLeft();
			Check(0b011_11000, value);
			Check(false, carry);
		}

		[TestMethod]
		public void TestRotateRight1()
		{
			(var value, var carry) = TestValue1.RotateRight();
			Check(0b11100_001, value);
			Check(true, carry);
		}

		[TestMethod]
		public void TestRotateRight2()
		{
			(var value, var carry) = TestValue2.RotateRight();
			Check(0b00011_110, value);
			Check(false, carry);
		}
	}
}
