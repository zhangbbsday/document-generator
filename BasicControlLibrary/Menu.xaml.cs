using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XMLHandle;
using Forms = System.Windows.Forms;

namespace BasicControlLibrary
{
    /// <summary>
    /// Menu.xaml 的交互逻辑
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            XMLDocumentationHandle documentation = new XMLDocumentationHandle(XMLDefault.XMLMarksDefault);
            documentation.Open(Open());
            documentation.Split(Save());
            MessageBox.Show("分割完成!");
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("新建!");
        }

        private string Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "打开文件",
                DefaultExt = ".xml",
                Filter = "XML文档(.xml)|*.xml|主文档文件(.xmlmain)|*.xmlmain"
            };

            if (openFileDialog.ShowDialog() ?? false == true)
                return openFileDialog.FileName;
            return null;
        }

        private string Save()
        {
            using Forms::FolderBrowserDialog folderBrowserDialog = new Forms::FolderBrowserDialog
            {
                Description = "选择保存路径",
                ShowNewFolderButton = true
            };

            if (folderBrowserDialog.ShowDialog() == Forms::DialogResult.OK)
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
