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
    ///  Credi card view model
    /// </summary>
    class CreditCardViewModel: GenericHelperViewModel<CreditCardViewObject, TARCREDI>
    {
        /// <summary>
        /// CreditCardView Model.
        /// </summary>
        /// <param name="dataServices">DataServices</param>
        /// <param name="region"> RegionManager to support further navigation</param>
        /// <param name="manager">Event Manager for the communiction between view modules.</param>
        public CreditCardViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService, IConfigurationService config) : base(String.Empty, dataServices, region, manager, dialogService, config)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperCreditCard;

        }
        /// <summary>
        ///  Get an unique code for the credit card.
        /// </summary>
        /// <param name="payLoad">Payload recevied from the toolbar</param>
        /// <param name="dataServices">DataServices.</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            CreditCardViewObject viewObject = payLoad.DataObject as CreditCardViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CreditCardViewObject, TARCREDI>(viewObject);
                viewObject.Code = codeId.Substring(0, 2);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }
    }
}
