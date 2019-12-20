using System;
using XMLHandle;

namespace XMLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLDocumentation documentation = new XMLDocumentation(XMLDefault.XMLMarksDefault);
            documentation.Open(@"D:\xml\XML注释生成.xml");
            documentation.Split(@"D:\xml\data\");

            Console.WriteLine("分割完成!");
            Console.ReadKey();
        }
    }
}
