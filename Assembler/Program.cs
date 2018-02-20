using System;
using System.IO;
using System.Reflection;
using System.Text;

using JetBrains.Annotations;

namespace Assembler
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var me = Path.GetFileName(Assembly.GetExecutingAssembly().Location);

			if (args.Length < 2)
			{
				Console.WriteLine($"Usage: {me} input.asm output.bin [symbols.dbg]");
				Environment.Exit(1);
			}

			var input = args[0];
			var output = args[1];
			var symbols = args.Length > 2 ? args[2] : "";

			using (var inStream = new FileStream(input, FileMode.Open, FileAccess.Read, FileShare.Read))
			using (var outStream = new FileStream(output, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
			{
				if (!string.IsNullOrEmpty(symbols))
				{
					using (var dbgStream = new FileStream(symbols, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
					{
						Assemble(inStream, outStream, dbgStream);
					}
				}
				else
				{
					Assemble(inStream, outStream);
				}
			}
		}

		private static void Assemble(Stream inStream, Stream outStream, [CanBeNull] Stream dbgStream = null)
		{
			var input = new StreamReader(inStream, Encoding.UTF8);
			var output = new BinaryWriter(outStream, Encoding.ASCII);
			var debug = new BinaryWriter(dbgStream, Encoding.UTF8);


		}
	}
}
