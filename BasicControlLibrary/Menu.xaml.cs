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
