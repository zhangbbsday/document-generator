using System;
using System.Collections.Generic;
using System.Text;

namespace XMLHandle
{
    public class XMLDefault
    {
        /// <summary>
        /// XMLMarks 的默认值
        /// </summary>
        public static Dictionary<XMLMarks, string> XMLMarksDefault = new Dictionary<XMLMarks, string>
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
        public static Dictionary<XMLMainMarks, string> XMLMainMarksDefault = new Dictionary<XMLMainMarks, string>
        {
            [XMLMainMarks.NameSpace] = "namespace",
            [XMLMainMarks.Class] = "class",
            [XMLMainMarks.Struct] = "struct",
            [XMLMainMarks.Enum] = "enum",
            [XMLMainMarks.Field] = "field",
            [XMLMainMarks.Property] = "property",
            [XMLMainMarks.Method] = "method"
        };
        public static string XMLDefaultPath = "";
    }
}
