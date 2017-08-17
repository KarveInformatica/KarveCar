using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prism.Mvvm;
using ProvidersModule.ViewModels;
using Prism.Regions;
using System.Windows.Input;
using Prism.Commands;
using KarveDataServices.DataObjects;
using KarveCommon.Services;

namespace ProvidersModule.ViewModels
{
    public class SupplierViewModel: TabViewModelBase
    {
        private ISupplierDataServices _supplierDataServices;
        private IDataServices _dataServices;
        private DataTable _supplierDataTable;
        private readonly IRegionManager _regionManager;
        public ICommand SelectedIndexCommand { set; get; }
        private IEventManager _eventManager;
       
        public DataTable SummaryDataTable
        {
            set { _supplierDataTable = value; RaisePropertyChanged(); }
            get { return _supplierDataTable; }
        }

    
        public SupplierViewModel(IRegionManager manager, IDataServices dataServices, IEventManager ev)
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
    }
}
