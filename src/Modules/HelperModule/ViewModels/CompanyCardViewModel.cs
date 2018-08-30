using System;
using System.Collections.Generic;
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
    ///  This is the company card view model.
    /// </summary>
    class CompanyCardViewModel:  GenericHelperViewModel<KarveDataServices.ViewObjects.CompanyCardViewObject, TARJETA_EMP>
    {
        /// <summary>
        ///  CompanyCardViewModel
        /// </summary>
        /// <param name="dataServices">DataServices</param>
        /// <param name="region">Region</param>
        /// <param name="manager">EventManager</param>
        public CompanyCardViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService, IConfigurationService config) : base(String.Empty, dataServices, region, manager, dialogService, config)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperCompanyCard;

        }
        /// <summary>
        /// This is the SetCode
        /// </summary>
        /// <param name="payLoad">Payload to be loaded</param>
        /// <param name="dataServices">DataServices to be loaded</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            CompanyCardViewObject viewObject = payLoad.DataObject as CompanyCardViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CompanyCardViewObject, TARJETA_EMP>(viewObject);
                viewObject.Code = codeId.Substring(0, 2);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }
    }
}
