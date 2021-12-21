using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegendsViewer
{
    public static class ExtensionMethods
    {
        public static string ToCsv(this IEnumerable<string> items)
        {
            return items.Any() ? string.Join(",", items) : string.Empty;
        }

        public static string ToSpacedCsv(this IEnumerable<string> items)
        {
            return items.Any() ? string.Join(", ", items) : string.Empty;
        }

        public static string ToSpacedCsvWithOxfordComma(this IEnumerable<string> items)
        {
            return items.ToSpacedCsv().Replace(", " + items.Last(), ", and " + items.Last());
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string s)
        {
            return !s.IsNullOrEmpty();
        }

        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool IsNotNullOrWhiteSpace(this string s)
        {
            return !s.IsNullOrWhiteSpace();
        }

        public static bool EndsWith(this string s, IEnumerable<string> allowedEndings, bool caseInsensitive = true)
        {
            if (caseInsensitive) return allowedEndings.Any(ae => s.EndsWith(ae, StringComparison.InvariantCultureIgnoreCase));
            return allowedEndings.Any(ae => s.EndsWith(ae));
        }

        public static bool EqualsIgnoreCase(this string s, string other)
        {
            return s.Equals(other, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ContainsIgnoreCase(this string s, string other)
        {
            return s.IndexOf(other, StringComparison.InvariantCultureIgnoreCase) > -1;
        }
    }
}
