﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Components
{
    /// <summary>
    /// Content.xaml 的交互逻辑
    /// </summary>
    public partial class Content : UserControl
    {
        private string FileLoad { get; set; }
        public Content()
        {
            InitializeComponent();
        }

        public void Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            FileLoad = path;
            LoadListItems();
            MessageBox.Show("读取成功!");
        }

        public void Save()
        {
            if (FileLoad == null)
                return;

            SaveListItems(FileLoad);
            MessageBox.Show("保存成功!");
        }

        public void SaveAs(string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            SaveListItems(path);
            FileLoad = path;
            MessageBox.Show("保存成功!");
        }

        private void LoadListItems()
        {
            using FileStream fileStream = new FileStream(FileLoad, FileMode.Open, FileAccess.Read);
            using BinaryReader reader = new BinaryReader(fileStream);
            ObservableCollection<string> list = new ObservableCollection<string>();
            while (fileStream.Position != fileStream.Length)
            {
                list.Add(reader.ReadString());
            }

            contentList.ItemsSource = list;
        }

        private void SaveListItems(string path)
        {
            using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Write);
            using BinaryWriter writer = new BinaryWriter(fileStream);

            foreach (var item in contentList.ItemsSource)
            {
                writer.Write(item.ToString());
            }
        }
    }
}