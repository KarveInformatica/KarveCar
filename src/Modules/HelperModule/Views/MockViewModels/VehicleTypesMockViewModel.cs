using Prism.Commands;
using System.Windows;
using HelperModule.ViewModels;
using KarveDataServices.ViewObjects;
using System.Collections.ObjectModel;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Regions;
using System.Threading.Tasks;

namespace HelperModule.Views
{
   
    public class VehicleTypesMockViewModel: BaseHelperViewModel 
    {

        private ObservableCollection<VehicleTypeViewObject> listOfVehicles = new ObservableCollection<VehicleTypeViewObject>();

        public VehicleTypesMockViewModel(IDataServices dataServices, IRegionManager manager,
            IEventManager eventManager) : base(dataServices, manager, eventManager)
        {

        }
        protected override Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            throw new System.NotImplementedException();
        }

        public override void Revert(DataPayLoad payLoad)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> DeleteEntity(DataPayLoad payLoad)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> InsertEntity(DataPayLoad payLoad)
        {
            throw new System.NotImplementedException();
        }

        public override bool UpdateEntity(DataPayLoad payLoad)
        {
            throw new System.NotImplementedException();
        }
    }
}
