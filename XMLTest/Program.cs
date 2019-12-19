using System;
using XMLHandle;

namespace XMLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLDocumentation documentation = new XMLDocumentation(XMLDefault.XMLMarksDefault);
            documentation.Open(@"D:\XML注释生成.xml");
            documentation.Split(@"D:\xml\");

            Console.WriteLine("分割完成!");
            Console.ReadKey();
        }
    }
}
