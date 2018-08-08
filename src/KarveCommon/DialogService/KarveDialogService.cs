
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using System.Windows;
using Microsoft.Practices.Unity;
using KarveCommon.DialogService.Views;
using KarveCommon.DialogService.ViewModels;


namespace KarveCommon.DialogService
{
    /// <summary>
    ///  This implementation shall be differe and ssociated with a view first scenario or using intraction
    /// </summary>
    public class KarveDialogService : IDialogService
    {
        IUnityContainer _container;
        public KarveDialogService(IUnityContainer container)
        {
            _container = container;
            _container.RegisterType<object, ConfirmMessageViewModel>(typeof(ConfirmMessageViewModel).FullName);
            _container.RegisterType<object, ConfirmationView>(typeof(ConfirmationView).FullName);

        }
        public bool ShowConfirmMessage(string title, string message)
        {
            var viewModel = _container.Resolve<ConfirmMessageViewModel>();
            viewModel.Title = title;
            viewModel.Message = message;
            ConfirmationView view = _container.Resolve<ConfirmationView>();
            view.DataContext = viewModel;
            view.ShowDialog();
            return viewModel.IsConfirmed;
        }

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
