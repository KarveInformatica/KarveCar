using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using KarveDataServices.ViewObjects;
using KarveDataServices.DataObjects;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using System.Threading.Tasks;
using Prism.Regions;
using KarveCommonInterfaces;

namespace HelperModule.ViewModels
{
    public class CountryRegionsViewModel : GenericHelperViewModel<KarveDataServices.ViewObjects.CountryRegionViewObject, CCAA>
    {
        public CountryRegionsViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialog, IConfigurationService config) : base(
            String.Empty, dataServices, region, manager, dialog, config)
        {

        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
           CountryRegionViewObject viewObject = payLoad.DataObject as CountryRegionViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CountryRegionViewObject, CCAA>(viewObject);
                viewObject.Code = codeId.Substring(0, 2);
                payLoad.DataObject = viewObject;
            }
            return payLoad;

        }
    }
}
