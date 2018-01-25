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
    ///  This is the company card view model.
    /// </summary>
    class CompanyCardViewModel:  GenericHelperViewModel<KarveDataServices.DataTransferObject.CompanyCardDto, TARJETA_EMP>
    {
        /// <summary>
        ///  CompanyCardViewModel
        /// </summary>
        /// <param name="dataServices">DataServices</param>
        /// <param name="region">Region</param>
        /// <param name="manager">EventManager</param>
        public CompanyCardViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(String.Empty, dataServices, region, manager)
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
            CompanyCardDto dto = payLoad.DataObject as CompanyCardDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CompanyCardDto, TARJETA_EMP>(dto);
                dto.Code = codeId.Substring(0, 2);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
