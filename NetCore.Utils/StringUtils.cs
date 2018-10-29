using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NetCore.Utils
{
    public static class StringUtils
    {
        public static string RemoveCaracteresNaoNumericos(this string texto)
        {
            string replaced = string.Empty;

            if (!string.IsNullOrEmpty(texto))
                replaced = Regex.Replace(texto, "[^0-9]", "");

            return replaced.ToString();
        }
    }
}
