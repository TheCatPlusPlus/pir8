using System.Text;

using JetBrains.Annotations;

namespace PIR8.ISA.Utils
{
	public static class ObjectExt
	{
		public static string ToFormattedString([CanBeNull] this object item)
		{
			return new ObjectFormatter(item).ToString();
		}

		public static void ToFormattedString([CanBeNull] this object item, [NotNull] StringBuilder builder)
		{
			new ObjectFormatter(item).Format(builder);
		}
	}
}
