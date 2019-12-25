using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using XMLHandle;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicControlLibrary
{
    /// <summary>
    /// DocumentList.xaml 的交互逻辑
    /// </summary>
    public partial class DocumentList : UserControl
    {
        public DocumentList()
        {
            InitializeComponent();
        }

        public void Load(string path)
        {
            string filePath = path;
            if (!filePath.EndsWith(".xmlmain"))
            {
                if (!System.IO.Directory.Exists(path + XMLDefault.DataDirectory))
                    throw new System.IO.DirectoryNotFoundException("没有找到data文件夹!");
                else
                    filePath += XMLDefault.DataDirectory + XMLDefault.MainXMLName + ".xmlmain";
            }

            XMLDocumentationMainLoader.OpenMain(filePath);

            foreach (var x in XMLDocumentationMainLoader.FindElements(XMLDocumentationMainLoader.MainDocument.Root))
            {
                TreeViewItem item = new TreeViewItem
                {
                    Header = x.Attribute("name").Value,
                    Tag = x
                };
                item.Items.Add("*");

                documentListTree.Items.Add(item);
            }
        }

        /// <summary>
        /// 及时更新树内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentList_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem select = (TreeViewItem)e.OriginalSource;
            select.Items.Clear();

            foreach (var x in XMLDocumentationMainLoader.FindElements((System.Xml.Linq.XElement)select.Tag))
            {
                TreeViewItem item = new TreeViewItem
                {
                    Header = x.Attribute("name").Value,
                    Tag = x
                };
                item.Items.Add("*");

                select.Items.Add(item);
            }
        }
    }
}
