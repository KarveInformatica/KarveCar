using System;
using System.Windows;
using MultiEventCommandBinder;

namespace MultiEventCommand.Classes
{
    public class TryCatch
    {
        public static void BeginTryCatch(Action<CommandArgs> function, CommandArgs obj)
        {
            try
            {
                function.Invoke(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void BeginTryCatch(Action<object> function, object obj)
        {
            try
            {
                function.Invoke(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void BeginTryCatch(Action function)
        {
            try
            {
                function.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //You can log error here for e.g you can use log4net
            }
        }
    }
   
}
