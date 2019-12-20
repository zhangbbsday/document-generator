using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XMLHandle
{
    public static class StringHandle
    {
        /// <summary>
        /// 去除字符串中对于文件名、路径的无效字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string RemoveInvalidCharacter(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str), "字符串为空!");

            StringBuilder stringBuilder = new StringBuilder();
            var invalidFileNameChars = Path.GetInvalidFileNameChars();
            foreach (var c in str)
            {
                if (!invalidFileNameChars.Contains(c))
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 将字符串中的空白替换为下划线，若以数字开头，在开头添加下划线
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>处理后的字符串</returns>
        public static string AddUnderline(string str)
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
    }
}
