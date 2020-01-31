using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Components;
using EditToolLibrary;

namespace XMLToDocument
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
            try
            {
                string name = FileExtension.SaveFile("保存文件", DefaultSetting.SaveFileTypeDefault, DefaultSetting.FileTypeFilterDefault);
                memberContent.Load(name);
            }
            catch (Exception exception)
            {
                MessageBoxExtension.ErroBox(exception.Message);
            }
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string[] names = FileExtension.OpenFiles("打开文件", DefaultSetting.SaveFileTypeDefault, DefaultSetting.FileTypeFilterDefault);

                if (names[0].EndsWith(".dal"))
                    memberContent.Load(names[^1]);
                else
                {
                    foreach (string path in names)
                    {
                        xmlContent.Load(path);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBoxExtension.ErroBox(exception.Message);
            }
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            memberContent.Save();
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string name = FileExtension.SaveFile("保存文件", DefaultSetting.SaveFileTypeDefault, DefaultSetting.FileTypeFilterDefault);
                memberContent.SaveAs(name);
            }
            catch (Exception exception)
            {
                MessageBoxExtension.ErroBox(exception.Message);
            }
        }

        private void OutputCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                xmlContent.Delete();
            }
            catch (Exception exception)
            {
                MessageBoxExtension.ErroBox(exception.Message);
            }
        }

        private void ProduceCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                xmlContent.Produce();
            }
            catch (Exception exception)
            {
                MessageBoxExtension.ErroBox(exception.Message);
            }
        }

        private void PreviewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception exception)
            {
                MessageBoxExtension.ErroBox(exception.Message);
            }
        }
    }
}
