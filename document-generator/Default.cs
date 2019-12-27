using System;
using System.Collections.Generic;
using System.Text;

namespace document_generator
{
    static class Default
    {
        public static string PathDefault { get; } = System.IO.Directory.GetCurrentDirectory() + @"\";
        public static string DataPathDefault { get; } = PathDefault + @"data\";
        public static string[] DirectoryDefault { get; } =
        {
            @"doc\",
            @"xls\",
            @"config\"
        };
    }
}
