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
    class ClientOriginViewModel : GenericHelperViewModel<ClientOriginDto, ORIGEN>
    {
        public ClientOriginViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(string.Empty, dataServices, region, manager)
        {
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
           ClientOriginDto dto = payLoad.DataObject as ClientOriginDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ClientOriginDto, ORIGEN>(dto);
                dto.Code = Convert.ToInt32(codeId);
                payLoad.DataObject = dto;
               
            }
            return payLoad;
        }
    }
}
