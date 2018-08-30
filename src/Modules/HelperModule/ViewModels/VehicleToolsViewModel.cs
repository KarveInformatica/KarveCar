using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    class VehicleToolsViewModel : GenericHelperViewModel<VehicleToolViewObject, VEHI_ACC>
    {
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            VehicleToolViewObject viewObject = payLoad.DataObject as VehicleToolViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<VehicleToolViewObject, VEHI_ACC>(viewObject);
                viewObject.Code = codeId.Substring(0, 4);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }
        public VehicleToolsViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService, IConfigurationService config) : base(GenericSql.VehicleTools, dataServices, region, manager, dialogService, config)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleTools;
        }
    }
}
