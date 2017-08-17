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
        public ICommand ClickSearchCommnd { set; get; }
        public ICommand ClickSearchCountryCodeCommand { set; get; }
        public ICommand ClickSearchCountryCommand { set; get; }
        public ICommand ClickSearchMainAddressCommand { set; get; }
        public ICommand SelectedIndexCommand { set; get; }
        public DelegateCommand<string> NavigateCommand { get; set; }

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


        public ProvidersControlViewModel(ICareKeeperService careKeeperService,
                                  IRegionManager regionManager,
                                  IEventManager eventManager)
        {
            _careKeeperService = careKeeperService;
            _eventManager = eventManager;
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            _eventManager.registerObserver(this);
         
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
