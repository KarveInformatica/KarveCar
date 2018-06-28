using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using KarveDataServices.DataTransferObject;
using KarveDataServices.DataObjects;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using System.Threading.Tasks;
using Prism.Regions;
using KarveCommonInterfaces;

namespace HelperModule.ViewModels
{
    public class CountryRegionsViewModel : GenericHelperViewModel<KarveDataServices.DataTransferObject.CountryRegionDto, CCAA>
    {
        public CountryRegionsViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialog) : base(
            String.Empty, dataServices, region, manager, dialog)
        {

        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
           CountryRegionDto dto = payLoad.DataObject as CountryRegionDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CountryRegionDto, CCAA>(dto);
                dto.Code = codeId.Substring(0, 2);
                payLoad.DataObject = dto;
            }
            return payLoad;

        }
    }
}
