using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
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
    class CitiesViewModel: GenericHelperViewModel<CityDto, POBLACIONES>
    {
      
        private IEnumerable<CityCountryDto> _cityCountryDto = new ObservableCollection<CityCountryDto>();
        private static long _gridIdentifier = 0;
        private ObservableCollection<CountryDto> _countryCities;
        private HelperLoader<CountryDto, Country> _countryDto;
        private HelperLoader<CityDto, POBLACIONES> _cityDto;
        private IAssistDataService _assistDataService;
        /// <summary>
        ///  CitiesViewModel
        /// </summary>
        /// <param name="dataServices">DataService</param>
        /// <param name="region">Region</param>
        /// <param name="manager">EventManager</param>
        public CitiesViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService service) : base(String.Empty, dataServices, region, manager, service)
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

        public ObservableCollection<CountryDto> CountryCitiesDto
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
            IEnumerable<CountryDto> countries = await helperData.GetMappedAllAsyncHelper<CountryDto, Country>();
            IncrementalList<CityDto> cities = HelperView;
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
            CityDto dto = payLoad.DataObject as CityDto;
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();

            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CityDto, POBLACIONES>(dto);
                dto.Code = codeId.Substring(0, 3);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }

       
    }
}
