using System;
using System.Collections.Generic;
using System.Linq;

namespace PIR8.ISA.Utils
{
	public static class EnumExt
	{
		public static IEnumerable<TEnum> GetValues<TEnum>()
			where TEnum : struct
		{
			return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
		}

		public static bool IsDefined<TEnum>(TEnum value)
			where TEnum : struct
		{
			return Enum.IsDefined(typeof(TEnum), value);
		}
	}
}
