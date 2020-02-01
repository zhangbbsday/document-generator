using System;
using System.Collections.Generic;
using System.Text;

namespace EditToolLibrary
{
    public static class DefaultSetting
    {
        public static Dictionary<XMLMarks, string> XmlMarksDefault { get; } = new Dictionary<XMLMarks, string>
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
        public static Dictionary<XMLNavigationMarks, string> XmlNavigationMarksDefault { get; } = new Dictionary<XMLNavigationMarks, string>
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
        public static string HtmlFileTypeDefault { get; } = ".html";
        public static string XmlFileTypeDefault { get; } = ".xml";
        public static string OpenFileTypeFilterDefault { get; } = "XML文档|*.xml";
        public static string SaveFileTypeFilterDefault { get; } = "zip文件|*.zip";
        public static string HtmlDefaultPath { get; } = System.IO.Directory.GetCurrentDirectory() + @"\data\html\";
        public static string StyleDefaultPath { get; } = System.IO.Directory.GetCurrentDirectory() + @"\data\style\";
        public static string MemberXslFileDefault { get; } = "member.xsl";
        public static string MainXslFileDefault { get; } = "main.xsl";
    }
}
