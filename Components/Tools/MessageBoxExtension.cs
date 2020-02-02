using System.Windows;

namespace Components
{
    public static class MessageBoxExtension
    {
        public static void NomalBox(string content, string title = "提示")
        {
            MessageBox.Show(content, title);
        }

        public static void WarningBox(string content, string title = "警告")
        {
            MessageBox.Show(content, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void ErroBox(string content, string title = "错误")
        {
            MessageBox.Show(content, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
