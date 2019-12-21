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
    public class XMLDocumentationHandle
    {
        private XDocument Document { get; set; }
        private Dictionary<XMLMarks, string> MarksReader { get; }


        public XMLDocumentationHandle(Dictionary<XMLMarks, string> marks)
        {
            if (marks == null)
                throw new NullReferenceException("数据不能为空!");

            MarksReader = marks;
        }

        /// <summary>
        /// 打开一个 XML 文档
        /// </summary>
        /// <param name="path">XML 文档路径</param>
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

        /// <summary>
        /// 分割原文档
        /// </summary>
        /// <param name="path">保存路径</param>
        public void Split(string path)
        {
            try
            {
                var members = Document.Descendants(MarksReader[XMLMarks.Member]);
                string nameSpace = StringHandle.AddUnderline(Document.Root.Element(MarksReader[XMLMarks.Assembly]).Element("name").Value);
                XDocument mainDocument = new XDocument(
                    new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.NameSpace],
                    new XAttribute("name", nameSpace)));

                XElement xElement = mainDocument.Root;
                string dataPath = path + @"data\" + nameSpace + @"\";

                foreach (var member in members)
                {
                    xElement = AddMainElement(mainDocument.Root, xElement, member.Attribute("name").Value);
                    Save(new XDocument(member), dataPath);
                }
                Save(mainDocument, path + @"data\", true);
            }
            catch (Exception)
            {
                throw new Exception("XML 文件标记无法识别!");
            }
        }

        /// <summary>
        /// 保存分割后的文档
        /// </summary>
        /// <param name="xDocument">XML 文档</param>
        /// <param name="path">保存路径</param>
        private void Save(XDocument xDocument, string path, bool isMain = false)
        {
            string name = !isMain ? xDocument.Element(MarksReader[XMLMarks.Member]).Attribute("name").Value : 
                XMLDefault.MainXMLName;

            name = StringHandle.RemoveInvalidCharacter(name);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            xDocument.Save(path + name + ".xml");
        }

        /// <summary>
        /// 生成主 XML 文档
        /// </summary>
        /// <param name="root">根节点</param>
        /// <param name="xElement">父节点</param>
        /// <param name="memberName">子节点名称</param>
        /// <returns></returns>
        private XElement AddMainElement(XElement root, XElement xElement, string memberName)
        {
            XElement add;
            char type = memberName[0];
            memberName = StringHandle.RemoveInvalidCharacter(memberName);
            string trueMemberName = memberName.Substring(1);

            switch (type)
            {
                case 'T':
                    add = new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.Class],
                        new XAttribute("name", memberName));
                    break;
                case 'P':
                    add = new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.Property],
                        new XAttribute("name", memberName));
                    break;
                case 'F':
                    add = new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.Field],
                        new XAttribute("name", memberName));
                    break;
                case 'M':
                    add = new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.Method],
                        new XAttribute("name", memberName));
                    break;
                default:
                    add = new XElement("Null");
                    break;
            }

            while (xElement.Parent != null)
            {
                if (trueMemberName.StartsWith(xElement.Attribute("name").Value.Substring(1)))
                    break;
                xElement = xElement.Parent;
            }

            if (type != 'T' && xElement.Name == XMLDefault.XMLMainMarksDefault[XMLMainMarks.NameSpace])
            {
                if (root.Element(XMLDefault.XMLMainMarksDefault[XMLMainMarks.DefaultClass]) == null)
                    root.Add(new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.DefaultClass], new XAttribute("name", "Null")));

                xElement = root.Element(XMLDefault.XMLMainMarksDefault[XMLMainMarks.DefaultClass]);
            }
                
            xElement.Add(add);
            return add;
        }
    }
}
