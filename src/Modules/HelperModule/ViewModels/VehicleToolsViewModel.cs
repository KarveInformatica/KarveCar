using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    class VehicleToolsViewModel : GenericHelperViewModel<VehicleToolDto, VEHI_ACC>
    {
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            VehicleToolDto dto = payLoad.DataObject as VehicleToolDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<VehicleToolDto, VEHI_ACC>(dto);
                dto.Code = codeId.Substring(0, 4);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
        public VehicleToolsViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(GenericSql.VehicleTools, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleTools;
        }
    }
}
