using System.Windows;
using System.Windows.Input;

namespace KarveControls
{
    public class CommandExt
    {
        public static readonly DependencyProperty CommandProperty =
     DependencyProperty.RegisterAttached("Command",
     typeof(ICommand), typeof(CommandExt));

        public static void SetCommand(DependencyObject dp, object value)
        {
            dp.SetValue(CommandProperty, value);
        }
        public static ICommand GetCommand(DependencyObject dp)
        {
            return (ICommand) dp.GetValue(CommandProperty);
        }
        private static readonly DependencyProperty CommandParameterProperty =
           DependencyProperty.RegisterAttached("CommandParameter", typeof(string),
           typeof(CommandExt));

        public static void SetCommandParameter(DependencyObject dp,string value)
        {
            dp.SetValue(CommandParameterProperty, value);
        }
        public static string GetCommandParameter(DependencyObject dp)
        {
            return (string)dp.GetValue(CommandParameterProperty);
        }
    }
}
