using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  RentingUseViewModel.
    /// </summary>
    class RentingUseViewModel: GenericHelperViewModel<RentingUseDto, USO_ALQUILER>
    {
        /// <summary>
        /// RentingUseViewModel
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dataServices"></param>
        /// <param name="region"></param>
        /// <param name="manager"></param>
        public RentingUseViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService service ) : base(String.Empty, dataServices, region, manager, service)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperRentingUse;

        }
        /// <summary>
        ///  SetCode
        /// </summary>
        /// <param name="payLoad"></param>
        /// <param name="dataServices"></param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            RentingUseDto dto = payLoad.DataObject as RentingUseDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<RentingUseDto,USO_ALQUILER>(dto);
                dto.Code = codeId.Substring(0, 2);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
