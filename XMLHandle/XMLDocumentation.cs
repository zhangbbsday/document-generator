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

        /// <summary>
        /// 分割原文档
        /// </summary>
        /// <param name="path">保存路径</param>
        public void Split(string path)
        {
            var members = Document.Descendants(MarksReader[XMLMarks.Member]);
            string nameSpace = StringHandle.AddUnderline(Document.Root.Element(MarksReader[XMLMarks.Assembly]).Element("name").Value);
            XDocument mainDocument = new XDocument(
                new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.NameSpace], 
                new XAttribute("name", nameSpace)));

            XElement xElement = mainDocument.Root;
            string dataPath = path + nameSpace + @"\";

            foreach (var member in members)
            {
                xElement = AddMainElement(mainDocument.Root, xElement, member.Attribute("name").Value);
                Save(new XDocument(member), dataPath);   
            }
            Save(mainDocument, path, true);
        }

        /// <summary>
        /// 保存分割后的文档
        /// </summary>
        /// <param name="xDocument">XML 文档</param>
        /// <param name="path">保存路径</param>
        private void Save(XDocument xDocument, string path, bool isMain = false)
        {
            string name = !isMain ? xDocument.Element(MarksReader[XMLMarks.Member]).Attribute("name").Value : 
                xDocument.Root.Attribute("name").Value;

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
            bool isParent = false;
            memberName = StringHandle.RemoveInvalidCharacter(memberName);
            switch (Enum.Parse(typeof(XMLMemberType), memberName[0].ToString()))
            {
                case XMLMemberType.T:
                    add = new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.Class],
                        new XAttribute("name", memberName));
                    isParent = true;
                    break;
                case XMLMemberType.P:
                    add = new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.Property],
                        new XAttribute("name", memberName));
                    break;
                case XMLMemberType.F:
                    add = new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.Field],
                        new XAttribute("name", memberName));
                    break;
                case XMLMemberType.M:
                    add = new XElement(XMLDefault.XMLMainMarksDefault[XMLMainMarks.Method],
                            new XAttribute("name", memberName));
                    break;
                default:
                    add = new XElement("Null");
                    break;
            }
            if (isParent)
                root.Add(add);
            else
                xElement.Add(add);

            if (isParent)
                return add;
            return xElement;
        }
    }
}
