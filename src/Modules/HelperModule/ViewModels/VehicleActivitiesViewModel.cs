using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using KarveDataServices.DataObjects;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    class VehicleActivitiesViewModel : GenericHelperViewModel<VehicleActivitiesDto, ACTIVEHI>
    {
        public VehicleActivitiesViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(string.Empty, dataServices, region, manager)
        {
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            VehicleActivitiesDto activitiesDto = new VehicleActivitiesDto();
            string activities = await DataServices.GetHelperDataServices().GetMappedUniqueId<VehicleActivitiesDto, ACTIVEHI>(activitiesDto);
            activitiesDto = payLoad.DataObject as VehicleActivitiesDto;
            if (activitiesDto != null)
            {
                activitiesDto.Code = activities.Substring(0, 4);
            }
            return payLoad;
        }
        
    }
}
