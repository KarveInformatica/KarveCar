using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.Windows.Controls;
using static KarveCommon.Generic.Enumerations;
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
        ///  Get or Set the enviroment variables for the application.
        /// </summary>
        /// <returns></returns>
        IEnviromentVariables EnviromentVariables { set; get; }
        /// <summary>
        ///  The current main window
        /// </summary>
        Window Shell { set; get; }
        /// <summary>
        ///  Get the account managemenet solution.
        /// </summary>
        /// <returns></returns>
        IUserAccessControlList GetAccountManagement();
        /// <summary>
        ///  Get User Settings. 
        /// </summary>
        /// <returns></returns>
        IUserSettings UserSettings { set; get; }
        /// <summary>
        ///  Connection string
        /// </summary>
        /// <returns></returns>
        string ConnectionString { set; get; }
    }
}