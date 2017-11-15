using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

namespace ElementTreeComparison
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {  
            using (XmlReader xmlReader = XmlReader.Create("DemoWindow.xaml"))
            {
                Window wnd = XamlReader.Load(xmlReader) as Window;

                wnd.PreviewMouseLeftButtonDown += HandlePreviewMouseLeftButtonDown;
                wnd.PreviewMouseRightButtonDown += HandlePreviewMouseRightButtonDown;
                wnd.AddHandler(ButtonBase.ClickEvent, (RoutedEventHandler)HandleClick);

                wnd.ShowDialog();
            }
        }

        static void HandlePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                LogicalTreeDumper.Dump(e.OriginalSource as DependencyObject);
                e.Handled = true;
            }
        }

        static void HandlePreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                VisualTreeDumper.Dump(e.OriginalSource as DependencyObject);
                e.Handled = true;
            }
        }

        static void HandleClick(object sender, RoutedEventArgs e)
        {
            // Since CheckBox and Button both derive from ButtonBase, which exposes
            // the Click event, we need to make sure that the user is clicking on the
            // Button and not the CheckBox control.
            if(e.Source is Button)
                Console.Clear();
        }
    }
}