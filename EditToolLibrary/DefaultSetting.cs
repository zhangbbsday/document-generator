using System;
using System.Collections.Generic;
using System.Text;

namespace EditToolLibrary
{
    public static class DefaultSetting
    {
        public static Dictionary<XMLMarks, string> XMLMarksDefault { get; } = new Dictionary<XMLMarks, string>
        {
            [XMLMarks.Assembly] = "assembly",
            [XMLMarks.Member] = "member",
            [XMLMarks.Summary] = "summary",
            [XMLMarks.Param] = "param",
            [XMLMarks.Returns] = "returns",
            [XMLMarks.ReMarks] = "remarks",
            [XMLMarks.Value] = "value",
            [XMLMarks.See] = "see",
            [XMLMarks.SeeAlso] = "seealso",
            [XMLMarks.Para] = "para",
            [XMLMarks.Example] = "example",
            [XMLMarks.Code] = "code",
            [XMLMarks.C] = "c",
            [XMLMarks.Exception] = "exception",
            [XMLMarks.Typeparam] = "typeparam",
            [XMLMarks.List] = "list",
            [XMLMarks.Term] = "term",
            [XMLMarks.Description] = "description",
        };
        public static Dictionary<XMLNavigationMarks, string> XMLNavigationMarksDefault { get; } = new Dictionary<XMLNavigationMarks, string>
        {
            [XMLNavigationMarks.NameSpace] = "namespace",
            [XMLNavigationMarks.DefaultClass] = "defaultclass",
            [XMLNavigationMarks.Class] = "class",
            [XMLNavigationMarks.Struct] = "struct",
            [XMLNavigationMarks.Enum] = "enum",
            [XMLNavigationMarks.Field] = "field",
            [XMLNavigationMarks.Property] = "property",
            [XMLNavigationMarks.Method] = "method"
        };
        public static string FileTypeDefault { get; } = ".dal";
        public static string FileTypeFilterDefault { get; } = "文档列表|*.dal|XML文档|*.xml";

    }
}
