using KarveCar.Model.Sybase;
using KarveCar.Properties;
using KarveCar.View;
using System;
using System.ComponentModel;
using System.Windows;
namespace KarveCar.Logic.Generic
{
    /// <summary>
    /// <author>Jordi Fernández Moreno</author>
    /// </summary>

    public class CloseWindowLogic
    {
        /// <summary>
        /// Cierra la aplicación. Llamada desde (Ribbon.ApplicationMenu)Inicio/Salir
        /// </summary>
        public static void CloseWindowFromCommand()
        {
            try
            {
                if (MessageBox.Show(Resources.msgSalir, Resources.lrapmnitSalir, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ((MainWindow)Application.Current.MainWindow).Close();
                }
            }
            catch (Exception ex)
            {
                ErrorsGeneric.MessageError(ex);
            }
        }

        /// <summary>
        /// Cierra la aplicación. Llamada desde Alt+F4 o desde el botón de cerrar ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CloseWindowFromWindow(object sender, CancelEventArgs e)
        {
            try
            {
                if (MessageBox.Show(Resources.msgSalir, Resources.lrapmnitSalir, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            catch (Exception ex)
            {
                ErrorsGeneric.MessageError(ex);
            }
        }
    }
}
