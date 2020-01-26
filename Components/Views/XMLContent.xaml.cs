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
using System.Collections.ObjectModel;

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
        }

        public void Delete()
        {
            if (xmlContentList.SelectedItems == null)
                return;

            List<XMLFileContainer> selects = new List<XMLFileContainer>();
            foreach (XMLFileContainer select in xmlContentList.SelectedItems)
            {
                xmlFiles.Remove(select.Path);
                selects.Add(select);
            }

            foreach (XMLFileContainer select in selects)
            {
                xmlContentList.Items.Remove(select);
            }
        }

        private void LoadXMLFile(string path)
        {
            XMLFileContainer file = new XMLFileContainer(path);
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
