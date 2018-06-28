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
using KarveCommonInterfaces;
using KarveCommon.Generic;

namespace HelperModule.ViewModels
{
    public class CountryViewModel : GenericHelperViewModel<CountryDto, Country>
    {
        private IHelperDataServices _helperDataServices;
        private ObservableCollection<LanguageDto> _languageDto = new ObservableCollection<LanguageDto>();
        public CountryViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(
            String.Empty, dataServices, region, manager, dialogService)
        {
            AssistCommand = new Prism.Commands.DelegateCommand<object>(OnAssistCommand);
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperCountry;
            _helperDataServices = DataServices.GetHelperDataServices();
            
        }

        private void StartAndNotify()
        {
            NotifyTaskCompletion.Create<IEnumerable<LanguageDto>>(_helperDataServices.GetMappedAllAsyncHelper<LanguageDto, IDIOMAS>(), (task, ev)=> {
                if (ev is INotifyTaskCompletion <IEnumerable<LanguageDto>> languageList)
                {
                    if (languageList.IsSuccessfullyCompleted)
                    {
                        LanguageDto = languageList.Result;
                    }
                }
            });
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
