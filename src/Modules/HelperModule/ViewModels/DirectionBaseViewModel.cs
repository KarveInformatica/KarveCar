using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveControls;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Commands;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  DirectionBaseViewModel. The idea here is to uniform all the assist n case of poblacion, pais or province.
    ///  The subclass shall call OnAssistCommand.
    /// </summary>
    /// <typeparam name="Dto"></typeparam>
    /// <typeparam name="Entity"></typeparam>
    public abstract class DirectionBaseViewModel<Dto, Entity> : GenericHelperViewModel<Dto, Entity> where Dto : class, new()
                                                                                                    where Entity: class, new()

    {

        private const string CityTag = "CITY_ASSIST";
        private const string CountryTag = "COUNTRY_ASSIST";
        private const string ProvinceTag = "PROVINCE_ASSIST";
        private IAssistDataService _assistDataService;


        public DirectionBaseViewModel(string query, IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService, IConfigurationService config) : base(query, dataServices, region, manager, dialogService, config)
        {
            _assistDataService = dataServices.GetAssistDataServices();
            AssistMapper = _assistDataService.Mapper;
            AssistCommand = new DelegateCommand<object>(OnAssistAsync);
            AssistCompletionEventHandler += AssistComplete;
        }
        /// <summary>
        ///  Assist complete handler
        /// </summary>
        /// <param name="sender">This is the sender.</param>
        /// <param name="e">These are the objects.</param>
        public abstract void AssistComplete(object sender, PropertyChangedEventArgs e);

        
        protected void OnAssistAsync(object obj)
        {
            AssistCompletion = NotifyTaskCompletion.Create<bool>(OnAssistCommand(obj), AssistCompletionEventHandler);
        }

    

        protected async Task<bool> OnAssistCommand(object ev)
        {
                IDictionary<string, string> assistData = ev as Dictionary<string, string>;
                if (assistData != null)
                {
                    string name = assistData[ControlExt.AssistTable];
                string assistQuery = assistData[ControlExt.AssistQuery];
                    var resultDto = await AssistMapper.ExecuteAssistGeneric(name, assistQuery);
                    IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
                    // remove this if it possible.
                    switch (name)
                    {
                        case CityTag:
                        {
                            GenericCityDto = (IEnumerable<CityViewObject>)resultDto; 
                            break;
                        }
                        case CountryTag:
                        {
                            GenericCountryDto = (IEnumerable<CountryViewObject>)resultDto;
                            break;
                        }
                        case ProvinceTag:
                        {
                            GenericProvinciaDto = (IEnumerable<ProvinceViewObject>)resultDto; 
                            break;

                        }
                    }
                    return true;
                }
            return false;
        }
        
        /// <summary>
        ///  GenericCityDto.
        /// </summary>
        public IEnumerable<CityViewObject> GenericCityDto { get; private set; }
        /// <summary>
        ///  GenericyCountryDto
        /// </summary>
        public IEnumerable<CountryViewObject> GenericCountryDto { get; private set; }
        /// <summary>
        ///  GenericProvinciaDto.
        /// </summary>
        public IEnumerable<ProvinceViewObject> GenericProvinciaDto { get; private set; }
    }
}
