using System;
using System.Collections.Generic;
using System.Linq;
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

        public static string AddSpacesToSentence(this string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        public static double SimilarTo(this string string1, string string2)
        {
            string[] splitString1 = string1.Split(' ');
            string[] splitString2 = string2.Split(' ');
            var strCommon = splitString1.Intersect(splitString2);
            //Formula : Similarity (%) = 100 * (CommonItems * 2) / (Length of String1 + Length of String2)
            double Similarity = (double)(100 * (strCommon.Count() * 2)) / (splitString1.Length + splitString2.Length);
            return Similarity;
        }
    }
}
