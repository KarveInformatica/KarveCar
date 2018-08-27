using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices.ViewObjects;
using KarveDataAccessLayer.DataObjects;
using KarveDataServices;
using Prism.Regions;
using KarveCommonInterfaces;
using KarveCommon.Generic;

namespace HelperModule.ViewModels
{
    public class CountryViewModel : GenericHelperViewModel<CountryViewObject, Country>
    {
        private IHelperDataServices _helperDataServices;
        private ObservableCollection<LanguageViewObject> _languageDto = new ObservableCollection<LanguageViewObject>();
        public CountryViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(
            String.Empty, dataServices, region, manager, dialogService)
        {
            AssistCommand = new Prism.Commands.DelegateCommand<object>(OnAssistCommand);
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperCountry;
            _helperDataServices = DataServices.GetHelperDataServices();
            
        }

        private void StartAndNotify()
        {
            NotifyTaskCompletion.Create<IEnumerable<LanguageViewObject>>(_helperDataServices.GetMappedAllAsyncHelper<LanguageViewObject, IDIOMAS>(), (task, ev)=> {
                if (ev is INotifyTaskCompletion <IEnumerable<LanguageViewObject>> languageList)
                {
                    if (languageList.IsSuccessfullyCompleted)
                    {
                        LanguageDto = languageList.Result;
                    }
                }
            });
        }
        /// <summary>
        ///  LanguageViewObject.
        /// </summary>
        public IEnumerable<LanguageViewObject> LanguageDto
        {
            set
            {
                _languageDto = new ObservableCollection<LanguageViewObject>(value);
                RaisePropertyChanged();
            }
            get { return _languageDto; }
        }
    

   
        public async void OnAssistCommand(object command)
        {
            var value = await DataServices.GetHelperDataServices().GetMappedAllAsyncHelper<LanguageViewObject, IDIOMAS>();
            LanguageDto = value;
        }
        public override  async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            CountryViewObject viewObject = payLoad.DataObject as CountryViewObject;
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
          
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CountryViewObject, Country>(viewObject);
                viewObject.Code = codeId.Substring(0, 3);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }
    }
}
