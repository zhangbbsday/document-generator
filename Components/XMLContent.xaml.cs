using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EditToolLibrary;

namespace Components
{
    /// <summary>
    /// XMLContent.xaml 的交互逻辑
    /// </summary>
    public partial class XMLContent : UserControl
    {
        private Dictionary<string, XMLFileContainer> xmlFiles = new Dictionary<string, XMLFileContainer>();
        public XMLContent()
        {
            InitializeComponent();
        }

        public void Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            LoadXMLFile(path);
            MessageBoxExtension.NomalBox("加载 XML 文件成功!");
        }

        private void LoadXMLFile(string path)
        {
            XMLFileContainer file = new XMLFileContainer(XDocument.Load(path));
            if (!xmlFiles.ContainsKey(path))
            {
                xmlContentList.Items.Add(file);
                xmlFiles[path] = file;
            }
            else
                MessageBoxExtension.WarningBox("已有重复内容!");
        }
    }
}
