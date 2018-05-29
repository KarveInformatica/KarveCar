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
    class ClientZoneViewModel: GenericHelperViewModel<ClientZoneDto, ZONAS>
    {

        public ClientZoneViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(
            string.Empty, dataServices, region, manager)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperClientZone;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            ClientZoneDto dto = payLoad.DataObject as ClientZoneDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ClientZoneDto, ZONAS>(dto);
                dto.Code = codeId.Substring(0, 4);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }

        
    }
}
