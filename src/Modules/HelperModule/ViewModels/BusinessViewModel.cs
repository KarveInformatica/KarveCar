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
    /// <summary>
    ///  BusinessViewModel. Model that maps the business helper.
    /// </summary>
    class BusinessViewModel: GenericHelperViewModel<BusinessViewObject, NEGOCIO>
    {
        public BusinessViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService service, IConfigurationService config) : base(String.Empty, dataServices, region, manager, service, config)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperBusiness;
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            BusinessViewObject viewObject = payLoad.DataObject as BusinessViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<BusinessViewObject,NEGOCIO>(viewObject);
                viewObject.Code = codeId.Substring(0, 2);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }

      
    }
}
