
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using System.Windows;

namespace KarveCommon.DialogService
{
    /// <summary>
    ///  This implementation shall be differe and ssociated with a view first scenario or using intraction
    /// </summary>
    public class KarveDialogService : IDialogService
    {
        public MessageDialogResult ShowDialogMessage(string title, string message)
        {
            throw new NotImplementedException();
        }

        public MessageDialogResult ShowDialogView(object view, object viewModel)
        {
            throw new NotImplementedException();
        }

        public MessageDialogResult ShowDialogViewByName(string view)
        {
            throw new NotImplementedException();
        }

        public void ShowErrorMessage(string errorMessage)
        {
            // this needs to be replaced with the correct message.
            MessageBox.Show(errorMessage);
        }

        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK);
        }

        public void ShowView(object view, object viewModel)
        {
            throw new NotImplementedException();
        }

        public MessageDialogResult ShowYesNoDialog(string title, string text, MessageDialogResult defaultResult = MessageDialogResult.Yes)
        {
            throw new NotImplementedException();
        }
    }
}
