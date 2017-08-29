using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProvidersModule.ViewModels
{
    class ProviderInfoViewModel : BindableBase, IEventObserver
    {
        public ICommand SupplierSearchSelection { set; get; }
        public ICommand SupplierSearchCommand { set; get; }
        public ICommand SupplierSearchCountryCommand { set; get; }
        public ICommand SupplierSearchProvinceCommand { set; get; }
        public ICommand ClickSearchMainAddressCommand { set; get; }
        public ICommand ClickSearchWebAddressCommand { set; get; }
        public ICommand SelectedIndexCommand { set; get; }
        public ICommand CommandUpdateNotes { set; get; }
        /// List of the commands needed
        
        public ICommand SupplierNameChangedCommand { set; get; }
        public ICommand SupplierCommonNameChangedCommand { set; get; }
        public ICommand SupplierNifChangedCommand { set; get; }
        // DO SupplierType
        public ICommand SupplierTypeCodeChangedCommand { set; get; }
        public ICommand SupplierTypeChangedCommand { set; get; }
        // SupplierInfoDataObject
        public ICommand SupplierStreetChangedCommand { set; get; }
        public ICommand SupplierCountryChangedCommand { set; get; }
        public ICommand SupplierCountryNameChangedCommand { set; get; }
        public ICommand SupplierCityChangedCommand { set; get; }
        public ICommand SupplierZipChangedCommand { set; get; }
        public ICommand SupplierProvinceCodeChangedCommand { set; get; }
        public ICommand SupplierProvinceChangedCommand { set; get; }

        public ICommand SupplierPhoneChangedCommand { set; get; }
        public ICommand SupplierCellPhoneChangedCommand { set; get; }
        public ICommand SupplierFaxChangedCommand { set; get; }
        public ICommand SupplierMailChangedCommand { set; get; }
        public ICommand SupplierWebAddressChangedCommand { set; get; }
        public ICommand SupplierNotesChangedCommand { set; get; }
        public ICommand SupplierPersonaChangedCommand { set; get; }
        public ICommand SupplierDelvieringTimeChangedCommand { set; get; }
        public ICommand PeriodTimeChangedCommand { set; get; }
        public ICommand SelectedDateChangedIVACommand { set; get; }
        public ICommand SelectedDischargedDateCommand { set; get; }
        public ICommand SelectedLeavingDateCommand { set; get; }
       


    private IEventManager _eventManager;
        private ISupplierDataInfo _dataObjectInfo;
        private DataTable _dataTable;
        private IConfigurationService _configurationService;
        private IDataServices _dataServices;
        private IUnityContainer _unityContainer;
        private ISupplierDataInfo _lastDataObject;
        private ISupplierTypeData _supplierDataObjectType;

        public ProviderInfoViewModel(
            IUnityContainer container,
            IEventManager eventManager, 
            IConfigurationService configurationService, 
            IDataServices dataServices)
        {
            _unityContainer = container;
            _dataServices = dataServices;
            _dataTable = new DataTable();
            SupplierNameChangedCommand = new DelegateCommand<object>(OnSupplierNameChanged);
            _configurationService = configurationService;
            SupplierSearchSelection = new DelegateCommand<object>(SupplierSearch);
            SupplierSearchCommand = new DelegateCommand<object>(SupplierSearchExecute);
            SupplierSearchCountryCommand = new DelegateCommand<object>(SupplierSearchByCountry);
            SupplierSearchProvinceCommand = new DelegateCommand<object>(SupplierSearchByProvince);
            ClickSearchMainAddressCommand = new DelegateCommand<object>(LaunchMailClient);
            ClickSearchWebAddressCommand = new DelegateCommand<object>(LaunchWebBrowser);
            SelectedIndexCommand = new DelegateCommand<object>(SelectProvider);
            CommandUpdateNotes = new DelegateCommand<object>(UpdateNotes);
            _eventManager = eventManager;
            _eventManager.registerObserverSubsystem("ProviderModule", this);
           
           

        }
        public void OnSupplierNameChanged(object text)
        {
            ISupplierDataInfo info = this.SupplierDataObjectInfo;
            info.Name = text as string;
            DataPayLoad dataPayload = new DataPayLoad();
            dataPayload.DataObjectName = info.GetType().Name;
            string name  = info.GetType().Name;
            dataPayload.ObjectPath = "ProviderInfo;General;" + name;
            dataPayload.PayloadType = DataPayLoad.Type.Update;
            // notifico la toolbar.
            _eventManager.notifyObserverToolBar(dataPayload);
        }
        public DataTable SummaryDataTable
        {
            get
            {
                return _dataTable;
            }
            set
            {
                _dataTable = value;
                RaisePropertyChanged("SummaryDataTable");
            }
        }

        private void UpdateWorld()
        {
            DataPayLoad payload = new DataPayLoad();
            payload.ObjectPath = "Proveedores";
            _configurationService.NotifyDataChange(payload);
        }
        private async void SelectProvider(object row)
        {
            ISupplierInfoView view = _unityContainer.Resolve<ISupplierInfoView>();
            DataRowView local = row as DataRowView;
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
            supplierDataPayLoad.SupplierSummaryDataTable = _dataTable;
            // notify the view model and add the view
            KarveCommon.Services.DataPayLoad dataPayload = new KarveCommon.Services.DataPayLoad();
            dataPayload.DataObject = supplierDataPayLoad;
            _eventManager.registerObserverSubsystem("ProvidersModule", this);
            _configurationService.AddMainTab(view, "Proveedor " + _lastDataObject.Name);
        }
        public ISupplierTypeData SupplierDataObjectType
        {
            get
            {
                return _supplierDataObjectType;
            }
            set
            {
                _supplierDataObjectType = value;
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
        private void SupplierSearch(object param)
        {}
        private void SupplierSearchExecute(object param)
        {}
        private void SupplierSearchByProvince(object param)
        {}
        private void SupplierSearchByCountry(object param)
        {}
        private void LaunchMailClient(object value)
        {
            if (value != null)
            {
                string email = value as string;
                string emailUrl = "mailto:" + email + "?subject=KarveCar";

                System.Diagnostics.Process.Start(emailUrl);
            }
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
        private void UpdateNotes(object param)
        { }

        public void incomingPayload(DataPayLoad dataPayLoad)
        {
            var dataObject = dataPayLoad.DataObject;
            ISupplierPayload payload = null;
            if (dataObject is ISupplierPayload)
            {
                payload = dataObject as ISupplierPayload;
                this.SupplierDataObjectInfo = payload.SupplierDataObjectInfo;
                this.SummaryDataTable = payload.SupplierSummaryDataTable;
                this.SupplierDataObjectType = payload.SupplierDataObjectType;
            }
            
        }
    }
}
