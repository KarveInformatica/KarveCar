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
    public class ContactTypeViewModel: GenericHelperViewModel<ContactTypeDto, TIPOCONTACTO_CLI>
    {
        public ContactTypeViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(string.Empty, dataServices, region, manager)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperConctactType;

        }

        public async override Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
           ContactTypeDto dto = payLoad.DataObject as ContactTypeDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ContactTypeDto, TIPOCONTACTO_CLI>(dto);
                dto.Code = codeId.Substring(0, 2);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
