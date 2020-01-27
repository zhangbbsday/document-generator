using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace EditToolLibrary
{
    public static class XMLHandle
    {
        public static void Produce(IList files)
        {
            foreach (XMLFileContainer file in files)
            {
                Split(file);
            }
        }

        private static void Split(XMLFileContainer file)
        {
            if (file.File == null)
                throw new IOException("文件读取错误!");

            XDocument document = file.File;
            var members = document.Descendants(DefaultSetting.XMLMarksDefault[XMLMarks.Member]);
            string nameSpace = document.Root
                            .Element(DefaultSetting.XMLMarksDefault[XMLMarks.Assembly])
                            .Element("name").Value
                            .AddUnderline();

            XDocument mainDocument = CreateMainFile(nameSpace);
            XElement nameSpaceRoot = mainDocument.Root
                                    .Element(DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.NameSpace]);
            XElement xElement = nameSpaceRoot;
            foreach (var member in members)
            {
                xElement = AddMainElement(nameSpaceRoot, xElement, member.Attribute("name").Value);
                ChangeToHtml(new XDocument(member));
            }
            ChangeToHtml(mainDocument, HtmlHandle.FileType.MainFile);
        }

        private static XDocument CreateMainFile(string nameSpace)
        {
            return new XDocument(new XElement("Root",
                new XElement(DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.NameSpace],
                new XAttribute("name", nameSpace))));
        }

        private static XElement AddMainElement(XElement root, XElement xElement, string memberName)
        {
            XElement add;
            char type = memberName[0];
            memberName = memberName.RemoveInvalidCharacter();
            string trueMemberName = memberName.Substring(1);

            switch (type)
            {
                case 'T':
                    add = new XElement(DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.Class],
                        new XAttribute("name", memberName));
                    break;
                case 'P':
                    add = new XElement(DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.Property],
                        new XAttribute("name", memberName));
                    break;
                case 'F':
                    add = new XElement(DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.Field],
                        new XAttribute("name", memberName));
                    break;
                case 'M':
                    add = new XElement(DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.Method],
                        new XAttribute("name", memberName));
                    break;
                default:
                    add = new XElement("Null");
                    break;
            }

            while (xElement.Parent != root.Parent)
            {
                if (trueMemberName.StartsWith(xElement.Attribute("name").Value.Substring(1)))
                    break;
                xElement = xElement.Parent;
            }

            if (type != 'T' && xElement.Name == DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.NameSpace])
            {
                if (root.Element(DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.DefaultClass]) == null)
                    root.Add(new XElement(DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.DefaultClass], new XAttribute("name", "Null")));

                xElement = root.Element(DefaultSetting.XMLNavigationMarksDefault[XMLNavigationMarks.DefaultClass]);
            }

            xElement.Add(add);
            return add;
        }

        private static void ChangeToHtml(XDocument xDocument, HtmlHandle.FileType fileType = HtmlHandle.FileType.MemberFile)
        {
            HtmlHandle.ChangeToHtml(xDocument, fileType);
        }
    }
}
