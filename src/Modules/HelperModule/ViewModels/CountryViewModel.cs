using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices.DataTransferObject;
using KarveDataAccessLayer.DataObjects;
using KarveDataServices;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    public class CountryViewModel : GenericHelperViewModel<CountryDto, Country>
    {
        private ObservableCollection<LanguageDto> _languageDto = new ObservableCollection<LanguageDto>();
        public CountryViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(
            String.Empty, dataServices, region, manager)
        {
            AssistCommand = new Prism.Commands.DelegateCommand<object>(OnAssistCommand);
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperCountry;

        }

        /// <summary>
        ///  LanguageDto.
        /// </summary>
        public IEnumerable<LanguageDto> LanguageDto
        {
            set
            {
                _languageDto = new ObservableCollection<LanguageDto>(value);
                RaisePropertyChanged();
            }
            get { return _languageDto; }
        }
    

    public ICommand AssistCommand { set; get; }

        public async void OnAssistCommand(object command)
        {
            var value = await DataServices.GetHelperDataServices().GetMappedAllAsyncHelper<LanguageDto, IDIOMAS>();
            LanguageDto = value;
        }
        public override  async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            CountryDto dto = payLoad.DataObject as CountryDto;
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
          
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CountryDto, Country>(dto);
                dto.Code = codeId.Substring(0, 3);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
