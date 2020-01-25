using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
