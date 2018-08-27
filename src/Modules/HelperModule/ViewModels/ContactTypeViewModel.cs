using System;
using System.Collections.Generic;
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
    public class ContactTypeViewModel: GenericHelperViewModel<ContactTypeViewObject, TIPOCONTACTO_CLI>
    {
        public ContactTypeViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperConctactType;

        }

        public async override Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
           ContactTypeViewObject viewObject = payLoad.DataObject as ContactTypeViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ContactTypeViewObject, TIPOCONTACTO_CLI>(viewObject);
                viewObject.Code = codeId.Substring(0, 2);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }
    }
}
