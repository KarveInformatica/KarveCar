using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    ///  ClientTypeViewModel.
    /// </summary>
    class ClientTypeViewModel : GenericHelperViewModel<ClientTypeDto, TIPOCLI>
    {
       

        /// <summary>
        ///  Set the code.
        /// </summary>
        /// <param name="payLoad">DataPayLoad</param>
        /// <param name="dataServices">DataServices</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            ClientTypeDto dto = payLoad.DataObject as ClientTypeDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ClientTypeDto, TIPOCLI>(dto);
                dto.Code = codeId.Substring(0, 4);
                payLoad.DataObject = dto;
            }
            
            return payLoad;
        }

    

        /// <summary>
        /// Client data services.
        /// </summary>
        /// <param name="dataServices">DataServices</param>
        /// <param name="region">Region</param>
        /// <param name="manager">Manager</param>
        public ClientTypeViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(String.Empty, dataServices, region, manager)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperClientType;
        }
    }
}
