using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelForm
{
    internal class Helpers
    {
        public static bool validDate(string dateString, string format)
        {
            return DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        public static DateTime convertToDateTime(string dateString, string format = "dd.MM.yyyy")
        {
            if (validDate(dateString, format))
                return DateTime.ParseExact(dateString, format, null);
            throw new Exception("Invalid date format");
        }
    }
}
