using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;
using Prism.Commands;

namespace HelperModule.ViewModels
{

    /// <summary>
    /// VehicleOwnerViewModel. This view model is responsible for vehicle owener mini tab.
    /// </summary>
    internal class VehicleOwnerViewModel : GenericHelperViewModel<VehicleOwnerDto, PROPIE>
    {
        private IEnumerable<CountryDto> _vehicleOwnerCountryDto;
        private IEnumerable<CityDto> _vehicleOwnerCityDto;
        private IEnumerable<ProvinciaDto> _vehicleOwnerProvinciaDto;
      
        /// <summary>
        /// This is a vehicle owner view model.
        /// </summary>
        /// <param name="dataServices">DataServices that you can use</param>
        /// <param name="region"> Region Manager</param>
        /// <param name="manager">Event Manager</param>
        public VehicleOwnerViewModel(IDataServices dataServices, IRegionManager region,
            IEventManager manager): base(GenericSql.VehicleOwner, dataServices, region,manager)
        {
            AssistCommand = new DelegateCommand<object>(OnAssistCommand);         
        }

        private async void OnAssistCommand(object ev)
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
                    case "POBLA_OWNER":
                    {
                        VehicleOwnerCityDto = await helperDataServices.GetMappedAsyncHelper<CityDto, POBLACIONES>(assistQuery);
                        break;
                    }
                    case "PAIS_OWNER":
                    {
                        VehicleOwnerCountryDto =
                            await helperDataServices.GetMappedAsyncHelper<CountryDto, Country>(assistQuery);
                        break;
                    }
                    case "PROV_OWNER":
                    {
                        VehicleOwnerProvinciaDto = await helperDataServices
                            .GetMappedAsyncHelper<ProvinciaDto, PROVINCIA>(assistQuery);
                        break;
                        
                    }
                }
            }
        }

        public ICommand AssistCommand { set; get; }
        public IEnumerable<CountryDto> VehicleOwnerCountryDto
        {
            set { _vehicleOwnerCountryDto = value; RaisePropertyChanged(); }
            get { return _vehicleOwnerCountryDto; }
        }

        public IEnumerable<CityDto> VehicleOwnerCityDto
        {
            set { _vehicleOwnerCityDto = value; RaisePropertyChanged(); }
            get { return _vehicleOwnerCityDto; }
        }

        public IEnumerable<ProvinciaDto> VehicleOwnerProvinciaDto
        {
            set { _vehicleOwnerProvinciaDto = value; RaisePropertyChanged(); }
            get { return _vehicleOwnerProvinciaDto; }      
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            VehicleOwnerDto dto = payLoad.DataObject as  VehicleOwnerDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<VehicleOwnerDto, PROPIE>(dto);
                dto.NUM_PROPIE = codeId.Substring(0,7);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
        public override void SetModification(ref DataPayLoad payLoad)
        {
            var lastModification = DateTime.Now;
            VehicleOwnerDto dto = payLoad.DataObject as VehicleOwnerDto;
            if (dto != null)
            {
                dto.ULTMODI = lastModification.ToString("yyyMMddHHmmss");
            }
            payLoad.DataObject = dto;
        }
    }
}
