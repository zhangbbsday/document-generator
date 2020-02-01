using System;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace EditToolLibrary
{
    public static class ZipFileHandle
    {  
        public static void ExtractFiles(string from)
        {
            if (string.IsNullOrEmpty(from))
                throw new NullReferenceException("字符串为空!");

            ZipFile.ExtractToDirectory(from, DefaultSetting.HtmlDefaultPath);
        }

        public static void SaveFile(string to)
        {
            if (string.IsNullOrEmpty(to))
                throw new NullReferenceException("字符串为空!");

            if (File.Exists(to))
                File.Delete(to);
            ZipFile.CreateFromDirectory(DefaultSetting.HtmlDefaultPath, to);
        }
    }
}
