using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prism.Mvvm;
using KarveDataServices;
using DataAccessLayer.DataObjects;
using KarveCommon;
using KarveCommon.Services;
using Prism.Regions;
using System.Windows.Input;
using Prism.Commands;
using KarveDataServices.DataObjects;
using KarveCommon.Services;

namespace ProvidersModule.ViewModels
{
    public class BasicEditorViewModel: TabViewModelBase
    {
        private IDataServices _dataServices;
        private DataTable _supplierDataTable;
        private readonly IRegionManager _regionManager;
        public ICommand SelectedIndexCommand { set; get; }
        private IEventManager _eventManager;
       
        private SupplierInfoDataObject _dataObjectInfo = new SupplierInfoDataObject();

        public ICommand ClickSearchCommnd { set; get; }
        public ICommand ClickSearchCountryCodeCommand { set; get; }
        public ICommand ClickSearchCountryCommand { set; get; }
        public ICommand ClickSearchMainAddressCommand { set; get; }
        public ICommand SelectedIndexCommand { set; get; }

>>>>>>> c60ce6a463ef7310a6ea6ca508daeb4b9d8a6929:src/ProvidersModule/ViewModel/ProvidersViewModel.cs
        public DataTable SummaryDataTable
        {
            set { _supplierDataTable = value; RaisePropertyChanged(); }
            get { return _supplierDataTable; }
        }

<<<<<<< HEAD:src/ProvidersModule/ViewModels/SupplierViewModel.cs
    
        public SupplierViewModel(IRegionManager manager, IDataServices dataServices, IEventManager ev)
=======
       SupplierInfoDataObject SupplierDataObjectInfo
        {
            get
            {
                return _dataObjectInfo;
            }
            set
            {
                _dataObjectInfo = value;
                RaisePropertyChanged("SupplierInfoDataObject");
            }
        }

      
        public ProvidersViewModel(ICareKeeperService careKeeperService,
                                  IDataServices dataServices,
                                  IConfigurationService configurationService)
>>>>>>> c60ce6a463ef7310a6ea6ca508daeb4b9d8a6929:src/ProvidersModule/ViewModel/ProvidersViewModel.cs
        {
             Title = "Proveedores";
            _dataServices = dataServices;
            _regionManager = manager;
            _eventManager = ev;
            SelectedIndexCommand = new DelegateCommand<object>(OnSelectedIndex);
            StartDataLayer();
        }
        private async void OnSelectedIndex(object param)
        {
            DataRowView local = param as DataRowView;
            
            if (local != null)
            {
                string supplierId = local.Row.ItemArray[0] as string;
<<<<<<< HEAD:src/ProvidersModule/ViewModels/SupplierViewModel.cs
                string name = local.Row.ItemArray[1] as string;
                string nif = local.Row.ItemArray[2] as string;

                ISupplierDataObjectInfo dataObject = await _supplierDataServices.GetAsyncSupplierDataObjectInfo(supplierId);
                dataObject.Name = name;
                dataObject.Nif = nif;
                dataObject.Number = supplierId;
                ISupplierPayload supplierDataPayLoad = new SupplierDataPayload();

                supplierDataPayLoad.SupplierDataObjectInfo = dataObject;

                if (dataObject.Type != null)
                {
                    supplierDataPayLoad.SupplierDataObjectType = await _supplierDataServices.GetAsyncSupplierTypesDataObject((string)dataObject.Type);

                }
                else
                {
                    supplierDataPayLoad.SupplierDataObjectType = null;
                }
                _eventManager.notifyObserver(supplierDataPayLoad);
=======
                this.SupplierDataObjectInfo = (SupplierInfoDataObject) await _supplierDataServices.GetAsyncSupplierDataObjectInfo(supplierId);

>>>>>>> c60ce6a463ef7310a6ea6ca508daeb4b9d8a6929:src/ProvidersModule/ViewModel/ProvidersViewModel.cs
            }

        }
        private async void StartDataLayer()
        {
            try
            {

                _supplierDataServices = _dataServices.GetSupplierDataServices();
                if (_supplierDataServices != null)
                {
                    DataSet dataSet = await _supplierDataServices.GetAsyncAllSupplierSummary();
                    this.SummaryDataTable = dataSet.Tables[0];
                }

            }
            catch (Exception e)
            {


                //        ShowError(e, "Error during data loading");
            }
        }
<<<<<<< HEAD:src/ProvidersModule/ViewModels/SupplierViewModel.cs
=======


>>>>>>> c60ce6a463ef7310a6ea6ca508daeb4b9d8a6929:src/ProvidersModule/ViewModel/ProvidersViewModel.cs
    }
}
