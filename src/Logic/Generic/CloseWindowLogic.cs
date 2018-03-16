
using KarveCar.Properties;
using System;
using System.ComponentModel;
using System.Windows;
using KarveCar.Views;
using KarveCommonInterfaces;

namespace KarveCar.Logic.Generic
{
    /// <summary>
    /// <author>Jordi Fernández Moreno</author>
    /// </summary>

    public class CloseWindowLogic
    {

        private IDialogService _dialogService;

        public CloseWindowLogic(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        /// <summary>
        /// Cierra la aplicación. Llamada desde (Ribbon.ApplicationMenu)Inicio/Salir
        /// </summary>
        public void CloseWindowFromCommand()
        {
            if (_dialogService==null)
            {
                return;
            }
            try
            {
                MessageDialogResult result = _dialogService.ShowYesNoDialog(Resources.msgSalir, Resources.lrapmnitSalir);
                if (result != MessageDialogResult.Ok)
                {
                   
                }
            }
            catch (Exception ex)
            {
                
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
                
            }
        }
    }
}
