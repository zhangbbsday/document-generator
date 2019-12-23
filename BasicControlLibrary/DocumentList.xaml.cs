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

        private void documentList_Initialized(object sender, EventArgs e)
        {
            XMLDocumentationMainLoader.OpenMain((string)Application.Current.Resources["mainPath"]);
            
            foreach (var x in XMLDocumentationMainLoader.FindElements(XMLDocumentationMainLoader.MainDocument.Root))
            {
                TreeViewItem item = new TreeViewItem
                {
                    Header = x.Attribute("name").Value,
                    Tag = x
                };
                item.Items.Add("*");

                documentList.Items.Add(item);
            }
        }

        /// <summary>
        /// 及时更新树内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void documentList_Expanded(object sender, RoutedEventArgs e)
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
