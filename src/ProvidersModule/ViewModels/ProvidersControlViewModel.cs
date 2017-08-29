using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using KarveDataServices;
using DataAccessLayer.DataObjects;
using KarveCommon;
using KarveCommon.Services;
using Prism.Regions;
using Prism.Commands;
using KarveDataServices.DataObjects;
using System.Net;
using ProvidersModule.Views;
using System.Windows.Controls;
using Dragablz;
using System.Windows;
using System.Text.RegularExpressions;
using Microsoft.Practices.Unity;

namespace ProvidersModule.ViewModels
{
    public class ProvidersControlViewModel : BindableBase, IProvidersViewModel
    {

        /// <summary>
        ///  Type of payment data services.
        /// </summary>
        private IEventManager _eventManager;
        private IConfigurationService _configurationService;
        private IRegionManager _regionManager;
        private DataTable _supplierDataTable;
        private ISupplierDataInfo _lastDataObject = null;
        private ISupplierDataInfo _dataObjectInfo = new SupplierInfoDataObject();
        private ISupplierTypeData _dataObjectType = new SupplierTypeDataObject();
        
        public ICommand SupplierSearchSelection { set; get; }
        public ICommand SupplierSearchCommand { set; get; }
        public ICommand SupplierSearchCountryCommand { set; get; }
        public ICommand SupplierSearchProvinceCommand { set; get; }
        public ICommand ClickSearchCountryCode { set; get; }
        public ICommand ClickSearchMainAddressCommand { set; get; }
        public ICommand SelectedIndexCommand { set; get; }
        public ICommand ClickSearchWebAddressCommand { set; get; }
        public ICommand CommandUpdateNotes { set; get; }
        public DelegateCommand<string> NavigateCommand { get; set; }
        private string _supplierSearchType = TabViewModelBase.NUMBER;
        private ISupplierPayload _supplierPayload;
        private string _title = ""; 
        private DataTable _extendedSupplierDataTable;
        private IDataServices _dataServices;
        private ICommand _openItemCommand;
        private IUnityContainer _container;

        public ProvidersControlViewModel(IConfigurationService configurationService,
                                  IUnityContainer container,
                                  IRegionManager regionManager,
                                  IDataServices services,
                                  IEventManager eventManager)
        {
            _configurationService = configurationService;
            _eventManager = eventManager;
            _regionManager = regionManager;
            _dataServices = services;
            _container = container;
            _extendedSupplierDataTable = new DataTable();
            _openItemCommand = new DelegateCommand<object>(openCurrentItem);
            NavigateCommand = new DelegateCommand<string>(Navigate);
            _supplierSearchType = TabViewModelBase.NUMBER;
            StartDataLayer();
        }
        
        public DataTable SummaryView
        {
            get { return _extendedSupplierDataTable;  }
           
        }
        
        private async void StartDataLayer()
        {
            ISupplierDataServices supplier = _dataServices.GetSupplierDataServices();
            DataSet set = await supplier.GetAsyncCompleteSummary();
            if (set.Tables.Count > 0)
            {
                _extendedSupplierDataTable = set.Tables[0];
                RaisePropertyChanged("SummaryView");
            }
        }
        private void UpdateNotes(object value)
        {

            SupplierNotesEdit(value);
        }
        /// <summary>
        ///  This launches the google map.
        /// </summary>
        /// <param name="value"></param>
        private void LaunchMailClient(object value)
        {
            if (value != null)
            {
                string email = value as string;
                string emailUrl = "mailto:" + email + "?subject=KarveCar";

                System.Diagnostics.Process.Start(emailUrl);
            }
        }
        private void LaunchGoogleMap(object value)
        {

        }
        /// <summary>
        /// This method provide a method to select to  search by code or by type
        /// </summary>
        /// <param name="param"></param>
        private void SupplierSearch(object param)
        {
            ComboBoxItem item = param as ComboBoxItem;
            _supplierSearchType = item.Content as string;

        }
        private void LaunchWebBrowser(object value)
        {
            if (value != null)
            {
                string webBrowser = value as string;
                if (webBrowser.Length > 0)
                {

                    System.Diagnostics.Process.Start(webBrowser);
                }
            }
        }

        public string Title
        {
            set
            {
                this._title = value;
                RaisePropertyChanged();
            }
            get
            {
                return _title;
            }
        }

