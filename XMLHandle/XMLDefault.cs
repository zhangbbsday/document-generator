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

        public static string XMLDefaultPath = "";
    }
}
