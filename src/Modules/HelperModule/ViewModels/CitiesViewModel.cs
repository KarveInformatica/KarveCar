using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;
using System.Windows.Input;
using DataAccessLayer.Assist;
using Prism.Commands;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;

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

        /// <summary>
        ///  CitiesViewModel
        /// </summary>
        /// <param name="dataServices">DataService</param>
        /// <param name="region">Region</param>
        /// <param name="manager">EventManager</param>
        public CitiesViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(String.Empty, dataServices, region, manager)
        {
            AssistCommand = new DelegateCommand<object>(OnCityCountry);
            AssistCountryCommand = new DelegateCommand<object>(OnCountry);
            if (_gridIdentifier == 0)
            {
                _gridIdentifier = GenerateGridId();
            }
            GridIdentifier = _gridIdentifier;
            LoadAllCountries();
            SetCurrentCountryDto();
        }

        private void SetCurrentCountryDto()
        {
            var value = CityCountryDto;
            var country = from citycountry in value
                where citycountry.City.Code == HelperDto.Code
                select citycountry;
            var cval = country.FirstOrDefault();
            if (cval != null)
            {
                PreviousValue = HelperDto;
                CurrentValue.Country = new CountryDto()
                {
                    Code = cval.Country.Code,
                    CountryCode = cval.Country.CountryCode,
                    CountryName = cval.Country.CountryName,
                    IsIntraco = cval.Country.IsIntraco,
                    Language = cval.Country.Language,
                    ShortName = cval.Country.ShortName
                };
                HelperDto = CurrentValue;

            }
        }

        /// <summary>
        ///  Country Data Trasnfer object
        /// </summary>
        /// <param name="country">Country Data Transfer object</param>
        private async void OnCountry(object country)
        {
            IHelperDataServices dataServices = DataServices.GetHelperDataServices();
            var value = await dataServices.GetMappedAllAsyncHelper<CountryDto, Country>();
            CountryCitiesDto = new ObservableCollection<CountryDto>(value);
          //  LoadAllCountries();
        }

        public ObservableCollection<CountryDto> CountryCitiesDto
        {
            get { return _countryCities; }
            set { _countryCities = value; RaisePropertyChanged(); }
                
        }
        /// <summary>
        ///  AssistCommand to be executed
        /// </summary>
        public ICommand AssistCommand { get; set; }
        /// <summary>
        ///  AssistCommand to be executed
        /// </summary>
        public ICommand AssistCountryCommand { get; set; }
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
        private void LoadAllCountries()
        {

            HelperLoader<CountryDto, Country> loader = new HelperLoader<CountryDto, Country>(DataServices);
            loader.LoadAll();
            var list = from country in loader.HelperView
                from city in HelperView
                where city.Pais == country.Code
                select new CityCountryDto()
                {
                    Code = city.Code,
                    City = city, Country = new CountryDto()
                    {
                        Code = country.Code,
                        CountryCode = country.CountryCode,
                        CountryName = country.CountryName,
                        IsIntraco = country.IsIntraco,
                        Language = country.Language,
                        ShortName = country.ShortName
                    }
                };
            CityCountryDto= new ObservableCollection<CityCountryDto>(list);

        }

        /// <summary>
        ///  Update.
        /// </summary>
        protected override void Update()
        {
            HelperView = LoadView();
            LoadAllCountries();
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
