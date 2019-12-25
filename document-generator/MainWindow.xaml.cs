using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace document_generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New" + sender.ToString());
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            bool isMain = false;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "打开文件",
                DefaultExt = ".xml",
                Filter = "XML文档(.xml)|*.xml|主文档文件(.xmlmain)|*.xmlmain",
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() ?? false == true)
            {
                foreach (var file in openFileDialog.FileNames)
                {
                    if (file.EndsWith(".xml"))
                    {
                        OpenDoc(file);
                        isMain = false;
                    }
                    else if (file.EndsWith(".xmlmain") && file == openFileDialog.FileNames[^1])
                    {
                        OpenMain(file);
                        isMain = true;
                    }
                }

                if (!isMain)
                    documentList.Load(XMLDefault.XMLDefaultPath);
                else
                    documentList.Load(openFileDialog.FileNames[^1]);
            }
        }

        private void OpenMain(string path)
        {

        }

        private void OpenDoc(string path)
        {
            XMLDocumentationHandle documentation = new XMLDocumentationHandle(XMLDefault.XMLMarksDefault);
            documentation.Open(path);
            documentation.Split(XMLDefault.XMLDefaultPath);
            MessageBox.Show("分割完成!");
        }
    }
}
