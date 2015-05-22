using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Helpers
{
    public static class APIHelpers
    {
        public static string ConvertToAPIConpliantString(this string _text, char charToParse = ' ', char replacementChar = '-')
        {
            char[] txtarr = _text.ToLower().ToCharArray();
            string text = string.Empty;

            foreach (char c in txtarr)
            {
                if (c == charToParse) { text += replacementChar; }
                else { text += c; }
            }

            return text;
        }
    }
}
