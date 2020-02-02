using System.Windows.Input;

namespace Components
{
    public static class Commands
    {
        public static readonly RoutedUICommand New = new RoutedUICommand
            (
                "新建",
                "New",
                typeof(Commands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.N, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand Open = new RoutedUICommand
            (
                "打开",
                "Open",
                typeof(Commands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.O, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand Save = new RoutedUICommand
            (
                "保存",
                "Save",
                typeof(Commands),
                new InputGestureCollection
                    {
                        new KeyGesture(Key.S, ModifierKeys.Control)
                    }
            );

        public static readonly RoutedUICommand SaveAs = new RoutedUICommand
            (
                "另存为",
                "SaveAs",
                typeof(Commands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift)
                }
            );
        public static readonly RoutedUICommand Output = new RoutedUICommand
            (
                "导出",
                "Output",
                typeof(Commands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.I, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "退出",
                "Exit",
                typeof(Commands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.F4, ModifierKeys.Alt)
                }
            );
        public static readonly RoutedUICommand Delete = new RoutedUICommand
            (
                "删除",
                "Delete",
                typeof(Commands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.Delete)
                }
            );
        public static readonly RoutedUICommand Produce = new RoutedUICommand
            (
                "生成",
                "Produce",
                typeof(Commands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.F4)
                }
            );
        public static readonly RoutedUICommand Preview = new RoutedUICommand
            (
                "预览",
                "Preview",
                typeof(Commands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.F5)
                }
            );
    }
}
