using System;
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
    /// PeoplePositionViewModel.
    /// </summary>
    class PeoplePositionViewModel : GenericHelperViewModel<PeoplePositionViewObject, TIPO_CARGO>
    {
        /// <summary>
        /// Set the code
        /// </summary>
        /// <param name="payLoad">Payload</param>
        /// <param name="dataServices">DataService</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            PeoplePositionViewObject viewObject = payLoad.DataObject as PeoplePositionViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<PeoplePositionViewObject, TIPO_CARGO>(viewObject);
                viewObject.Code = codeId.Substring(0,2);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }
        public PeoplePositionViewModel(IDataServices dataServices, IRegionManager region,
            IEventManager manager, IDialogService service, IConfigurationService config) : base(String.Empty, dataServices, region, manager, service, config)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperPeoplePosition;
        }
    }
}
