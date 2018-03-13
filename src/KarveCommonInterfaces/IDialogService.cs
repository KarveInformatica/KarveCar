using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommonInterfaces
{
    /// <summary>
    ///  Dialog service used for dialog in the model view view model pattern.
    /// </summary>
    public interface IDialogService
    { 
        /// <summary>
        /// Show the dialog with yes or no.
        /// </summary>
        /// <param name="title">Title of the dialog</param>
        /// <param name="text">Text of the dialog</param>
        /// <param name="defaultResult"></param>
        /// <returns></returns>
        MessageDialogResult ShowYesNoDialog(string title, string text, MessageDialogResult defaultResult = MessageDialogResult.Yes);
        /// <summary>
        ///  Show dialog message with title.
        /// </summary>
        /// <param name="title">Title of the message.</param>
        /// <param name="message">Message to be shown.</param>
        /// <returns></returns>
        MessageDialogResult ShowDialogMessage(string title, string message);
        /// <summary>
        /// Show the dialog view and the services.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        MessageDialogResult ShowDialogView(object view, object viewModel);

        /// <summary>
        ///  Show a dialog view with the view name.
        ///  The view shall be registered in Unity Container.
        /// </summary>
        /// <param name="view">View name</param>
        /// <returns></returns>
        MessageDialogResult ShowDialogViewByName(string view);
        /// <summary>
        ///  Show a message with a title.
        /// </summary>
        /// <param name="title">Title of the service</param>
        /// <param name="message">Message of the service</param>
        void ShowMessage(string title, string message);
        /// <summary>
        ///  Show a generic dialog view with the view model.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="viewModel"></param>
        void ShowView(object view, object viewModel);
        /// <summary>
        /// Show an error message.
        /// </summary>
        /// <param name="errorMessage">Message to show</param>
        void ShowErrorMessage(string errorMessage);
    }
}
