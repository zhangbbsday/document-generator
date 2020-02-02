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
        public XDocument File { get; }

        public XMLFileContainer(string path)
        {
            File = XDocument.Load(path);

            Name = path.GetFileName();
            Path = path;
            MemberCount = File.Descendants(DefaultSetting.XmlMarksDefault[XMLMarks.Member]).Count();
        }
    }
}
