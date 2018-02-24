using System;
using System.IO;

using JetBrains.Annotations;

using PIR8.ISA.Utils;

namespace PIR8.ISA
{
	public sealed class Memory
	{
		public sealed class Stream : System.IO.Stream
		{
			private readonly Memory _memory;
			private long _position;

			public override bool CanRead => true;
			public override bool CanSeek => true;
			public override bool CanWrite => true;
			public override long Length => ushort.MaxValue;

			public override long Position
			{
				get => _position;
				set => _position = CheckAddress(value);
			}

			public Stream(Memory memory)
			{
				_memory = memory;
			}

			public override void Flush()
			{
			}

			public void Next()
			{
				Position = MathExt.Mod(Position + 1, Length);
			}

			public byte Read()
			{
				var value = _memory[Position];
				Next();
				return value;
			}

			public void Write(byte value)
			{
				_memory[Position] = value;
				Next();
			}

			public int Read([NotNull] byte[] buffer)
			{
				return Read(buffer, buffer.Length);
			}

			public int Read([NotNull] byte[] buffer, int count)
			{
				return Read(buffer, 0, count);
			}

			public override int Read([NotNull] byte[] buffer, int offset, int count)
			{
				for (var idx = 0; idx < count; ++idx)
				{
					buffer[idx + offset] = Read();
				}

				return count;
			}

			public void Write([NotNull] byte[] buffer)
			{
				Write(buffer, buffer.Length);
			}

			public void Write([NotNull] byte[] buffer, int count)
			{
				Write(buffer, 0, count);
			}

			public override void Write([NotNull] byte[] buffer, int offset, int count)
			{
				for (var idx = 0; idx < count; ++idx)
				{
					Write(buffer[idx + offset]);
				}
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				long start;

				switch (origin)
				{
					case SeekOrigin.Begin:
						start = 0;
						break;
					case SeekOrigin.Current:
						start = Position;
						break;
					case SeekOrigin.End:
						start = Length;
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(origin), origin, null);
				}

				return Position = MathExt.Mod(start + offset, Length);
			}

			public override void SetLength(long value)
			{
				throw new NotImplementedException();
			}
		}

		public readonly byte[] Contents;
		public ushort ADR { get; private set; }

		public byte this[ushort addr]
		{
			get
			{
				ADR = addr;
				return Contents[addr];
			}
			set
			{
				ADR = addr;
				Contents[addr] = value;
			}
		}

		public byte this[long addr]
		{
			get => this[CheckAddress(addr)];
			set => this[CheckAddress(addr)] = value;
		}

		public Memory()
		{
			Contents = new byte[ushort.MaxValue];
		}

		public System.IO.Stream MakeStream()
		{
			return new Stream(this);
		}

		private static ushort CheckAddress(long addr)
		{
			if ((addr < 0) || (addr > ushort.MaxValue))
			{
				throw new ArgumentOutOfRangeException(nameof(addr), addr, "Address too large");
			}

			return (ushort)addr;
		}
	}
}
