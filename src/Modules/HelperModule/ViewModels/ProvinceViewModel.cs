using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Regions;
using Syncfusion.Windows.PdfViewer;

namespace HelperModule.ViewModels
{
    class ProvinceViewModel: GenericHelperViewModel<ProvinciaDto, PROVINCIA>
    {
        private HelperLoader<CountryDto, Country> _loader;
        private IEnumerable<CountryDto> _countryDto;
        /// <summary>
        /// 
        ///  ProvinceViewModel
        /// </summary>
        /// <param name="dataServices">DataServices testing</param>
        /// <param name="region">Region </param>
        /// <param name="manager"> event manager to send and put messages.</param>
        public ProvinceViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(
            string.Empty, dataServices, region, manager)
        {
            LoadAllCountries();
            AssistCountryCommand = new DelegateCommand<object>(OnAssistCountryCommand);
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperProvince;
        }

        private void OnAssistCountryCommand(object obj)
        {
            if (_loader != null)
            {
                _loader.LoadAll();
                CountryDto = _loader.HelperView;
            }
        }

        private void LoadAllCountries()
        {
            
            _loader = new HelperLoader<CountryDto, Country>(DataServices);
            CountryDto = _loader.HelperView;
            _loader.LoadAll();
            var list = from country in _loader.HelperView
                from province in HelperView
                where province.Country == country.Code
                select new ProvinciaDto() { Name= province.Name,
                                            Code = province.Code,
                                            Country = province.Country,
                                            Capital = province.Capital,
                                            Prefix = province.Prefix,
                                            CountryValue = new CountryDto()
                                            {
                                                Code = country.Code,
                                                CountryName = country.CountryName
                                            } };
            HelperView = new ObservableCollection<ProvinciaDto>(list);
        }

        public IEnumerable<CountryDto> CountryDto
        {
            set { _countryDto = value; RaisePropertyChanged();}
            get { return _countryDto; }
        }
        public ICommand AssistCountryCommand { set; get; }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            ProvinciaDto dto = payLoad.DataObject as ProvinciaDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ProvinciaDto, PROVINCIA>(dto);
                dto.Code = codeId.Substring(0, 3);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
