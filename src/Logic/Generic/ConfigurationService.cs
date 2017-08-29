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
using System.Windows.Input;
using Prism.Commands;

namespace KarveCar.Logic
{
    /// <summary>
    ///  Configuration services is a service configuration used around the application for 
    ///  providing a communication mechanism between the view models.
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {

        private Window mainWindow;
        private readonly IEventAggregator eventAggregator = new EventAggregator();

        /// <summary>
        ///  This is the constructor of the configuration service
        /// </summary>
        /// <param name="mainWindow">The main shell of the application will be injected to the ConfigurationService.</param>
        public ConfigurationService(Window mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        /// <summary>
        /// This method notify the change of the DataPayLoad the receiver.
        /// </summary>
        /// <param name="changedData">Payload changed. In case of DataPayload it has inside the data.</param>
        public void NotifyDataChange(DataPayLoad changedData)
        {
            
                lock (this)
                {
                    eventAggregator.GetEvent<DataChangeEvent>().Publish(changedData);
                }
                
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
                throw new ConfigurationServiceException("ConfigurationService Error during CloseApplication. Reason:" + ex.Message);
            }
            return true;
        }
        /// <summary>
        /// TODO. This method subscribe waiting for the change of the data. It shall be an asynchronous subscribtion.
        /// </summary>
        /// <param name="action"></param>
        public void SubscribeDataChange(Action<DataPayLoad> action)
        {
        }

        public void AddMainTab(object view, string tabName)
        {
            HeaderData data = new HeaderData();
            CustomTabControl tbitem = new CustomTabControl();
            tbitem.HorizontalAlignment = HorizontalAlignment.Stretch;
            CustomTabItemViewModel tabItemVm;
            var binding = new Binding();
            binding.IsAsync = true;
            tabItemVm = tbitem.Model;
            data.Name = tabName;
            data.Header = tabName;
            binding.Path = new PropertyPath("Header");
            binding.Source = data;
            tbitem.SetBinding(TabItem.HeaderProperty, binding);
            // tbitem.
             //   TabItemCloseButton.DataContext = tabItemVm;

            tabItemVm.addItem(tabName, tbitem);
            //tbitem.Header = tabName;
            tbitem.Content = view;
            //tabitemdictionary.Add(tabName, new TemplateInfoTabItem(tbitem));
            tbitem.HeaderTemplate = tbitem.FindResource("TabHeader") as DataTemplate;
            
            // tabitemdictionary.Add(RecopilatorioEnumerations.EOpcion.Default, new TemplateInfoTabItem(tbitem));
            // TODO.
            //Se añade el nuevo TabItem al TabControl, le ponemos el focus y devolvemos el nuevo TabItem
            ((MainWindow)Application.Current.MainWindow).tbControl.Items.Add(tbitem);

            tbitem.Focus();
        }
    }
    public class CustomTabItemViewModel
    {
        IDictionary<string, CustomTabControl> control = new Dictionary<string, CustomTabControl>();
        public ICommand CloseTabItemCommand
        { set; get; }
        
        public CustomTabItemViewModel()
        {
            this.CloseTabItemCommand = new DelegateCommand<object>(onCloseButton);
        }
        public void addItem(string name, CustomTabControl tab)
        {
            control.Add(name, tab);
        }
        private void onCloseButton(object v)
        {
            string key = v as string;
            if (control.ContainsKey(key))
            {
                CustomTabControl view = control[key];
                ((MainWindow)Application.Current.MainWindow).tbControl.Items.Remove(view);
                control.Remove(key);
            }
            
        }
    }
    public class HeaderData
    {
        private string _header;
        private string _name;
        private CustomTabItemViewModel _model = new CustomTabItemViewModel();
        public string Header {
            set { _header = value; }
            get { return _header; } }
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public CustomTabItemViewModel Model {
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
