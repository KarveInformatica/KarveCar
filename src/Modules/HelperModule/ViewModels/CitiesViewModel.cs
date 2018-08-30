using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;
using System.Windows.Input;
using Prism.Commands;
using Syncfusion.UI.Xaml.Grid;
using KarveCommonInterfaces;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  View model that contains the cities.
    /// </summary>
    class CitiesViewModel: GenericHelperViewModel<CityViewObject, POBLACIONES>
    {
      
        private IEnumerable<CityCountryDto> _cityCountryDto = new ObservableCollection<CityCountryDto>();
        private static long _gridIdentifier = 0;
        private ObservableCollection<CountryViewObject> _countryCities;
        private HelperLoader<CountryViewObject, Country> _countryDto;
        private HelperLoader<CityViewObject, POBLACIONES> _cityDto;
        private IAssistDataService _assistDataService;
        /// <summary>
        ///  CitiesViewModel
        /// </summary>
        /// <param name="dataServices">DataService</param>
        /// <param name="region">Region</param>
        /// <param name="manager">EventManager</param>
        public CitiesViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService service, IConfigurationService config) : base(String.Empty, dataServices, region, manager, service, config)
        {
            AssistCommand = new DelegateCommand<object>(OnAssistRequest);
            if (_gridIdentifier == 0)
            {
                _gridIdentifier = GenerateGridId();
            }
            _assistDataService = dataServices.GetAssistDataServices();
            GridIdentifier = _gridIdentifier;
        }

        private void OnAssistRequest(object obj)
        {
         
        }

        public ObservableCollection<CountryViewObject> CountryCitiesDto
        {
            get { return _countryCities; }
            set { _countryCities = value; RaisePropertyChanged(); }
                
        }
        /// <summary>
        ///  CityCountryDto
        /// </summary>
        /// <param name="obj"></param>
        public async void OnCityCountry(object obj)
        {
            IHelperDataServices helperData = DataServices.GetHelperDataServices();
            IEnumerable<CountryViewObject> countries = await helperData.GetMappedAllAsyncHelper<CountryViewObject, Country>();
            IncrementalList<CityViewObject> cities = HelperView;
            CityCountryDto = from l in countries
                from r in cities
                where l.CountryCode == r.Country.CountryCode
                select new CityCountryDto() {City = r, Country = l};
        }
     

        /// <summary>
        ///  Update.
        /// </summary>
        protected override void Update()
        {
            HelperView = LoadView();
            PreviousValue = CurrentValue;
            CurrentValue = HelperView.FirstOrDefault();
        }
        /// <summary>
        ///  CityCountryDto
        /// </summary>
        public IEnumerable<CityCountryDto> CityCountryDto
        {
            set { _cityCountryDto = value; RaisePropertyChanged();}
            get { return _cityCountryDto; }
        }
        /// <summary>
        ///  Set the code for the city country
        /// </summary>
        /// <param name="payLoad">Kind of payload</param>
        /// <param name="dataServices">DataService</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            CityViewObject viewObject = payLoad.DataObject as CityViewObject;
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();

            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CityViewObject, POBLACIONES>(viewObject);
                viewObject.Code = codeId.Substring(0, 3);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }

       
    }
}
