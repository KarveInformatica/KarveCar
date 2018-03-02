using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using KarveCar.View;
using KarveCar.Views;
using KarveCommon.Services;
using Prism.Commands;
using Prism.Regions;

namespace KarveCar.Logic.Generic
{
    /// <summary>
    ///  Configuration services is a service configuration used around the application for 
    ///  providing a communication mechanism between the view models.
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        private Window _mainWindow;
        private CustomTabItemViewModel _tabItemVm;
        private IUserSettings _userSettings;
        private IDictionary<string, TabItem> dictionaryTab = new Dictionary<string, TabItem>();
        public static IEnviromentVariables env = new EnviromentVariableContainer();

        /// <summary>
        ///  This is the constructor of the configuration service
        /// </summary>
        /// <param name="mainWindow">The main shell of the application will be injected to the ConfigurationService.</param>
        public ConfigurationService()
        {
            this._mainWindow = null;
        }
        /// <summary>
        ///  Configuratin service
        /// </summary>
        /// <param name="settings"></param>
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

        

        public string GetPrimaryKeyValue()
        {
         /*   object selectedItem = ((MainWindow) Application.Current.MainWindow).NewTabControl.SelectedItem;
            if (selectedItem is TabItem)
            {
                TabItem item = (TabItem) selectedItem;
                string itemHeader = item.Header as string;
                string[] value = itemHeader.Split('.');
                return value[1];
            }
            if (selectedItem is UserControl)
            {
                UserControl item = selectedItem as UserControl;
                var context = item.DataContext;
               var propertyInfo =  context.GetType().GetProperty("PrimaryKeyValue");
                if (propertyInfo != null)
                {
                    var primaryKey = propertyInfo.GetValue(context) as string;
                    if (!string.IsNullOrEmpty(primaryKey))
                    {
                        return primaryKey;
                    }
                }
          
            }
            */
            return "";
        }

        /// <summary>
        /// This returns the enviroments variables.
        /// </summary>
        /// <returns></returns>
        public IEnviromentVariables GetEnviromentVariables()
        {
          
            return env;
        }

        
        public IUserAccessControlList GetAccountManagement()
        {
            throw new NotImplementedException();
        }

        public void CloseTab(string primaryKeyValue)
        {
            /*
            TabControl control = ((MainWindow) Application.Current.MainWindow).NewTabControl;
            IRegion region = RegionManager.GetObservableRegion(control).Value;
            if (region == null)
                return;
            for (int i= 0; i < control.Items.Count; ++i)
            {
                var item = control.Items[i];
                if (item is CustomTabControl)
                {
                    CustomTabControl ct = (CustomTabControl) item;
                    string ctHeader = ct.Header as string;
                    if (ctHeader.Contains(primaryKeyValue))
                    {
                       control.Items.Remove(ct);
                    }
                }
                
            }
            */
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
        /// <param name="settings"></param>
        public void SetUserSettings(IUserSettings settings)
        {
            _userSettings = settings;
        }

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  This is the custom view model for the main custom tabs.
        ///  TODO: Remove all this complexity. we dont need it.
        /// </summary>
        public class CustomTabItemViewModel
        {
            IDictionary<string, CustomTabControl> control = new Dictionary<string, CustomTabControl>();
            public ICommand CloseTabItemCommand { set; get; }

            public CustomTabItemViewModel()
            {
                this.CloseTabItemCommand = new DelegateCommand<object>(onCloseButton);
            }

            public bool hasItem(string name, out CustomTabControl tabOut)
            {
                tabOut = null;
                if (control.ContainsKey(name))
                {
                    tabOut = control[name];
                    return true;
                }
                return false;
            }

            public void addItem(string name, CustomTabControl tab)
            {
                control.Add(name, tab);
            }

            private void onCloseButton(object v)
            {
                /*
                string key = v as string;
                foreach (string k in control.Keys)
                {
                    if (key == k)
                    {
                        CustomTabControl view = control[key];
                        ((MainWindow)Application.Current.MainWindow).NewTabControl.Items.Remove(view);
                        control.Remove(key);
                        break;
                    }
    
                }
                
                if (control.ContainsKey(key))
                {
                    CustomTabControl view = control[key];
                    ((MainWindow)Application.Current.MainWindow).NewTabControl.Items.Remove(view);
                    control.Remove(key);
                }
                */


            }

            internal string ContainsItem(string primaryKeyValue)
            {
                ICollection<string> keys = control.Keys;
                foreach (string s in keys)
                {
                    if (s.Contains(primaryKeyValue))
                    {
                        return s;
                    }

                }
                return "";
            }
        }

        public class HeaderData
        {
            private string _header;
            private string _name;
            private CustomTabItemViewModel _model = new CustomTabItemViewModel();

            public string Header
            {
                set { _header = value; }
                get { return _header; }
            }

            public string Name
            {
                set { _name = value; }
                get { return _name; }
            }

            public CustomTabItemViewModel Model
            {
                get { return _model; }
                set { _model = value; }
            }
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

