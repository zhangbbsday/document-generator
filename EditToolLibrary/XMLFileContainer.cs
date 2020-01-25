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

        public XMLFileContainer(XDocument document)
        {
            File = document;
            FileState = State.Loading;
        }
    }
}
