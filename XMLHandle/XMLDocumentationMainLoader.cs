using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace XMLHandle
{
    public static class XMLDocumentationMainLoader
    {
        private static XDocument mainDocument;
        public static XDocument MainDocument
        {
            get
            {
                if (mainDocument == null)
                    throw new NullReferenceException("为空值!");
                return mainDocument;
            }
            private set
            {
                mainDocument = value;
            }
        }

        public static void OpenMain(string path)
        {
            try
            {
                MainDocument = XDocument.Load(path);
            }
            catch (Exception)
            {
                throw new Exception("读取.xmlmain文件失败!");
            }
        }

        public static IEnumerable<XElement> FindElements(XElement root)
        {
            var element = from item in root.Elements()
                          select item;

            return element;
        }
    }
}
