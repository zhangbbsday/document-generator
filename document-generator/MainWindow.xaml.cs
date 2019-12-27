using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using XMLHandle;
using System.IO;
using Forms = System.Windows.Forms;

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
            bool isMain = true;

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
                }

                if (!isMain)
                    documentList.Load(XMLDefault.XMLDefaultPath);
                else
                    documentList.Load(openFileDialog.FileNames[^1]);
            }
        }

        private void OpenDoc(string path)
        {
            XMLDocumentationHandle documentation = new XMLDocumentationHandle(XMLDefault.XMLMarksDefault);
            documentation.Open(path);
            documentation.Split(XMLDefault.XMLDefaultPath);
            MessageBox.Show("分割完成!");
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("保存!");
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("另存为!");
        }

        private void RecentOpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            foreach (string str in Default.DirectoryDefault)
            {
                CreateDirectory(Default.DataPathDefault + str);
            }
        }

        private void CreateDirectory(string path)
        {
            if (Directory.Exists(path))
                return;

            Directory.CreateDirectory(path);
        }
    }
}
