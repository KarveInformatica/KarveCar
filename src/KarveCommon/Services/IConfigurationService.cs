using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.Windows.Controls;
using static KarveCommon.Generic.RecopilatorioEnumerations;
using System.Windows;

namespace KarveCommon.Services
{
    /// <summary>
    ///  This service is a global service for messagging and closing the application
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        ///  This method helps for closing the application
        /// </summary>
        /// <returns></returns>
        bool CloseApplication();
        /// <summary>
        ///  This method wrap up the old main tab subsystem. It adds a tab in the central window.
        /// </summary>
        /// <param name="view">Name of the view.</param>
        /// <param name="tabName">Name of the tab.</param>
        /// <returns></returns>
        bool AddMainTab(object view, string tabName);
        /// <summary>
        ///  This returns the enviroment variables of the application.
        /// </summary>
        /// <returns></returns>
        IEnviromentVariables GetEnviromentVariables();
        /// <summary>
        ///  The current main window
        /// </summary>
        Window Shell { set; get; }

        /// <summary>
        ///  Get the primary key value associated with the current active tab.
        /// </summary>
        /// <returns></returns>
        string GetPrimaryKeyValue();
        /// <summary>
        ///  Get the account managemenet solution.
        /// </summary>
        /// <returns></returns>
        IUserAccessControlList GetAccountManagement();

        /// <summary>
        ///  Get User Settings. 
        /// </summary>
        /// <returns></returns>
        IUserSettings GetUserSettings();
        /// <summary>
        ///  Set user settings.
        /// </summary>
        /// <param name="settings"></param>
        void SetUserSettings(IUserSettings settings);

        void CloseTab(string primaryKeyValue);
    }
}