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
        /// <summary>
        ///  Global enviroment. 
        /// </summary>
        public static IEnviromentVariables _env = new EnviromentVariableContainer();
        /// <summary>
        ///  This is the constructor of the configuration service
        /// </summary>
        /// <param name="mainWindow">The main shell of the application will be injected to the ConfigurationService.</param>
        public ConfigurationService()
        {
            this._mainWindow = null;
            _userSettings = new UserSettings();
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
        public string ConnectionString {
            get
            {
                var connection = _userSettings.FindSetting<string>(UserSettingConstants.DefaultConnectionString);
                return connection;
            }
            set
            {
                _userSettings.SaveSetting<string>(UserSettingConstants.DefaultConnectionString, value);

            }
        }

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
            get { return _env; }
            set { _env = value; }
        }


        /// <summary>
        /// Get or Set the enviroment variables.
        /// </summary>
        /// <returns></returns>
        public IUserSettings UserSettings
        {
            get { return _userSettings; }
            set { _userSettings = value; }
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

