using System;
using System.Globalization;

namespace AbrPlus.Integration.OpenERP.Helpers
{
    /// <summary>
    /// <para>The main <c>Logger</c> class.</para>
    /// <para>
    /// Converts Persian date to Gregorian date Or vice versa.
    /// Gets Persian year from gregorian date and etc.
    /// </para>
    /// </summary>
    /// <list type="bullet">
    /// <item>
    /// <term>ToGregorianDate</term>
    /// <description>Converts Persian Date to Gregorian date.</description>
    /// </item>
    /// <item>
    /// <term>ToPersianDate</term>
    /// <description>Converts Gregorian Date to Persian date.</description>
    /// </item>
    /// <item>
    /// <term>GetPersianYearStartAndEnd</term>
    /// <description>Gets Persian's year number and return the first and the last time of year.</description>
    /// </item>
    /// <item>
    /// <term>GetPersianYearFromGregorianDate</term>
    /// <description>Gets gregorian date and returns persian year.</description>
    /// </item>
    /// </list>
    public static class PersianHelper
    {
        /// <summary>
        /// Gets Persian's year number and return the first and the last time of year.
        /// </summary>
        /// <param name="persianYear"></param>
        /// <returns></returns>
        public static Tuple<DateTime, DateTime> GetPersianYearStartAndEnd(int persianYear)
        {
            var cal = new PersianCalendar();
            var startDate = cal.ToDateTime(persianYear, 1, 1, 0, 0, 0, 0);
            var endDate = startDate.AddYears(1).AddMilliseconds(-1);
            return new Tuple<DateTime, DateTime>(startDate, endDate);
        }

        public static string ArabizeYeKe(this string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return string.Empty;
            }

            char[] array = data.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                switch (array[i])
                {
                    case 'ؠ':
                    case 'ؽ':
                    case 'ؾ':
                    case 'ؿ':
                    case 'ى':
                    case 'ٸ':
                    case 'ۍ':
                    case 'ێ':
                    case 'ې':
                    case 'ۑ':
                    case 'ی':
                        array[i] = 'ي';
                        break;
                    case 'ک':
                        array[i] = 'ك';
                        break;
                }
            }

            return new string(array);
        }
    }
}
