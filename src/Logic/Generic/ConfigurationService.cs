using System;
using System.Windows;
using System.Windows.Controls;
using Prism.Events;
using KarveCommon.Services;
using KarveCommon.Generic;
using KarveCar.Model.Generic;
using static KarveCar.Model.Generic.RecopilatorioCollections;
using KarveCommon.Logic.Generic;
using System.Windows.Data;
using KarveCar.View;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Prism.Commands;
using KarveCar.Logic.Generic;
using KarveCar.Views;
using KarveControls;
using MasterModule.Views;
using Prism.Regions;

namespace KarveCar.Logic
{
    /// <summary>
    ///  Configuration services is a service configuration used around the application for 
    ///  providing a communication mechanism between the view models.
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        private Window mainWindow;
        private CustomTabItemViewModel tabItemVm;

        private IDictionary<string, TabItem> dictionaryTab = new Dictionary<string, TabItem>();
        public static IEnviromentVariables env = new EnviromentVariableContainer();

        /// <summary>
        ///  This is the constructor of the configuration service
        /// </summary>
        /// <param name="mainWindow">The main shell of the application will be injected to the ConfigurationService.</param>
        public ConfigurationService()
        {
            this.mainWindow = null;
        }

        /// <summary>
        ///  This returns the Shell.
        /// </summary>
        public Window Shell
        {
            set { this.mainWindow = value; }
            get { return this.mainWindow; }
        }

        /// <summary>
        ///  This close the application.
        /// </summary>
        /// <returns>true if the close has been successfully.</returns>
        public bool CloseApplication()
        {

            if (mainWindow == null)
            {
                return false;
            }
            try
            {
                mainWindow.Close();
            }
            catch (Exception ex)
            {
                throw new ConfigurationServiceException("ConfigurationService Error during CloseApplication. Reason:" +
                                                        ex.Message);
            }
            return true;
        }


        public bool AddMainTab(object view, string tabName)
        {
            HeaderData data = new HeaderData();
            CustomTabControl tbitem = new CustomTabControl();
            tbitem.HorizontalAlignment = HorizontalAlignment.Stretch;
            var binding = new Binding();
            binding.IsAsync = true;
            tabItemVm = tbitem.Model;
            data.Name = tabName;
            data.Header = tabName;
            binding.Path = new PropertyPath("Header");
            binding.Source = data;
            tbitem.SetBinding(TabItem.HeaderProperty, binding);
            CustomTabControl tb = null;
            if (!tabItemVm.hasItem(tabName, out tb))
            {
                tabItemVm.addItem(tabName, tbitem);
                tbitem.Content = view;
                tbitem.HeaderTemplate = tbitem.FindResource("TabHeader") as DataTemplate;
                ((MainWindow) Application.Current.MainWindow).NewTabControl.Items.Add(tbitem);
                tbitem.Focus();
                return true;
            }
            tbitem.Focus();
            return false;
        }

        public string GetPrimaryKeyValue()
        {
            object selectedItem = ((MainWindow) Application.Current.MainWindow).NewTabControl.SelectedItem;
            if (selectedItem is TabItem)
            {
                TabItem item = (TabItem) selectedItem;
                string itemHeader = item.Header as string;
                string[] value = itemHeader.Split('.');
                return value[0];
            }
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
                
                /*
            var itemValue = item.GetType().GetProperty("Header").GetValue(item, null);
                if (itemValue != null)
                {
                    string currentValue = itemValue as string;
                    if (currentValue.Contains(primaryKeyValue))
                    {
                        
                    }
                }
                   // string headerValue = item.Header as string;
                   // if (headerValue.Contains(primaryKeyValue))
                   // {
                   string v = "djdhjd";
               // }
               */
            }
            //RemoveItemFromRegion(tabItem.Content, region);

            /*ItemCollection collection = control.Items;
            string key = tabItemVm.ContainsItem(primaryKeyValue);
            
            tabItemVm.CloseTabItemCommand.Execute(key);
            */
        }


        void RemoveItemFromRegion(object item, IRegion region)
        {
            var navigationContext = new NavigationContext(region.NavigationService, null);
            if (CanRemove(item, navigationContext))
            {
                InvokeOnNavigatedFrom(item, navigationContext);
                region.Remove(item);
            }
        }

        void InvokeOnNavigatedFrom(object item, NavigationContext navigationContext)
        {
            var navigationAwareItem = item as INavigationAware;
            if (navigationAwareItem != null)
                navigationAwareItem.OnNavigatedFrom(navigationContext);

            var frameworkElement = item as FrameworkElement;
            if (frameworkElement != null)
            {
                INavigationAware navigationAwareDataContext = frameworkElement.DataContext as INavigationAware;
                if (navigationAwareDataContext != null)
                {
                    navigationAwareDataContext.OnNavigatedFrom(navigationContext);
                }
            }
        }

        bool CanRemove(object item, NavigationContext navigationContext)
        {
            bool canRemove = true;

            var confirmRequestItem = item as IConfirmNavigationRequest;
            if (confirmRequestItem != null)
            {
                confirmRequestItem.ConfirmNavigationRequest(navigationContext, result =>
                {
                    canRemove = result;
                });
            }

            var frameworkElement = item as FrameworkElement;
            if (frameworkElement != null && canRemove)
            {
                IConfirmNavigationRequest confirmRequestDataContext =
                    frameworkElement.DataContext as IConfirmNavigationRequest;
                if (confirmRequestDataContext != null)
                {
                    confirmRequestDataContext.ConfirmNavigationRequest(navigationContext, result =>
                    {
                        canRemove = result;
                    });
                }
            }

            return canRemove;
        }

        static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            var parent = parentObject as T;
            if (parent != null)
                return parent;

            return FindParent<T>(parentObject);
        }


        /// <summary>
        ///  This is the custom view model for the main custom tabs.
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

