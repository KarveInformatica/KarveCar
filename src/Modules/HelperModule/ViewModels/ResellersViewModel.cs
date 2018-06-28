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
using KarveCommonInterfaces;
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
    public class ResellersViewModel : DirectionBaseViewModel<ResellerDto, VENDEDOR>
    {
    
        private IHelperDataServices _helperDataServices;
        private IAssistDataService _assistDataService;
        private IDataServices _dataServices;
        private HelperLoader<ResellerDto, VENDEDOR> _resellerLoader;
        private HelperLoader<CityDto, POBLACIONES> _cityLoader;
        private HelperLoader<CountryDto, Country> _countryLoader;
        private HelperLoader<ProvinciaDto, PROVINCIA> _provinceLoader;
        private IEnumerable<CountryDto> _countryDtos;
        private IEnumerable<ProvinciaDto> _provinceDtos;
        private IEnumerable<CityDto> _cityDtos;

        public IEnumerable<CountryDto> ResellerCountryDto { get {
                return _countryDtos;
            }
            set
            {
                _countryDtos = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<ProvinciaDto> ResellerProvinceDto
        {
            get
            {
                return _provinceDtos;
            }
            set
            {
                _provinceDtos = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CityDto> ResellerCityDto
        {
            get
            {
                return _cityDtos;
            }
            set
            {
                _cityDtos = value;
                RaisePropertyChanged();
            }
        }
        public ResellersViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty, dataServices, region, manager, dialogService)
        {
            HelperDto = new ResellerDto();
            _dataServices = dataServices;
            _resellerLoader = new HelperLoader<ResellerDto, VENDEDOR>(dataServices);
            _cityLoader = new HelperLoader<CityDto, POBLACIONES>(dataServices);
            _countryLoader = new HelperLoader<CountryDto, Country>(dataServices);
            _provinceLoader = new HelperLoader<ProvinciaDto, PROVINCIA>(dataServices);
             GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperReseller;
        }

        private void LoadInitValues()
        {
            _resellerLoader.LoadAll();
            

            HelperView = _resellerLoader.HelperView;
        }


        protected override void OnSelectionChangedCommand(object obj)
        {
            var value = obj as ResellerDto;
            if (value != null)
            {
                HelperDto = value;
                _countryLoader.Load(value.Country.Code);
                _cityLoader.Load(value.City.Code);
                _provinceLoader.Load(value.Province.Code);
                ResellerCountryDto = _countryLoader.HelperView;
                ResellerCityDto = _cityLoader.HelperView;
                ResellerProvinceDto = _provinceLoader.HelperView;
                PreviousValue = CurrentValue;
                CurrentValue = value;
                SetHelperInFistDto();
            }

        }
        public override void AssistComplete(object sender, PropertyChangedEventArgs e)
        {
            if (sender is INotifyTaskCompletion<bool> assistCompleted)
            {
                if (assistCompleted.IsFaulted)
                {
                    DialogService?.ShowErrorMessage("Assist not completed");
                }
                else
                {
                    ResellerCityDto = GenericCityDto;
                    ResellerProvinceDto = GenericProvinciaDto;
                    ResellerCountryDto = GenericCountryDto;
                }
            }
        }

        private void SetHelperInFistDto()
        {
            var tmp = HelperDto;
            if ((tmp.City != null) && (tmp.City.Code != null))
            {
                var collection = from city in ResellerCityDto
                                 where city.Code == tmp.City.Code
                                 select city;
                var cityValue = collection.FirstOrDefault();
                if (cityValue != null)
                {
                    tmp.City = cityValue;
                }
            }
            if ((tmp.Country != null) && (tmp.Country.Code != null))
            {
                    var collectionCountry = from country in ResellerCountryDto
                                            where country.Code == tmp.Country.Code
                                            select country;
                    var countryValue = collectionCountry.FirstOrDefault();
                    if (countryValue != null)
                    {
                        tmp.Country = countryValue;
                    }
            }
            if ((tmp.Province != null) && (tmp.Province.Code != null))
            {
                var tmpProvinceDtos = from province in ResellerProvinceDto
                                      where province.Code == tmp.Province.Code
                                      select province;
                var provinceValue = tmpProvinceDtos.FirstOrDefault();

                if (provinceValue != null)
                {
                    tmp.Province = provinceValue;
                }
            }
            HelperDto = tmp;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
           ResellerDto dto = payLoad.DataObject as ResellerDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ResellerDto, VENDEDOR>(dto);
                dto.Code = codeId;
                payLoad.DataObject = dto;
            }
            return payLoad;
       }

    }
}
