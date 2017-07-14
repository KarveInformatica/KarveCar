using iAnywhere.Data.SQLAnywhere;
using KRibbon.Properties;
using System;
using System.Windows;

namespace KRibbon.Model.Sybase
{
    public class ErrorsMessage
    {
        /// <summary>
        /// Muestra el mensaje de error de SAException en el idioma seleccionado, sino, muestra un mensaje de error default
        /// </summary>
        /// <param name="e"></param>
        /// <param name="msgError"></param>
        public static void ShowMessage(SAException e, string msgError)
        {
            string nativeerror = msgError.Equals("default") ? e.NativeError.ToString() : msgError;
            MessageBox.Show(("(" + e.NativeError.ToString() + ") " + nativeerror + "\n\n" + e.StackTrace.ToString()), 
                                Resources.msgErrorTitulo, 
                                MessageBoxButton.OK, 
                                MessageBoxImage.Error);
        }

        /// <summary>
        /// Muestra el mensaje de error de Exception en el idioma seleccionado, sino, muestra un mensaje de error default
        /// </summary>
        /// <param name="e"></param>
        /// <param name="msgError"></param>
        public static void ShowMessage(Exception e, string msgError)
        {
            string nativeerror = msgError.Equals("default") ? e.Message.ToString() : msgError;
            MessageBox.Show(("(" + e.Message.ToString() + ") " + nativeerror + "\n\n" + e.StackTrace.ToString()) + "\n\n" + e.TargetSite, 
                                Resources.msgErrorTitulo, 
                                MessageBoxButton.OK, 
                                MessageBoxImage.Error);
        }
    }
}
