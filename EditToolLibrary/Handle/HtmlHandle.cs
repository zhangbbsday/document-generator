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

        //待补充
        private static void ChangeMain(XDocument document, string path)
        {
            path += "main";
            document.Save(path + DefaultSetting.XmlFileTypeDefault);
        }

        //需要优化
        private static void ChangeMember(XDocument document, string path)
        {
            path += document.Element(DefaultSetting.XmlMarksDefault[XMLMarks.Member])
                            .Attribute("name").Value
                            .RemoveInvalidCharacter();

            document.Save(path + DefaultSetting.XmlFileTypeDefault);
            Change(DefaultSetting.StyleDefaultPath + DefaultSetting.MemberXslFileDefault,
                path + DefaultSetting.XmlFileTypeDefault, path + DefaultSetting.HtmlFileTypeDefault);

            File.Delete(path + DefaultSetting.XmlFileTypeDefault);
        }

        private static void Change(string xslPath, string xmlPath, string htmlPath)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslPath);
            xslt.Transform(xmlPath, htmlPath);
        }
    }
}
