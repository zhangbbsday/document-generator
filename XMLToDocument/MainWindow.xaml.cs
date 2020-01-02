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
                string name = Tools.SaveFile(("保存文件", DefaultSetting.FileTypeDefault, DefaultSetting.FileTypeFilterDefault));
                content.Load(name);
            }
            catch (Exception)
            {
                MessageBox.Show("错误!", "出错!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string name = Tools.OpenFile(("打开文件", DefaultSetting.FileTypeDefault, DefaultSetting.FileTypeFilterDefault));
                content.Load(name);
            }
            catch (Exception)
            {
                MessageBox.Show("错误!", "出错!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            content.Save();
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string name = Tools.SaveFile(("保存文件", DefaultSetting.FileTypeDefault, DefaultSetting.FileTypeFilterDefault));
                content.SaveAs(name);
            }
            catch (Exception)
            {
                MessageBox.Show("错误!", "出错!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OutputCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show(e.OriginalSource.ToString());
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
