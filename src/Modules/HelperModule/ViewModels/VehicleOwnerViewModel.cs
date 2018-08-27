using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;
using Prism.Commands;
using KarveCommonInterfaces;

namespace HelperModule.ViewModels
{

    /// <summary>
    /// VehicleOwnerViewModel. This view model is responsible for vehicle owener mini tab.
    /// </summary>
    internal class VehicleOwnerViewModel : GenericHelperViewModel<VehicleOwnerDto, PROPIE>
    {
        private IEnumerable<CountryViewObject> _vehicleOwnerCountryDto;
        private IEnumerable<CityViewObject> _vehicleOwnerCityDto;
        private IEnumerable<ProvinceViewObject> _vehicleOwnerProvinciaDto;
      
        /// <summary>
        /// This is a vehicle owner view model.
        /// </summary>
        /// <param name="dataServices">DataServices that you can use</param>
        /// <param name="region"> Region Manager</param>
        /// <param name="manager">Event Manager</param>
        public VehicleOwnerViewModel(IDataServices dataServices, IRegionManager region,
            IEventManager manager, IDialogService dialogService): base(GenericSql.VehicleOwner, dataServices, region,manager, dialogService)
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
                        VehicleOwnerCityDto = await helperDataServices.GetMappedAsyncHelper<CityViewObject, POBLACIONES>(assistQuery);
                        break;
                    }
                    case "PAIS_OWNER":
                    {
                        VehicleOwnerCountryDto =
                            await helperDataServices.GetMappedAsyncHelper<CountryViewObject, Country>(assistQuery);
                        break;
                    }
                    case "PROV_OWNER":
                    {
                        VehicleOwnerProvinciaDto = await helperDataServices
                            .GetMappedAsyncHelper<ProvinceViewObject, PROVINCIA>(assistQuery);
                        break;
                        
                    }
                }
            }
        }

     
        public IEnumerable<CountryViewObject> VehicleOwnerCountryDto
        {
            set { _vehicleOwnerCountryDto = value; RaisePropertyChanged(); }
            get { return _vehicleOwnerCountryDto; }
        }

        public IEnumerable<CityViewObject> VehicleOwnerCityDto
        {
            set { _vehicleOwnerCityDto = value; RaisePropertyChanged(); }
            get { return _vehicleOwnerCityDto; }
        }

        public IEnumerable<ProvinceViewObject> VehicleOwnerProvinciaDto
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