        public async void  openCurrentItem(object currentItem)
        {
            ISupplierInfoView view = _container.Resolve<ISupplierInfoView>();
            DataRowView local = currentItem as DataRowView;
            string lastSupplierId = local.Row.ItemArray[0] as string;
            string name = local.Row.ItemArray[1] as string;
            string nif = local.Row.ItemArray[2] as string;
            ISupplierDataServices supplierDataServices = _dataServices.GetSupplierDataServices();
             _lastDataObject = await supplierDataServices.GetAsyncSupplierDataObjectInfo(lastSupplierId);
            _lastDataObject.Name = name;
            _lastDataObject.Nif = nif;
            _lastDataObject.Number = lastSupplierId;
            ISupplierPayload supplierDataPayLoad = new SupplierDataPayload();
            supplierDataPayLoad.SupplierDataObjectInfo = _lastDataObject;
            if (_lastDataObject.Type != null)
            {
                supplierDataPayLoad.SupplierDataObjectType = await supplierDataServices.GetAsyncSupplierTypesDataObject((string)_lastDataObject.Type);

            }
            else
            {
                supplierDataPayLoad.SupplierDataObjectType = null;
            }
            supplierDataPayLoad.SupplierSummaryDataTable = _extendedSupplierDataTable;
            // notify the view model and add the view
            DataPayLoad payload = new DataPayLoad();
            payload.DataObject = supplierDataPayLoad;
            _eventManager.notifyObserverSubsystem("ProviderModule", payload);
            _configurationService.AddMainTab(view,"Proveedor "+ _lastDataObject.Name);
        }
        public ItemActionCallback ClosingTabItemHandler
        {
            get { return ClosingTabItemHandlerImpl; }
        }
        /// <summary>
        ///  this is useful for not closing suppliers.
        /// </summary>
        /// <param name="args"></param>
        private static void ClosingTabItemHandlerImpl(ItemActionCallbackArgs<TabablzControl> args)
        {
            //in here you can dispose stuff or cancel the close
            string tabName = args.DragablzItem.Content as string;
          if (tabName.Contains(ViewModels.TabViewModelBase.SUPPLIERS))
           {
                args.Cancel();
           }
           
        }
        /// <summary>
        ///  This method provide a way to execute the search using the code or the type.
        /// </summary>
        /// <param name="param"></param>
        private void SupplierSearchExecute(object param)
        {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("Command", "Search");
            if ((_supplierSearchType != TabViewModelBase.NUMBER) && (_supplierSearchType != TabViewModelBase.TYPE))
            {
                _supplierSearchType = TabViewModelBase.NUMBER;
            }
            navigationParameters.Add("SearchType", _supplierSearchType);
            navigationParameters.Add("Payload", _supplierPayload);
            _regionManager.RequestNavigate("TabRegion", "GenericGridView", navigationParameters);

        }
        /// <summary>
        /// This method provide a way to search by country
        /// </summary>
        /// <param name="param"></param>
        private void SupplierNotesEdit(object param)
        {
            _supplierSearchType = TabViewModelBase.NOTES;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("Command", "Search");
            navigationParameters.Add("SearchType", _supplierSearchType);
            navigationParameters.Add("Notes", _supplierPayload);
            _regionManager.RequestNavigate("TabRegion", "BasicEditorView", navigationParameters);

        }
        /// <summary>
        /// This method provide a way to search by country
        /// </summary>
        /// <param name="param"></param>
        private void SupplierSearchByCountry(object param)
        {
            _supplierSearchType = TabViewModelBase.COUNTRIES;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("Command", "Search");
            navigationParameters.Add("SearchType", _supplierSearchType);
            navigationParameters.Add("Payload", _supplierPayload);
            _regionManager.RequestNavigate("TabRegion", "GenericGridView", navigationParameters);
         
        }
        /// <summary>
        /// 
        /// </summary>
        private void SupplierSearchByProvince(object param)
        {
            _supplierSearchType = TabViewModelBase.PROVINCES;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("Command", "Search");
            navigationParameters.Add("SearchType", _supplierSearchType);
            navigationParameters.Add("Payload", _supplierPayload);
            _regionManager.RequestNavigate("TabRegion", "GenericGridView", navigationParameters);
        }
        public ICommand OpenItem
        {
            get { return _openItemCommand; }
            set { _openItemCommand = value; }
        }
        public DataTable SummaryDataTable
        {
            set { _supplierDataTable = value; RaisePropertyChanged(); }
            get { return _supplierDataTable; }
        }

        public ISupplierTypeData SupplierDataObjectType
        {
            get
            {
                return _dataObjectType;
            }
            set
            {
                _dataObjectType = value;
                RaisePropertyChanged("SupplierDataObjectType");
            }
        }
        public ISupplierDataInfo SupplierDataObjectInfo
        {
            get
            {
                return _dataObjectInfo;
            }
            set
            {
                _dataObjectInfo = value;
                RaisePropertyChanged("SupplierDataObjectInfo");
            }
        }


        
        public void Navigate(string navigationPath)
        {
            _supplierSearchType = TabViewModelBase.SUPPLIERS;
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("Command", "Search");
            navigationParameters.Add("SearchType", _supplierSearchType);
            navigationParameters.Add("Payload", _supplierPayload);
            _regionManager.RequestNavigate("TabRegion", navigationPath, navigationParameters);
        }

        
    }
}
