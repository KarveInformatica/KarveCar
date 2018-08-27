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
    ///  Helper BudgetKeyViewModel. This is an helper for the business helper view model.
    /// </summary>
    public class BudgetKeyViewModel : GenericHelperViewModel<BudgetKeyViewObject, CLAVEPTO>
    {
        public BudgetKeyViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialog) : base(
            String.Empty, dataServices, region, manager, dialog)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperBudgetKey;
        }
        /// <summary>
        /// Unfortunately we can have just 3 ciphers in this case. The database is not coherent. So we need to override.
        /// </summary>
        /// <param name="payLoad">Payload recevied from the EventManager/EventDispatcher</param>
        /// <param name="dataServices">Services to the lower level.</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            BudgetKeyViewObject viewObject = payLoad.DataObject as BudgetKeyViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<BudgetKeyViewObject, CLAVEPTO>(viewObject);
                viewObject.Code= codeId.Substring(0, 2);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }


       
    }
}
