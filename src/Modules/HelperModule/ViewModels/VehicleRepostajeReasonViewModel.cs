using System;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;



namespace HelperModule.ViewModels
{
    internal class VehicleRepostajeReasonViewModel : GenericHelperViewModel<VehicleProvisionReasonViewObject, MOT_REPOSTAJE>
    {   public VehicleRepostajeReasonViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty,dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleRepostaje;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            VehicleProvisionReasonViewObject provisionReasonViewObject = new VehicleProvisionReasonViewObject();
            string activities = await DataServices.GetHelperDataServices().GetMappedUniqueId<VehicleProvisionReasonViewObject, MOT_REPOSTAJE>(provisionReasonViewObject);
            provisionReasonViewObject = payLoad.DataObject as VehicleProvisionReasonViewObject;
            if (provisionReasonViewObject != null)
            {
                provisionReasonViewObject.Code = Convert.ToByte(activities.Substring(0, 2));
            }
            return payLoad;
        }
    }
}
