using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using Prism.Regions;
using DataAccessLayer.DataObjects;
using KarveDataServices.DataTransferObject;
using System.Threading.Tasks;

namespace HelperModule.ViewModels
{
    public class ActivitySectorViewModel : GenericHelperViewModel<ActividadDto, ACTIVI>
    {
        public ActivitySectorViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.ActivitySector;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            var dto = new ActividadDto();
            string tmp = await DataServices.GetHelperDataServices().GetMappedUniqueId<ActividadDto, ACTIVI>(dto);
            var activi = payLoad.DataObject as ActividadDto;
            if (activi != null)
            {
                activi.Codigo = tmp;
                payLoad.DataObject = activi;
            }
            return payLoad;
        }
    }
}
