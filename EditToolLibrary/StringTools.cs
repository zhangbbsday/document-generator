using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EditToolLibrary
{
    public static class StringTools
    {
        public static string GetFileName(this string path)
        {
            return System.IO.Path.GetFileName(path);
        }

        public static string GetExtensionName(this string path)
        {
            return System.IO.Path.GetExtension(path);
        }

        public static string RemoveInvalidCharacter(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str), "字符串为空!");

            StringBuilder stringBuilder = new StringBuilder();
            var invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars().ToList();
            foreach (var c in str)
            {
                if (!invalidFileNameChars.Contains(c))
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }

        public static string AddUnderline(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str), "字符串为空!");

            StringBuilder stringBuilder = new StringBuilder();
            if (char.IsDigit(str[0]))
                stringBuilder.Append('_');

            foreach (var c in str)
            {
                if (c == ' ')
                    stringBuilder.Append('_');
                else
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        public static string GetMeaningfulString(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str), "字符串为空!");

            string result = str.Substring(1);
            return Regex.Replace(result, @"\.#ctor", "");
        }
    }
}
