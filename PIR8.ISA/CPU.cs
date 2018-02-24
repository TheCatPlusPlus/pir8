using System;
using System.IO;

namespace PIR8.ISA
{
	public sealed class CPU
	{
		private readonly Stream _decoderStream;
		public readonly Memory RAM;

		public byte F;
		public byte S;
		public byte X;
		public byte Y;
		public byte A;
		public byte B;
		public byte C;
		public byte D;

		public ushort PC;
		public ushort SP;
		public byte INS;

		public bool Halt;

		public Flags Flags
		{
			get => (Flags)F;
			set => F = (byte)value;
		}

		public ushort ADR => RAM.ADR;

		public ref byte this[Register reg]
		{
			get
			{
				switch (reg)
				{
					case Register.F:
						return ref F;
					case Register.S:
						return ref S;
					case Register.X:
						return ref X;
					case Register.Y:
						return ref Y;
					case Register.A:
						return ref A;
					case Register.B:
						return ref B;
					case Register.C:
						return ref C;
					case Register.D:
						return ref D;
					default:
						throw new ArgumentOutOfRangeException(nameof(reg), reg, null);
				}
			}
		}

		public CPU(Memory memory)
		{
			RAM = memory;
			_decoderStream = memory.MakeStream();
		}
	}
}
