using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using KarveDataServices;
using KarveCommon;
using KarveCommon.Services;
using Prism.Regions;

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
        private IRegionManager _regionManager;
       
        public ICommand ClickSearchCommnd { set; get; }
        public ICommand ClickSearchCountryCodeCommand { set; get; }
        public ICommand ClickSearchCountryCommand { set; get; }
        public ICommand ClickSearchMainAddressCommand { set; get; }

        public DataTable SummaryDataTable {
            set { _supplierDataTable = value; RaisePropertyChanged(); }
            get { return _supplierDataTable; }
        }

        public ProvidersViewModel(ICareKeeperService careKeeperService, 
                                  IDataServices dataServices,
                                  IConfigurationService configurationService)
        {
            _dataServices = dataServices;
            _careKeeperService = careKeeperService;
            _configurationService = configurationService;
            StartDataLayer();
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
