using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Regions;
using Syncfusion.UI.Xaml.Grid;

namespace HelperModule.ViewModels
{
    /// <summary>
    /// ResellerViewModel. This is a reseller for the view model.
    /// </summary>
    class ResellersViewModel : DirectionBaseViewModel<ResellerDto, VENDEDOR>
    {
        private IEnumerable<CityDto> _resellerDto = new IncrementalList<CityDto>(LoadMoreCities);

        private static void LoadMoreCities(uint arg1, int arg2)
        {
          
        }

        private IEnumerable<CountryDto> _resellerCountryDto = new IncrementalList<CountryDto>(LoadMoreCountries);

        private static void LoadMoreCountries(uint arg1, int arg2)
        {
          
        }

        private IEnumerable<ProvinciaDto> _resellerProvinceDto = new IncrementalList<ProvinciaDto>(LoadMoreProvices);

        private static void LoadMoreProvices(uint arg1, int arg2)
        {

        }

        public ResellersViewModel(string query, IDataServices dataServices, IRegionManager region, IEventManager manager) : base(query, dataServices, region, manager)
        {
        }

        public override void AssistComplete(object sender, PropertyChangedEventArgs e)
        {
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            return new DataPayLoad();
        }

        /*

        public ResellersViewModel(string query, IDataServices dataServices, IRegionManager region, IEventManager manager) : base(
        {
            _resellerDto= new IncrementalList<CityDto>(LoadMoreCities);

        }
        private void LoadMoreCountries(uint baseIndex, int pageIndex)
        {
            _cityLoader.LoadPaged(pageIndex, 500);
            throw new NotImplementedException();
        }

        private  void LoadMoreCities(uint arg1, int arg2)
        {
            throw new NotImplementedException();
        }
        private static void LoadMoreProvices(uint arg1, int arg2)
        {
            throw new NotImplementedException();
        }
       

        private HelperLoader<CityDto, POBLACIONES> _cityLoader;
        private HelperLoader<ProvinciaDto, PROVINCIA> _provinceLoader;
        private HelperLoader<CountryDto, Country> _countryLoader;


        /// <summary>
        ///  ResellerCityDto
        /// </summary>
        public IncrementalList<CityDto> ResellerCityDto
        {
            get { return _resellerDto; }
            set { _resellerDto = value; RaisePropertyChanged(); }
        }
        /// <summary>
        /// ResellerCountryDto
        /// </summary>
        public IncrementalList<CountryDto> ResellerCountryDto
        {
            get { return _resellerCountryDto; }
            set { _resellerCountryDto = value; RaisePropertyChanged();}
        }
        /// <summary>
        ///  ResellerProvinceDto
        /// </summary>
        public IncrementalList<ProvinciaDto> ResellerProvinceDto {
            get { return _resellerProvinceDto; }
            set { _resellerProvinceDto = value; RaisePropertyChanged();}
        }
        /// <summary>
        /// ReselleersViewModel
        /// </summary>
        /// <param name="dataServices">DataServices</param>
        /// <param name="region">Region</param>
        /// <param name="manager">Event Manager</param>
        public ResellersViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(string.Empty, dataServices, region, manager)
        {
            AssistCommand = new DelegateCommand<object>(HandleAssistToGoalJuve1Barca0);
            _cityLoader = new HelperLoader<CityDto, POBLACIONES>(dataServices);
            _countryLoader = new HelperLoader<CountryDto, Country>(dataServices);
            _provinceLoader = new HelperLoader<ProvinciaDto, PROVINCIA>(dataServices);
            InitLoadHelpers();
            // set the helpers in the dto.
            SetHelperInFistDto();
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperReseller;


        }

        private void SetHelperInFistDto()
        {
            var tmp = HelperDto;
            var collection = from city in ResellerCityDto
                where city.Code == tmp.City.Code
                select city;
            var cityValue = collection.FirstOrDefault();
            if (cityValue != null)
            {
                tmp.City = cityValue;
            }
            var collectionCountry = from country in ResellerCountryDto
                where country.Code == tmp.Country.Code
                select country;
            var countryValue = collectionCountry.FirstOrDefault();
            if (countryValue != null)
            {
                tmp.Country = countryValue;
            }
            var tmpProvinceDtos = from province in ResellerProvinceDto
                where province.Code == tmp.Province.Code
                select province;
            var provinceValue = tmpProvinceDtos.FirstOrDefault();
            if (provinceValue != null)
            {
                tmp.Province = provinceValue;
            }
            HelperDto = tmp;
        }
        private  void InitLoadHelpers()
        {
            _cityLoader.LoadAll();
            ResellerCityDto = _cityLoader.HelperView;
            _countryLoader.LoadAll();
            ResellerCountryDto = _countryLoader.HelperView;
            _provinceLoader.LoadAll();
            ResellerProvinceDto = _provinceLoader.HelperView;
            HelperView = SetHelperData(HelperView, ResellerCityDto, ResellerCountryDto, ResellerProvinceDto);
        }

        private ObservableCollection<ResellerDto> SetHelperData(IncrementalList<ResellerDto> resellerDtos,
                                   IEnumerable<CityDto> cityDtos, 
                                   IEnumerable<CountryDto> countryDtos, 
                                   IEnumerable<ProvinciaDto> provinceDtos)
        {
         
            return resellerDtos;
        }
        /// <summary>
        ///  This assist goes to goal and Juventus F.C. will win the match agains Barcelona. Bored Friday!
        /// </summary>
        /// <param name="obj">The command aparameters.</param>
        private void HandleAssistToGoalJuve1Barca0(object obj)
        {
            OnAssistAsync(obj);
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            ResellerDto dto = payLoad.DataObject as ResellerDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ResellerDto,VENDEDOR>(dto);
                dto.Name = codeId.Substring(0, 7);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }

        public override void AssistComplete(object sender, PropertyChangedEventArgs e)
        {
            if (GenericCountryDto != null)
            {
                ResellerCountryDto = GenericCountryDto;
            }
            if (GenericCityDto != null)
            {
                ResellerCityDto = GenericCityDto;
            }
            if (GenericProvinciaDto != null)
            {
                ResellerProvinceDto = GenericProvinciaDto;
            }
          
    
        }
        */
    }
}
