using System;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    /// PeoplePositionViewModel.
    /// </summary>
    class PeoplePositionViewModel : GenericHelperViewModel<PeoplePositionDto, TIPO_CARGO>
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
            PeoplePositionDto dto = payLoad.DataObject as PeoplePositionDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<PeoplePositionDto, TIPO_CARGO>(dto);
                dto.Code = Convert.ToInt16(codeId.Substring(0,3));
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
        public PeoplePositionViewModel(IDataServices dataServices, IRegionManager region,
            IEventManager manager) : base(String.Empty, dataServices, region, manager)
        {
        }
    }
}
