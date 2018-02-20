using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using JetBrains.Annotations;

namespace BearLib.Native
{
	internal sealed class WindowsLibrary : LibraryImpl
	{
		private const string Kernel32 = "kernel32.dll";

		public override string Platform => "win";
		public override string Extension => "dll";

		[DllImport(Kernel32, CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern IntPtr LoadLibrary([NotNull] [In] string path);

		[DllImport(Kernel32, SetLastError = true)]
		private static extern bool FreeLibrary(IntPtr handle);

		[DllImport(Kernel32, CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		private static extern IntPtr GetProcAddress(IntPtr handle, [NotNull] [In] string symbol);

		public override IntPtr Open(string path)
		{
			var handle = LoadLibrary(path);
			if (handle == IntPtr.Zero)
			{
				throw new Win32Exception();
			}

			return handle;
		}

		public override void Close(IntPtr handle)
		{
			FreeLibrary(handle);
		}

		public override IntPtr Get(IntPtr handle, string symbol)
		{
			var ptr = GetProcAddress(handle, symbol);
			if (ptr == IntPtr.Zero)
			{
				throw new Win32Exception();
			}

			return ptr;
		}
	}
}
