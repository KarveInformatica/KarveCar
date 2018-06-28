using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  VehicleActivitiesViewModel. This is a viewmodel for the helpers vehicle view model.
    /// </summary>
    class VehicleActivitiesViewModel : GenericHelperViewModel<ActividadDto, ACTIVEHI>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataServices">DataServices to be used.</param>
        /// <param name="region">Region where the tab is present.</param>
        /// <param name="manager">Event manager to send and receive messages from other view models.</param>
        
        public VehicleActivitiesViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService service) : base(string.Empty, dataServices, region, manager, service)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleActivities;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            ActividadDto activitiesDto = new ActividadDto();
            string activities = await DataServices.GetHelperDataServices().GetMappedUniqueId<ActividadDto, ACTIVEHI>(activitiesDto);
            activitiesDto = payLoad.DataObject as ActividadDto;
            if (activitiesDto != null)
            {
                activitiesDto.Codigo = activities;
                payLoad.DataObject = activitiesDto;

            }
            
            return payLoad;
        }
        
    }
}
