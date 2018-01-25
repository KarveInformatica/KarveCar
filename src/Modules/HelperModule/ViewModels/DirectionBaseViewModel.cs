using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
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

        private const string CityTag = "POBLA";
        private const string CountryTag = "PAIS";
        private const string ProvinceTag = "PROV";



        public DirectionBaseViewModel(string query, IDataServices dataServices, IRegionManager region, IEventManager manager) : base(query, dataServices, region, manager)
        {
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
                    IHelperDataServices helperDataServices = DataServices.GetHelperDataServices();
                    // remove this if it possible.
                    switch (name)
                    {
                        case CityTag:
                        {
                            GenericCityDto = await helperDataServices.GetMappedAsyncHelper<CityDto, POBLACIONES>(assistQuery);
                            break;
                        }
                        case CountryTag:
                        {
                            GenericCountryDto =
                                await helperDataServices.GetMappedAsyncHelper<CountryDto, Country>(assistQuery);
                            break;
                        }
                        case ProvinceTag:
                        {
                            GenericProvinciaDto = await helperDataServices
                                .GetMappedAsyncHelper<ProvinciaDto, PROVINCIA>(assistQuery);
                            break;

                        }
                    }
                    return true;
                }
            return false;
        }
        /// <summary>
        ///  AssistCommand
        /// </summary>
        public DelegateCommand<object> AssistCommand { get; set; }
        /// <summary>
        ///  GenericCityDto.
        /// </summary>
        public IEnumerable<CityDto> GenericCityDto { get; private set; }
        /// <summary>
        ///  GenericyCountryDto
        /// </summary>
        public IEnumerable<CountryDto> GenericCountryDto { get; private set; }
        /// <summary>
        ///  GenericProvinciaDto.
        /// </summary>
        public IEnumerable<ProvinciaDto> GenericProvinciaDto { get; private set; }
    }
}
