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
using KarveDataServices.ViewObjects;
using Prism.Commands;
using Prism.Regions;
using Syncfusion.Windows.PdfViewer;
using Syncfusion.UI.Xaml.Grid;
using KarveCommonInterfaces;

namespace HelperModule.ViewModels
{
    class ProvinceViewModel: GenericHelperViewModel<ProvinceViewObject, PROVINCIA>
    {
        private HelperLoader<ProvinceViewObject, PROVINCIA> _provinceLoader;
        private HelperLoader<CountryViewObject, Country> _loader;
        private IEnumerable<CountryViewObject> _countryDto;
        
        /// <summary>
        /// 
        ///  ProvinceViewModel
        /// </summary>
        /// <param name="dataServices">DataServices testing</param>
        /// <param name="region">Region </param>
        /// <param name="manager"> event manager to send and put messages.</param>
        public ProvinceViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService service, IConfigurationService config) : base(string.Empty, dataServices, region, manager, service, config)
        {
            LoadAllCountries();
            _provinceLoader = new HelperLoader<ProvinceViewObject, PROVINCIA>(dataServices);
            AssistCountryCommand = new DelegateCommand<object>(OnAssistCountryCommand);
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperProvince;
            _provinceLoader.LoadAll();
           
            HelperView = _provinceLoader.HelperView;
        }

        private void OnAssistCountryCommand(object obj)
        {
            if (_loader != null)
            {
                _loader.LoadAll();
                CountryDto = _loader.HelperView;
            }
        }
        /// <summary>
        /// Selection changed within the grid.
        /// </summary>
        /// <param name="obj"></param>
        protected override void OnSelectionChangedCommand(object obj)
        {
            var value = obj as ProvinceViewObject;
            if (value != null)
            {
                var country = _loader.LoadSingle(value.Country);
                if (country != null)
                {
                    CountryDto = new List<CountryViewObject> { country };
                    HelperDto = value;
                    HelperDto.Country = country.Code;
                    HelperDto.CountryValue = country;
                    PreviousValue = CurrentValue;
                    CurrentValue = value;
                }
            }
        }

        private void LoadAllCountries()
        {
            /* There are at most 200 countries in the world today.
             * So no incremental loading is needed. Perforance test showed up that the grid freezed 
             * after 1000 items. 
            */
            _loader = new HelperLoader<CountryViewObject, Country>(DataServices);
            CountryDto = _loader.HelperView;
            _loader.LoadAll();
            var list = from country in _loader.HelperView
                from province in HelperView
                where province.Country == country.Code
                select new ProvinceViewObject() { Name= province.Name,
                                            Code = province.Code,
                                            Country = province.Country,
                                            Capital = province.Capital,
                                            Prefix = province.Prefix,
                                            CountryValue = new CountryViewObject()
                                            {
                                                Code = country.Code,
                                                CountryName = country.CountryName
                                            } };
            HelperView = new IncrementalList<ProvinceViewObject>(LoadMoreItems);
            HelperView.LoadItems(list);
        }

        private void LoadMoreItems(uint arg1, int arg2)
        {
           
        }

        public IEnumerable<CountryViewObject> CountryDto
        {
            set { _countryDto = value; RaisePropertyChanged();}
            get { return _countryDto; }
        }
        public ICommand AssistCountryCommand { set; get; }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            ProvinceViewObject viewObject = payLoad.DataObject as ProvinceViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ProvinceViewObject, PROVINCIA>(viewObject);
                viewObject.Code = codeId.Substring(0, 3);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }
    }
}
