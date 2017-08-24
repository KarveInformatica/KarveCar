using KarveDataServices;
using KarveDataServices.DataObjects;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

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
        ISupplierDataObjectInfo _lastDataObject = null;
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
        private async void OnSelectedIndex(object data)
        {
            DataRowView local = data as DataRowView;
            // case base someone form a complex grid asks ok.
            // SupplierSummary
            ISupplierPayload supplierDataPayLoad = new SupplierDataPayload();
      
            if ((_supplierPayload != null) && (_supplierPayload.SupplierDataObjectInfo != null) && (_supplierPayload.SupplierDataObjectInfo.Number != null))
            {

                _lastDataObject = _supplierPayload.SupplierDataObjectInfo;

                /// TODO: replace conditional with polymorphism and go on with this.
                if ((local != null) && (local.Row.Table.TableName.Contains("SupplierInfoDataObject")))
                {
                    _lastSupplierId = local.Row.ItemArray[0] as string;
                    if (_lastDataObject != null)
                    {
                        _lastDataObject.Name = local.Row.ItemArray[1] as string;
                        _lastDataObject.Nif = local.Row.ItemArray[2] as string;
                    }
                }
                else if ((local != null) && (local.Row.Table.TableName.Contains("Country")))
                {
                    string country = local.Row.ItemArray[0] as string;
                    string countryCode = local.Row.ItemArray[1] as string;
                    if (_lastDataObject != null)
                    {
                        if (_stateChange)
                        {
                            _lastDataObject.Country = country;
                            _lastDataObject.CountryCode = countryCode;


                        }

                        _stateChange = true;
                    }
                }
                else if ((local != null) && (local.Row.Table.TableName.Contains("Prov")))
                {
                    string provincia = local.Row.ItemArray[0] as string;
                    string provinciaCode = local.Row.ItemArray[1] as string;
                    if (_lastDataObject != null)
                    {
                        if (_stateChange)
                        {
                            _lastDataObject.ProvinceCode = provinciaCode;
                            _lastDataObject.Province = provincia;
                        }
                        _stateChange = true;
                    }
                }
                else if ((local != null) && (local.Row.Table.TableName.Contains("SupplierType")))

                {
                    string s=local.Row.ItemArray[2] as string;
                    supplierDataPayLoad.SupplierDataObjectType = await _supplierDataServices.GetAsyncSupplierTypesDataObject(s);
                }
                else if ((local != null) && (local.Row.Table.TableName.Contains("ExtendedSummary")))
                {
                    _lastSupplierId = local.Row.ItemArray[0] as string;
                    string name = local.Row.ItemArray[1] as string;
                    string nif = local.Row.ItemArray[2] as string;
                    _lastDataObject = await _supplierDataServices.GetAsyncSupplierDataObjectInfo(_lastSupplierId);
                    _lastDataObject.Name = name;
                    _lastDataObject.Nif = nif;
                    _lastDataObject.Number = _lastSupplierId;
                    supplierDataPayLoad.SupplierDataObjectInfo = _lastDataObject;

                    if (_lastDataObject.Type != null)
                    {
                        supplierDataPayLoad.SupplierDataObjectType = await _supplierDataServices.GetAsyncSupplierTypesDataObject((string)_lastDataObject.Type);

                    }
                    else
                    {
                        supplierDataPayLoad.SupplierDataObjectType = null;
                    }
                   

                }

                supplierDataPayLoad.SupplierDataObjectInfo = _lastDataObject;
                _manager.notifyObserver(supplierDataPayLoad);
            }
        }


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
        /// <summary>
        ///  This method list the in asynchronous way
        /// </summary>
        private async void ListByNumber()
        {
            try
            {

                _supplierDataServices = _dataServices.GetSupplierDataServices();
                if (_supplierDataServices != null)
                {
                    DataSet dataSet = await _supplierDataServices.GetAsyncCompleteSummary();
                    if ((dataSet != null) && (dataSet.Tables.Count > 0))
                    {
                        this.GenericDataTable = dataSet.Tables[0];
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;


            }
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
                    case TabViewModelBase.COUNTRIES: ListByCountryOrProvince("Country"); break;
                    case TabViewModelBase.PROVINCES: ListByCountryOrProvince("Prov"); break;
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
            try
            {

                _supplierDataServices = _dataServices.GetSupplierDataServices();
                if (_supplierDataServices != null)
                {
                    DataSet dataSet = await _supplierDataServices.GetAsyncAllProviderTypes();
                    if ((dataSet != null) && (dataSet.Tables.Count > 0))
                    {

                        this.GenericDataTable = dataSet.Tables[0];
                    }
                }

            }
            catch (Exception e)
            {
                throw e;

            }
        }

    }
}
