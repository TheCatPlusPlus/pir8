using System;

namespace BearLib.Native
{
	internal sealed class LinuxLibrary : LibraryImpl
	{
		public override string Platform => "linux";
		public override string Extension => "so";

		public override IntPtr Open(string path)
		{
			throw new NotImplementedException();
		}

		public override void Close(IntPtr handle)
		{
			throw new NotImplementedException();
		}

		public override IntPtr Get(IntPtr handle, string symbol)
		{
			throw new NotImplementedException();
		}
	}
}
