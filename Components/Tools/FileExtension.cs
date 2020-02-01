using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Components
{
    public class FileExtension
    {
        public static string[] OpenFiles(string title, string filter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = title,
                Filter = filter,
                Multiselect = true
            };

            openFileDialog.ShowDialog();
            return openFileDialog.FileNames;
        }

        public static string SaveFile(string title, string filter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = title,
                Filter = filter,
            };

            if (saveFileDialog.ShowDialog() ?? false)
            {
                using Stream stream = saveFileDialog.OpenFile();
                if (stream != null)
                    stream.Close();
            }

            return saveFileDialog.FileName;
        }
    }
}
