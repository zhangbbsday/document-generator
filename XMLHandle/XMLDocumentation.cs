﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace XMLHandle
{
    /// <summary>
    /// 用于打开、分割原始XML文件
    /// </summary>
    class XMLDocumentation
    {
        private XDocument Document { get; set; }
        private Dictionary<XMLMarks, string> MarksReader { get; }
        

        public XMLDocumentation(Dictionary<XMLMarks, string> marks)
        {
            if (marks == null)
                throw new NullReferenceException("数据不能为空!");

            MarksReader = marks;
        }

        public async void Open(string path)
        {
            try
            {
                using (var file = File.OpenRead(path))
                {
                    Document = await XDocument.LoadAsync(file, LoadOptions.None, System.Threading.CancellationToken.None);
                }
            }
            catch (IOException)
            {
                throw new IOException("读取 XML 文件出错!");
            }
        }

        public void Read()
        {

        }

        public async void Save()
        {
            
        }
    }
}