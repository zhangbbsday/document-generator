using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace XMLHandle
{
    /// <summary>
    /// 用于打开、分割原始XML文件
    /// </summary>
    public class XMLDocumentation
    {
       
        private XDocument Document { get; set; }
        private Dictionary<XMLMarks, string> MarksReader { get; }


        public XMLDocumentation(Dictionary<XMLMarks, string> marks)
        {
            if (marks == null)
                throw new NullReferenceException("数据不能为空!");

            MarksReader = marks;
        }

        public void Open(string path)
        {
            try
            {
                using (var file = File.OpenRead(path))
                {
                    Document = XDocument.Load(file, LoadOptions.None);
                }
            }
            catch (IOException)
            {
                throw new IOException("读取 XML 文件出错!");
            }
        }

        public void Split(string path)
        {
            var members = Document.Descendants(MarksReader[XMLMarks.Member]);

            foreach (var member in members)
            {
                Save(new XDocument(member), path);
            }
        }

        private void Save(XDocument xDocument, string path)
        {
            string name = xDocument.Element(MarksReader[XMLMarks.Member]).Attribute("name").Value;
            StringBuilder stringBuilder = new StringBuilder();
            var invalidFileNameChars = Path.GetInvalidFileNameChars();

            foreach (var c in name)
            {
                if (!invalidFileNameChars.Contains(c))
                {
                    stringBuilder.Append(c);
                }
            }

            xDocument.Save(path + stringBuilder.ToString() + ".xml");
        }
    }
}
