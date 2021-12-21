using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegendsViewer
{
    public static class ExtensionMethods
    {
        public static string ToSpacedCsv(this List<string> items)
        {
            return items.Any() ? string.Join(", ", items) : string.Empty;
        }

        public static string ToSpacedCsvWithOxfordComma(this List<string> items)
        {
            return items.ToSpacedCsv().Replace(", " + items.Last(), ", and " + items.Last());
        }
    }
}
