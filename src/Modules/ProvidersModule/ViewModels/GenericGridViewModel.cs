using KarveDataServices;
using KarveDataServices.DataObjects;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Data;
using System.Windows;
using System.Windows.Input;
using KarveCommon.Services;

namespace ProvidersModule.ViewModels
{
    class GenericGridViewModel : TabViewModelBase
    {

        private DataTable _dataTable = new DataTable();
        private IEventManager _manager;
        private IDataServices _dataServices;
        private ISupplierDataServices _supplierDataServices;
        public ICommand SelectedIndexCommand { set; get; }
        private string _lastSupplierId;
        ISupplierDataInfo _lastDataObject = null;
        ISupplierPayload _supplierPayload;
        private bool _stateChange;
        /// <summary>
        /// GenericVirel
        /// </summary>
        /// <param name="eventManager"></param>
        public GenericGridViewModel(IEventManager eventManager,
            IDataServices dataServices)
        {
            _manager = eventManager;
            _dataServices = dataServices;
            _supplierDataServices = _dataServices.GetSupplierDataServices();

            _stateChange = false;
            _lastSupplierId = "1";
            SelectedIndexCommand = new DelegateCommand<object>(OnSelectedIndex);


        }
        public DataTable GenericDataTable
        {
            set
            {
                _dataTable = value;
                RaisePropertyChanged();
            }
            get
            {
                return _dataTable;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void OnSelectedIndex(object data)
        {
         
        }

        /*
        private async void ListByCountryOrProvince(string param)
        {
            try
            {

                IHelperDataServices dataServices = _dataServices.GetHelperDataServices();
                if (dataServices != null)
                {
                    DataSet dataSet = await dataServices.GetAsyncCountriesAndProvinces();
                    if ((dataSet != null) && (dataSet.Tables.Count > 0))
                    {
                        foreach (DataTable dt in dataSet.Tables)
                        {
                            if (dt.TableName.Contains(param))
                            {
                                this.GenericDataTable = dt;
                                break;
                            }
                        }
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
        }
        */
        /// <summary>
        ///  This method list the in asynchronous way
        /// </summary>
        private async void ListByNumber()
        {
           
        }

        /// <summary>
        ///  This is the method that
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        /// <summary>
        ///  This method provides a way to navigate from the ProviddersControlViewModel and adding a new tab when finished.
        /// </summary>
        /// <param name="navigationContext">The needed naviagation context.</param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            // here comes the navigation parameters from the other view. 
            NavigationParameters par = navigationContext.Parameters;
            string commandName = par["Command"] as string;
         
            if (commandName == "Search")
            {
                string searchNumber = par["SearchType"] as string;
                switch (searchNumber)
                {
                    case TabViewModelBase.NUMBER: ListByNumber(); break;
                    case TabViewModelBase.TYPE: ListByType(); break;
           //         case TabViewModelBase.COUNTRIES: ListByCountryOrProvince("Country"); break;
          //          case TabViewModelBase.PROVINCES: ListByCountryOrProvince("Prov"); break;
                }


            }
            _stateChange = false;
            _supplierPayload = par["Payload"] as ISupplierPayload;

            // navigationParameters.Add("Payload", _supplierPayload);
        }
        /// <summary>
        ///  This method create asynchronously the list of the type of providers.
        /// </summary>
        private async void ListByType()
        {
           
        }

    }
}
