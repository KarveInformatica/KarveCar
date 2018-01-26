using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  Helper BudgetKeyViewModel. This is an helper for the business helper view model.
    /// </summary>
    public class BudgetKeyViewModel : GenericHelperViewModel<BudgetKeyDto, CLAVEPTO>
    {
        public BudgetKeyViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(
            String.Empty, dataServices, region, manager)
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
            BudgetKeyDto dto = payLoad.DataObject as BudgetKeyDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<BudgetKeyDto, CLAVEPTO>(dto);
                dto.Code= codeId.Substring(0, 2);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
