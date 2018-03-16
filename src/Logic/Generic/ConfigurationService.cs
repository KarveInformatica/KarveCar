using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KarveCommon.Services;

namespace KarveCar.Logic.Generic
{
    /// <summary>
    ///  Configuration services is a service configuration used around the application for 
    ///  providing a communication mechanism between the view models.
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        private Window _mainWindow;
        private IUserSettings _userSettings;
        private IDictionary<string, TabItem> dictionaryTab = new Dictionary<string, TabItem>();
        public static IEnviromentVariables _env = new EnviromentVariableContainer();
        private string _connectionString;

        /// <summary>
        ///  This is the constructor of the configuration service
        /// </summary>
        /// <param name="mainWindow">The main shell of the application will be injected to the ConfigurationService.</param>
        public ConfigurationService()
        {
            this._mainWindow = null;
        }
        /// <summary>
        ///  Configure the configuration services using the user settings.
        /// </summary>
        /// <param name="settings">User defined settings</param>
        public ConfigurationService(IUserSettings settings)
        {
            _userSettings = settings;
        }

        /// <summary>
        ///  This returns the Shell.
        /// </summary>
        public Window Shell
        {
            set { this._mainWindow = value; }
            get { return this._mainWindow; }
        }
        /// <summary>
        ///  Get or Set the connection string.
        /// </summary>
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }

        /// <summary>
        ///  This close the application.
        /// </summary>
        /// <returns>true if the close has been successfully.</returns>
        public bool CloseApplication()
        {

            if (_mainWindow == null)
            {
                return false;
            }
            try
            {
                _mainWindow.Close();
            }
            catch (Exception ex)
            {
                throw new ConfigurationServiceException("ConfigurationService Error during CloseApplication. Reason:" +
                                                        ex.Message);
            }
            return true;
        }

        /// <summary>
        /// Get or Set the enviroment variables.
        /// </summary>
        /// <returns></returns>
        public IEnviromentVariables EnviromentVariables {
            get { return _env;  }
            set { _env = value; }
        }
        /// <summary>
        ///  Return the current user settings for the value
        /// </summary>
        /// <returns></returns>
        public IUserSettings GetUserSettings()
        {
            return _userSettings;
        }
        /// <summary>
        ///  Setup the user settings.
        /// </summary>
        /// <param name="settings"> Set the user settings </param>
        public void SetUserSettings(IUserSettings settings)
        {
            _userSettings = settings;
        }
        /// <summary>
        ///  Return the connection string
        /// </summary>
        /// <returns>return the connection string</returns>
        public string GetConnectionString()
        {
            return _connectionString;
        }

        public IUserAccessControlList GetAccountManagement()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Customization of the service.
        /// </summary>
        public class ConfigurationServiceException : Exception
        {
            public ConfigurationServiceException(string exMessage) : base(exMessage)
            {
            }
        }
    }
}

