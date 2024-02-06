using SeptaKit.Extensions;
using SeptaKit.Persian;
using System;
using System.Linq;

namespace AbrPlus.Integration.OpenERP.Helpers
{
    public static class StringHelper
    {
        public static bool IsBiggerVersion(this string ver1, string ver2)
        {
            if (!ver1.StartsWith("V"))
            {
                throw new ArgumentOutOfRangeException($"{ver1} is not a valid version string");
            }
            if (!ver2.StartsWith("V"))
            {
                throw new ArgumentOutOfRangeException($"{ver2} is not a valid version string");
            }

            var vers1 = ver1.Substring(1).Split('_').Select(p => p.ToInt().Value).ToList();
            var vers2 = ver2.Substring(1).Split('_').Select(p => p.ToInt().Value).ToList();

            for (int i = 0; i < vers1.Count; i++)
            {
                if (i >= vers2.Count)
                {
                    if (vers1[i] != 0)
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (vers1[i] == vers2[i])
                {
                    continue;
                }
                else if (vers1[i] > vers2[i])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
