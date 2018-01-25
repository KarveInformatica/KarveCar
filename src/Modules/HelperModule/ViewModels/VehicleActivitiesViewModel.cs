using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  VehicleActivitiesViewModel. This is a viewmodel for the helpers vehicle view model.
    /// </summary>
    class VehicleActivitiesViewModel : GenericHelperViewModel<VehicleActivitiesDto, ACTIVEHI>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataServices">DataServices to be used.</param>
        /// <param name="region">Region where the tab is present.</param>
        /// <param name="manager">Event manager to send and receive messages from other view models.</param>
        
        public VehicleActivitiesViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(string.Empty, dataServices, region, manager)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleActivities;
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
