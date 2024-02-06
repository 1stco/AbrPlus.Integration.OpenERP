using System.Collections.Generic;
using System.Linq;

namespace AbrPlus.Integration.OpenERP.Helpers
{
    public static class ExtendedPropertyHelper
    {
        public static string GetAsListStringExtendedProperty(this IEnumerable<string> values)
        {
            return System.Text.Json.JsonSerializer.Serialize(values.Select(p => new StringExtendedPropertyTuple() { Value = p }));
        }
    }

    internal class StringExtendedPropertyTuple
    {
        public string Value { get; set; }
    }
}
