using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  VehicleActivitiesViewModel. This is a viewmodel for the helpers vehicle view model.
    /// </summary>
    class VehicleActivitiesViewModel : GenericHelperViewModel<VehicleActivitiesViewObject, ACTIVEHI>
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
            VehicleActivitiesViewObject activitiesViewObject = new VehicleActivitiesViewObject();
            string activities = await DataServices.GetHelperDataServices().GetMappedUniqueId<VehicleActivitiesViewObject, ACTIVEHI>(activitiesViewObject);
            activitiesViewObject = payLoad.DataObject as VehicleActivitiesViewObject;
            if (activitiesViewObject != null)
            {
                activitiesViewObject.Code = activities;
                payLoad.DataObject = activitiesViewObject;

            }
            
            return payLoad;
        }
        
    }
}
