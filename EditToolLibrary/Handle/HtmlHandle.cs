using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml.Xsl;
using System.Xml;

namespace EditToolLibrary
{
    public static class HtmlHandle
    {
        public enum FileType
        {
            MemberFile,
            MainFile
        }

        public static void ChangeToHtml(XDocument document, FileType fileType)
        {
            string path = DefaultSetting.HtmlDefaultPath;
            switch (fileType)
            {
                case FileType.MainFile:
                    ChangeMain(document, path);
                    break;
                case FileType.MemberFile:
                    ChangeMember(document, path);
                    break;
            }
        }

        private static void ChangeMain(XDocument document, string path)
        {
            string pathNew = path + "navigation";
            path += "main";

            SaveXml(document, path + DefaultSetting.XmlFileTypeDefault);
            Change(DefaultSetting.StyleDefaultPath + DefaultSetting.MainXslFileDefault,
                path + DefaultSetting.XmlFileTypeDefault, path + DefaultSetting.HtmlFileTypeDefault);
            Change(DefaultSetting.StyleDefaultPath + DefaultSetting.NavigationXslFileDefault,
                path + DefaultSetting.XmlFileTypeDefault, pathNew + DefaultSetting.HtmlFileTypeDefault);

            File.Delete(path + DefaultSetting.XmlFileTypeDefault);
        }

        private static void ChangeMember(XDocument document, string path)
        {
            path += document.Element(DefaultSetting.XmlMarksDefault[XMLMarks.Member])
                            .Attribute("name").Value
                            .RemoveInvalidCharacter();

            SaveXml(document, path + DefaultSetting.XmlFileTypeDefault);
            Change(DefaultSetting.StyleDefaultPath + DefaultSetting.MemberXslFileDefault,
                path + DefaultSetting.XmlFileTypeDefault, path + DefaultSetting.HtmlFileTypeDefault);

            File.Delete(path + DefaultSetting.XmlFileTypeDefault);
        }

        private static void SaveXml(XDocument document, string path)
        {
            document.Save(path);
        }
        private static void Change(string xslPath, string xmlPath, string htmlPath)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslPath);
            xslt.Transform(xmlPath, htmlPath);
        }
    }
}
