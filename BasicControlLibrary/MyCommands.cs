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
    }
}
