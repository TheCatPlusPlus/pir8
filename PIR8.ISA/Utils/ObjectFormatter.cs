using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using JetBrains.Annotations;

namespace PIR8.ISA.Utils
{
	public sealed class ObjectFormatter
	{
		[CanBeNull]
		private readonly object _item;
		[CanBeNull]
		private readonly System.Reflection.Assembly _assembly;
		private readonly char _indentChar;
		private readonly int _indentMultiplier;

		private struct Member
		{
			[NotNull]
			public readonly string Name;
			[CanBeNull]
			public readonly object Value;

			public Member([NotNull] object item, [NotNull] FieldInfo field)
			{
				Name = field.Name;
				Value = field.GetValue(item);
			}

			public Member([NotNull] object item, [NotNull] PropertyInfo prop)
			{
				Name = prop.Name;
				Value = prop.GetValue(item, null);
			}
		}

		public ObjectFormatter(
			[CanBeNull] object item, [CanBeNull] System.Reflection.Assembly assembly = null, char indentChar = '\t',
			int indentMultiplier = 1)
		{
			_assembly = assembly ?? item?.GetType().Assembly;
			_item = item;
			_indentChar = indentChar;
			_indentMultiplier = indentMultiplier;
		}

		private string GetIndent(int size)
		{
			return size > 0 ? new string(_indentChar, _indentMultiplier * size) : "";
		}

		[NotNull]
		public override string ToString()
		{
			var builder = new StringBuilder();
			Format(builder);
			return builder.ToString();
		}

		public void Format([NotNull] StringBuilder builder)
		{
			Format(_item, builder, 0);
			builder.AppendLine();
		}

		private void Format([CanBeNull] object item, [NotNull] StringBuilder builder, int indentSize)
		{
			var indent = GetIndent(indentSize);
			var nestedIndent = GetIndent(indentSize + 1);

			if (item == null)
			{
				builder.Append("<null>");
				return;
			}

			var type = item.GetType();

			if (item is IList list)
			{
				string typeStr;

				if (type.IsArray)
				{
					typeStr = $"{type.GetElementType()?.Name}[]";
				}
				else if (IsIList(type))
				{
					typeStr = $"IList<{type.GetGenericArguments()[0].Name}>";
				}
				else
				{
					typeStr = list.GetType().Name;
				}

				builder.AppendLine($"{typeStr} ({list.Count} items)");
				builder.AppendLine($"{indent}[");

				for (var idx = 0; idx < list.Count; idx++)
				{
					builder.Append($"{nestedIndent}#{idx}: ");
					Format(list[idx], builder, indentSize + 1);
					builder.AppendLine();
				}

				builder.Append($"{indent}]");
			}
			else if (item is IDictionary dict)
			{
				string typeStr;

				if (IsIDictionary(type))
				{
					var genArgs = type.GetGenericArguments();
					typeStr = $"IDictionary<{genArgs[0].Name}, {genArgs[1].Name}>";
				}
				else
				{
					typeStr = dict.GetType().Name;
				}

				builder.AppendLine($"{typeStr} ({dict.Count} items)");
				builder.AppendLine($"{indent}{{");

				foreach (DictionaryEntry pair in dict)
				{
					builder.Append($"{nestedIndent}{pair.Key} = ");
					Format(pair.Value, builder, indentSize + 1);
					builder.AppendLine();
				}

				builder.AppendLine($"{indent}}}");
			}
			else if (IsInteresting(type) && !type.IsEnum)
			{
				var fields = type
					.GetFields(BindingFlags.Instance | BindingFlags.Public)
					.Select(field => new Member(item, field));
				var props = type
					.GetProperties(BindingFlags.Instance | BindingFlags.Public)
					.Select(prop => new Member(item, prop));
				var members = fields.Union(props);

				builder.AppendLine($"{type.Name}");
				builder.AppendLine($"{indent}{{");

				foreach (var member in members)
				{
					builder.Append($"{nestedIndent}{member.Name} = ");
					Format(member.Value, builder, indentSize + 1);
					builder.AppendLine();
				}

				builder.Append($"{indent}}}");
			}
			else
			{
				builder.Append(item);
			}
		}

		private static bool HasGenericInterface(Type type, Type definition)
		{
			return type.IsGenericType && type.GetInterfaces()
				.Where(i => i.IsGenericType)
				.Select(i => i.GetGenericTypeDefinition())
				.Contains(definition);
		}

		private static bool IsIDictionary(Type type)
		{
			return HasGenericInterface(type, typeof(IDictionary<,>));
		}

		private static bool IsIList(Type type)
		{
			return HasGenericInterface(type, typeof(IList<>));
		}

		private bool IsInteresting(Type type)
		{
			return type.Assembly == _assembly;
		}
	}
}
