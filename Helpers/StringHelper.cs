using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RupaHealth.Helpers
{
    public static class StringHelper
    {
        public static string ConvertHTMLStringToPlainText(string htmlContent)
        {
            string str = htmlContent.Replace("&nbsp;", string.Empty);
            str = Regex.Replace(str, "<.*?>", String.Empty);

            return str;
        }
    }
}
