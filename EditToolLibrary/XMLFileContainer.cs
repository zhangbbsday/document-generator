using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace EditToolLibrary
{
    public class XMLFileContainer
    {
        public enum State
        {
            Loading,
            Ready,
            Spliting
        }

        public string Name { get; }
        public string Path { get; }
        public int MemberCount { get; }
        public State FileState { get; set; }
        private XDocument File { get; }

        public XMLFileContainer(string path)
        {
            File = XDocument.Load(path);

            Name = path.GetFileName();
            Path = path;
            MemberCount = 0;
            FileState = State.Loading;
        }
    }
}
