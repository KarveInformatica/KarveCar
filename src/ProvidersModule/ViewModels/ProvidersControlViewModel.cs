using System.Data;
using System.Windows.Input;
using Prism.Mvvm;
using KarveDataServices;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using Prism.Regions;
using Prism.Commands;
using KarveDataServices.DataObjects;
using System.Windows.Controls;
using Dragablz;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProvidersModule.ViewModels
{
    public class ProvidersControlViewModel : BindableBase, IProvidersViewModel
    {

        /// <summary>
        ///  Type of payment data services.
        /// </summary>
        private IEventManager _eventManager;
        private IConfigurationService _configurationService;
        private ISupplierDataInfo _lastDataObject = null;
        private DataTable _extendedSupplierDataTable;
        private IDataServices _dataServices;
        private ICommand _openItemCommand;
        private IUnityContainer _container;

        public ProvidersControlViewModel(IConfigurationService configurationService,
                                  IUnityContainer container,
                                  IDataServices services,
                                  IEventManager eventManager)
        {
            _configurationService = configurationService;
            _eventManager = eventManager;
            _container = container;
            _dataServices = services;
            _extendedSupplierDataTable = new DataTable();
            _openItemCommand = new DelegateCommand<object>(openCurrentItem);
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
        public async void openCurrentItem(object currentItem)
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
            // fire up the view
            _configurationService.AddMainTab(view, supplierDataPayLoad.SupplierDataObjectInfo.Name);
            DataPayLoad registrationPayload = new DataPayLoad();
            string routedName = "ProviderModule:" + supplierDataPayLoad.SupplierDataObjectInfo.Name;
            registrationPayload.PayloadType = DataPayLoad.Type.RegistrationPayload;
            registrationPayload.Registration = routedName;
            _eventManager.notifyObserverSubsystem("ProviderModule", registrationPayload);
            IDictionary<string, object> param = new Dictionary<string, object>();
            param["supplierId"] = _lastDataObject.Number;
            DataPayLoad currentPayload = await LoadData(_dataServices, param);

            DataPayLoad payload = new DataPayLoad();
            payload.DataObject = supplierDataPayLoad;
            _eventManager.notifyObserverSubsystem(routedName, payload);    
        }
        public  async Task<DataPayLoad> LoadData(IDataServices services, IDictionary<string, object> data)
        {
            DataPayLoad payload = new DataPayLoad();
            string supplierId = (string)data["supplierId"];
            ISupplierDataServices supplierServices = services.GetSupplierDataServices();
            supplierServices.OpenDataSession();
            payload.DataMap[SupplierPayLoad.SupplierDOName] = await supplierServices.GetAsyncSupplierDataObjectInfo(supplierId).ConfigureAwait(false);
            payload.DataMap[SupplierPayLoad.SupplierDOType] = await supplierServices.GetAsyncSupplierTypeById(supplierId).ConfigureAwait(false);
            payload.DataMap[SupplierPayLoad.SupplierAccountingDO] = await supplierServices.GetAsyncSupplierAccountInfo(supplierId).ConfigureAwait(false);
            payload.DataMap[SupplierPayLoad.SupplierMonitoringDS] = await supplierServices.GetAsyncMonitoring(supplierId).ConfigureAwait(false);
            payload.DataMap[SupplierPayLoad.SupplierEvaluationDS] = await supplierServices.GetAsyncEvaluationNote(supplierId).ConfigureAwait(false);
            payload.DataMap[SupplierPayLoad.SupplierTransportDS] = await supplierServices.GetAsyncTransportProviderData(supplierId).ConfigureAwait(false);
            payload.DataMap[SupplierPayLoad.SupplierAssuranceDS] = await supplierServices.GetAsyncSupplierAssuranceData(supplierId).ConfigureAwait(false);
            payload.DataMap[SupplierPayLoad.SupplierVisitsDS] = await supplierServices.GetAsyncVisits(supplierId).ConfigureAwait(false);
            payload.DataMap[SupplierPayLoad.SupplierBranchesDS] = await supplierServices.GetAsyncDelegations(supplierId).ConfigureAwait(false);
            supplierServices.CloseDataSession();
            return payload;
        }
        public ICommand OpenItem
        {
            get { return _openItemCommand; }
            set { _openItemCommand = value; }
        }
       
        
    }
}
