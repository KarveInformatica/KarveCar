using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    class ClientZoneViewModel: GenericHelperViewModel<ClientZoneViewObject, ZONAS>
    {

        public ClientZoneViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(
            string.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperClientZone;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            ClientZoneViewObject viewObject = payLoad.DataObject as ClientZoneViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ClientZoneViewObject, ZONAS>(viewObject);
                viewObject.Code = codeId.Substring(0, 4);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }

        
    }
}
