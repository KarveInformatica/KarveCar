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

namespace ProvidersModule.ViewModel
{
    class ProvidersViewModel : BindableBase, IProvidersViewModel
    {
        /// <summary>
        /// Data services interace
        /// </summary>
        private IDataServices _dataServices;

        /// <summary>
        ///  Type of payment data services.
        /// </summary>
        private IConfigurationService _configurationService;
        private ICareKeeperService _careKeeperService;
        private ISupplierDataServices _supplierDataServices;
        private DataTable _supplierDataTable;
        private SupplierInfoDataObject _dataObjectInfo = new SupplierInfoDataObject();

        public ICommand ClickSearchCommnd { set; get; }
        public ICommand ClickSearchCountryCodeCommand { set; get; }
        public ICommand ClickSearchCountryCommand { set; get; }
        public ICommand ClickSearchMainAddressCommand { set; get; }
        public ICommand SelectedIndexCommand { set; get; }

        public DataTable SummaryDataTable
        {
            set { _supplierDataTable = value; RaisePropertyChanged(); }
            get { return _supplierDataTable; }
        }

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
        {
            _dataServices = dataServices;
            _careKeeperService = careKeeperService;
            _configurationService = configurationService;
            this.SelectedIndexCommand = new DelegateCommand<object>(OnSelectedIndex);

            StartDataLayer();
        }
        private async void OnSelectedIndex(object param)
        {
            DataRowView local = param as DataRowView;
            if (local != null)
            {
                string supplierId = local.Row.ItemArray[0] as string;
                this.SupplierDataObjectInfo = (SupplierInfoDataObject) await _supplierDataServices.GetAsyncSupplierDataObjectInfo(supplierId);

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
