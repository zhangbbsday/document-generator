using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EditToolLibrary
{
    public class XMLFileContainer
    {
        public string Name { get; }
        public string Path { get; }
        public int MemberCount { get; }
        public XMLFileContainer(string path)
        {
            Name = path.GetFileName();
            Path = path;
            MemberCount = XDocument.Load(path).Descendants(DefaultSetting.XmlMarksDefault[XMLMarks.Member]).Count();
        }
    }
}
