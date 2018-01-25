using System;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;



namespace HelperModule.ViewModels
{
    internal class VehicleRepostajeReasonViewModel : GenericHelperViewModel<VehicleProvisionReasonDto, MOT_REPOSTAJE>
    {   public VehicleRepostajeReasonViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(string.Empty,dataServices, region, manager)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleRepostaje;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            VehicleProvisionReasonDto provisionReasonDto = new VehicleProvisionReasonDto();
            string activities = await DataServices.GetHelperDataServices().GetMappedUniqueId<VehicleProvisionReasonDto, MOT_REPOSTAJE>(provisionReasonDto);
            provisionReasonDto = payLoad.DataObject as VehicleProvisionReasonDto;
            if (provisionReasonDto != null)
            {
                provisionReasonDto.Code = Convert.ToByte(activities.Substring(0, 2));
            }
            return payLoad;
        }
    }
}
