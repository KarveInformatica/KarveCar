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
    public class BudgetKeyViewModel : GenericHelperViewModel<BudgetKeyDto, CLAVEPTO>
    {
        public BudgetKeyViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(
            String.Empty, dataServices, region, manager)
        {
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            BudgetKeyDto dto = payLoad.DataObject as BudgetKeyDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<BudgetKeyDto, CLAVEPTO>(dto);
                dto.Code= codeId.Substring(0, 3);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
