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
        public ICommand ClickSearchCountryCode { set; get; }
        public ICommand SelectedIndexCommand { set; get; }
        public DelegateCommand<string> NavigateCommand { get; set; }
        private string _supplierSearchType;



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
            _eventManager.registerObserver(this);

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
        /// <summary>
        ///  This method provide a way to execute the search using the code or the type.
        /// </summary>
        /// <param name="param"></param>
        private void SupplierSearchExecute(object param)
        {
            if (_supplierSearchType == "Tipo")
            {
              //  var parms = new NavigationParameters
               // _regionManager.RequestNavigate("TabRegion", navigationPath, );
            }
        }
        /// <summary>
        /// This method provide a way to search by country
        /// </summary>
        /// <param name="param"></param>
        private void SupplierSearchByCountry(object param)
        {

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
           
            _regionManager.RequestNavigate("TabRegion", navigationPath);
        }

        public void incomingPayload(ISupplierPayload payload)
        {
            this.SupplierDataObjectInfo = payload.SupplierDataObjectInfo;
            this.SupplierDataObjectType = payload.SupplierDataObjectType;
        }
    }
}
