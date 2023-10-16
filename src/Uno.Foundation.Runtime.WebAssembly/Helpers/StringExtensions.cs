﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Uno.Foundation.Runtime.WebAssembly.Helpers
{
	internal static partial class StringExtensions
	{
		private static readonly Lazy<Regex> _newLineRegex = new Lazy<Regex>(() => NewLineFast());

		public static string Indent(this string text, int indentCount = 1)
		{
			return _newLineRegex.Value.Replace(text, new string('\t', indentCount));
		}

		public static string JoinBy(this IEnumerable<string> items, string joinBy)
		{
			return string.Join(joinBy, items.ToArray());
		}

		public static bool HasValue(this string instance)
		{
			return !string.IsNullOrWhiteSpace(instance);
		}

		public static bool HasValueTrimmed(this string instance)
		{
			return !string.IsNullOrWhiteSpace(instance);
		}

		[GeneratedRegex("^", RegexOptions.Multiline)]
		private static partial Regex NewLineFast();
	}
}
