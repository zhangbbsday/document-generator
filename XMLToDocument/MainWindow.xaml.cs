﻿using System;
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
                string name = FileBoxExtension.SaveFile(("保存文件", DefaultSetting.FileTypeDefault, DefaultSetting.FileTypeFilterDefault));
                memberContent.Load(name);
            }
            catch (Exception)
            {
                MessageBoxExtension.ErroBox("出错!");
            }
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                string name = FileBoxExtension.OpenFile(("打开文件", DefaultSetting.FileTypeDefault, DefaultSetting.FileTypeFilterDefault));
                if (name.EndsWith(".dal"))
                    memberContent.Load(name);
                else
                    xmlContent.Load(name);
            }
            catch (Exception)
            {
                MessageBoxExtension.ErroBox("出错!");
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
                string name = FileBoxExtension.SaveFile(("保存文件", DefaultSetting.FileTypeDefault, DefaultSetting.FileTypeFilterDefault));
                memberContent.SaveAs(name);
            }
            catch (Exception)
            {
                MessageBoxExtension.ErroBox("出错!");
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
            catch (Exception)
            {
                MessageBoxExtension.ErroBox("出错!");
            }
        }
    }
}
