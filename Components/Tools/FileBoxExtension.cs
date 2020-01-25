using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Components
{
    public class FileBoxExtension
    {
        public static string OpenFile((string title, string defaultExt, string filter) info)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = info.title,
                DefaultExt = info.defaultExt,
                Filter = info.filter,
            };

            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }

        public static string SaveFile((string title, string defaultExt, string filter) info)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = info.title,
                DefaultExt = info.defaultExt,
                Filter = info.filter,
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
