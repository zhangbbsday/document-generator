using System;
using System.Windows;
using System.Windows.Input;
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

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string[] names = FileExtension.OpenFiles("打开文件", DefaultSetting.OpenFileTypeFilterDefault);

                foreach (string path in names)
                {
                    xmlContent.Load(path);
                }
            }
            catch (Exception exception)
            {
                MessageBoxExtension.ErroBox(exception.Message);
            }
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string name = FileExtension.SaveFile("保存文件", DefaultSetting.SaveFileTypeFilterDefault);
                xmlContent.Save(name);
            }
            catch (Exception exception)
            {
                MessageBoxExtension.ErroBox(exception.Message);
            }
        }

        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = xmlContent.IsProduced;
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
                xmlContent.Preview();
            }
            catch (Exception exception)
            {
                MessageBoxExtension.ErroBox(exception.Message);
            }
        }
    }
}
