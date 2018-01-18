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
    class ClientInvoiceBlockViewModel : GenericHelperViewModel<InvoiceBlockDto, BLOQUEFAC>
    {
        public ClientInvoiceBlockViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(string.Empty,dataServices, region, manager)
        {
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            InvoiceBlockDto dto = payLoad.DataObject as InvoiceBlockDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<InvoiceBlockDto, BLOQUEFAC>(dto);
                dto.Code = codeId.Substring(0, 4);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }     
    }
}
