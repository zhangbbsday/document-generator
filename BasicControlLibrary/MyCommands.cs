using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;

namespace BasicControlLibrary
{
    public static class MyCommands
    {
        public static readonly RoutedUICommand New = new RoutedUICommand
            (
                "新建",
                "New",
                typeof(MyCommands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.N, ModifierKeys.Control)
                }
            );

        public static readonly RoutedUICommand Open = new RoutedUICommand
            (
                "打开",
                "Open",
                typeof(MyCommands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.O, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand RecentOpen = new RoutedUICommand
            (
                "保存",
                "Save",
                typeof(MyCommands)
            );

        public static readonly RoutedUICommand Save = new RoutedUICommand
            (
                "保存",
                "Save",
                typeof(MyCommands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.S, ModifierKeys.Control)
                }
            );
        public static readonly RoutedUICommand SaveAs = new RoutedUICommand
            (
                "保存",
                "Save",
                typeof(MyCommands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift)
                }
            );
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "保存",
                "Save",
                typeof(MyCommands),
                new InputGestureCollection
                {
                    new KeyGesture(Key.F4, ModifierKeys.Alt)
                }
            );
    }
}
