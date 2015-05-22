using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeTrackingServiceWrapper.Helpers
{
    public class APIHelpers
    {
        public static string ConvertToAPIConpliantString(string _text, char charToParse = ' ', char replacementChar = '-')
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
