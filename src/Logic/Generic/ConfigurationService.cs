using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataAccessLayer.DataObjects;
using Dapper;
using KarveDapper.Extensions;

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
        private ISqlExecutor _executor;
        private IEnumerable<CONFIKARVE> _configKarve;
        private IEnumerable<CONFI_EMP> _configCompany;
        /// <summary>
        ///  Global enviroment. 
        /// </summary>
        private static IEnviromentVariables _enviroment = new EnvironmentVariableContainer();
        
        public ConfigurationService()
        {
            this._mainWindow = null;
           
            _userSettings = new UserSettings();
             SetDefaultEnvironmentValues();
        }
        /// <summary>
        ///  Configure the configuration services using the user settings.
        /// </summary>
        /// <param name="settings">User defined settings</param>
        public ConfigurationService(IUserSettings settings, ISqlExecutor executor)
        {
            _userSettings = settings;
            _executor = executor;
            InitSettings();
        }

        private void InitSettings()
        {
            using (var connection = _executor.OpenNewDbConnection())
            {
                _configKarve = connection.GetAll<CONFIKARVE>();
                _configCompany = connection.GetAll<CONFI_EMP>();
            }
        }

        private void SetDefaultEnvironmentValues()
        {
            _enviroment.SetKey(EnvironmentConfig.KarveConfiguration, EnvironmentKey.CurrentOffice, "C1");
            _enviroment.SetKey(EnvironmentConfig.KarveConfiguration, EnvironmentKey.CurrentUser, "CV");
            
        }

        public T FindCompanyConfiguration<T>(string name) 
        {
            var value = Activator.CreateInstance<T>();
            var singleType = _configCompany.GetType();
            var properties = singleType.GetProperties();
            foreach (var property in properties)
            {
                if (property.Name == name)
                {
                    // ok this is the correct name.
                    var currentValue = property.GetValue(_configCompany);
                    if (currentValue is T setting)
                    {
                        return setting;
                    }
                }
            }
            return value;
        }

        /// <summary>
        ///  This returns the Shell.
        /// </summary>
        public Window Shell
        {
            set { _mainWindow = value; }
            get { return _mainWindow; }
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
            get { return _enviroment; }
            set { _enviroment = value; }
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

