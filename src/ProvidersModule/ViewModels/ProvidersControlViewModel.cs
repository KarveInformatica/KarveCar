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

namespace ProvidersModule.ViewModels
{
    public class ProvidersControlViewModel : BindableBase, IProvidersViewModel, IEventObserver
    {

        /// <summary>
        ///  Type of payment data services.
        /// </summary>
        private IEventManager _eventManager;
        private ICareKeeperService _careKeeperService;
        private IRegionManager _regionManager;
        private DataTable _supplierDataTable;
        private ISupplierDataObjectInfo _dataObjectInfo = new SupplierInfoDataObject();
        private ISupplierTypeDataObject _dataObjectType = new SupplierTypeDataObject();
        public ICommand SupplierSearchSelection { set; get; }
        public ICommand SupplierSearchCommand { set; get; }
        public ICommand SupplierSearchCountryCommand { set; get; }
        public ICommand SupplierSearchProvinceCommand { set; get; }
        public ICommand ClickSearchCountryCode { set; get; }
        public ICommand SelectedIndexCommand { set; get; }
        public DelegateCommand<string> NavigateCommand { get; set; }
        private string _supplierSearchType = TabViewModelBase.SUPPLIERS;
        private ISupplierPayload _supplierPayload;
        private string _title = ""; 



        public ProvidersControlViewModel(ICareKeeperService careKeeperService,
                                  IRegionManager regionManager,
                                  IEventManager eventManager)
        {
            _careKeeperService = careKeeperService;
            _eventManager = eventManager;
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            SupplierSearchSelection = new DelegateCommand<object>(SupplierSearch);
            SupplierSearchCommand = new DelegateCommand<object>(SupplierSearchExecute);
            SupplierSearchCountryCommand = new DelegateCommand<object>(SupplierSearchByCountry);
            SupplierSearchProvinceCommand = new DelegateCommand<object>(SupplierSearchByProvince);

            _eventManager.registerObserver(this);
            _supplierSearchType = TabViewModelBase.NUMBER;
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
            navigationParameters.Add("SearchType", _supplierSearchType);
            navigationParameters.Add("Payload", _supplierPayload);
            _regionManager.RequestNavigate("TabRegion", "GenericGridView", navigationParameters);

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
        public DataTable SummaryDataTable
        {
            set { _supplierDataTable = value; RaisePropertyChanged(); }
            get { return _supplierDataTable; }
        }

        public ISupplierTypeDataObject SupplierDataObjectType
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
        public ISupplierDataObjectInfo SupplierDataObjectInfo
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

        public void incomingPayload(ISupplierPayload payload)
        {
            if (payload != null)
            {
                
                this.SupplierDataObjectInfo = payload.SupplierDataObjectInfo;
                this.SupplierDataObjectType = payload.SupplierDataObjectType;
                _supplierPayload = payload;
            }
        }
    }
}
