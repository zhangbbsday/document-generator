using System;
using XMLHandle;
using System.Windows.Forms;

namespace XMLTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            XMLDocumentationHandle documentation = new XMLDocumentationHandle(XMLDefault.XMLMarksDefault);
            documentation.Open(Open());
            documentation.Split(Save());

            Console.WriteLine("分割完成!");
            Console.ReadKey();
        }

        static string Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "打开XML文档",
                DefaultExt = ".xml",
                Filter = "XML文档(.xml)|*.xml"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return openFileDialog.FileName;
            return null;
        }

        static string Save()
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "选择保存路径",
                ShowNewFolderButton = true
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                if (!path.EndsWith("\\"))
                    path = path.Insert(path.Length, @"\");
                return path;
            }
            return null;
        }
    }
}
