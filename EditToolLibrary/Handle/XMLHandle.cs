﻿using System.Collections;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace EditToolLibrary
{
    public static class XMLHandle
    {
        public static void Produce(IList files)
        {
            ClearDirectory();
            XDocument main = CreateMainFile();
            foreach (XMLFileContainer file in files)
            { 
                Split(file, main);
            }
            ChangeToHtml(main, HtmlHandle.FileType.MainFile);
        }
        //需要优化
        private static void Split(XMLFileContainer file, XDocument main)
        {
            if (!File.Exists(file.Path))
                throw new IOException("文件读取错误!");

            XDocument document = XDocument.Load(file.Path);
            var members = document.Descendants(DefaultSetting.XmlMarksDefault[XMLMarks.Member]);
            string nameSpace = document.Root
                            .Element(DefaultSetting.XmlMarksDefault[XMLMarks.Assembly])
                            .Element("name").Value
                            .AddUnderline();
            AddNameSpace(main, nameSpace);

            XElement nameSpaceRoot = main.Root
                                 .Elements(DefaultSetting.XmlNavigationMarksDefault[XMLNavigationMarks.NameSpace])
                                 .Last();

            XElement xElement = nameSpaceRoot;
            foreach (var member in members)
            {
                string name = member.Attribute("name").Value.RemoveInvalidCharacter();
                member.SetAttributeValue("name", name.GetMeaningfulString());
                xElement = AddMainElement(nameSpaceRoot, xElement, name);
                ChangeToHtml(new XDocument(member));
            }
        }
        private static XDocument CreateMainFile()
        {
            return new XDocument(new XElement("Root"));
        }
        private static void AddNameSpace(XDocument document, string nameSpace)
        {
            document.Root.Add(new XElement(DefaultSetting.XmlNavigationMarksDefault[XMLNavigationMarks.NameSpace],
                        new XAttribute("name", nameSpace)));
        }
        private static XElement AddMainElement(XElement root, XElement xElement, string memberName)
        {
            XElement add;
            char type = memberName[0];
            string trueMemberName = memberName.GetMeaningfulString();
            add = new XElement(DefaultSetting.XmlNavigationMarksDefault[DefaultSetting.NavigationCharsDefault[type]],
                        new XAttribute("name", trueMemberName));

            while (xElement.Parent != root.Parent)
            {
                if (trueMemberName.StartsWith(xElement.Attribute("name").Value))
                    break;
                xElement = xElement.Parent;
            }

            if (type != 'T' && xElement.Name == DefaultSetting.XmlNavigationMarksDefault[XMLNavigationMarks.NameSpace])
            {
                if (root.Element(DefaultSetting.XmlNavigationMarksDefault[XMLNavigationMarks.DefaultClass]) == null)
                    root.Add(new XElement(DefaultSetting.XmlNavigationMarksDefault[XMLNavigationMarks.DefaultClass], new XAttribute("name", "Null")));

                xElement = root.Element(DefaultSetting.XmlNavigationMarksDefault[XMLNavigationMarks.DefaultClass]);
            }

            xElement.Add(add);
            return add;
        }
        private static void ChangeToHtml(XDocument xDocument, HtmlHandle.FileType fileType = HtmlHandle.FileType.MemberFile)
        {
            HtmlHandle.ChangeToHtml(xDocument, fileType);
        }
        private static void ClearDirectory()
        {
            string path = DefaultSetting.HtmlDefaultPath;
            if (Directory.Exists(path))
                Directory.Delete(path, true);
            Directory.CreateDirectory(path);
        }
    }
}
