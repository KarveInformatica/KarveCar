using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;


namespace HelperModule.ViewModels
{
    class ClientInvoiceBlocksViewModel : GenericHelperViewModel<InvoiceBlockViewObject, BLOQUEFAC>
    {
      
        public ClientInvoiceBlocksViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService, IConfigurationService config) : base(string.Empty,dataServices, region, manager, dialogService, config)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperClientInvoice;
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            InvoiceBlockViewObject viewObject = payLoad.DataObject as InvoiceBlockViewObject;
            if (viewObject != null)
            {

                string codeId = await helperDal.GetUniqueId<BLOQUEFAC>(new BLOQUEFAC());
                viewObject.Code = codeId.Substring(0,3);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }

    }
}
