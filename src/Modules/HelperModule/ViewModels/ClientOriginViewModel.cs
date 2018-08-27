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
    class ClientOriginViewModel : GenericHelperViewModel<OrigenViewObject, ORIGEN>
    {
        public ClientOriginViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperClientOrigin;
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            OrigenViewObject viewObject = payLoad.DataObject as OrigenViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<OrigenViewObject, ORIGEN>(viewObject);
                viewObject.Code =codeId;
                payLoad.DataObject = viewObject;
               
            }
            return payLoad;
        }
        public override void DisposeEvents()
        {
            base.DisposeEvents();
            var value = HelperDto as OrigenViewObject;
            value.ClearErrors();
            HelperDto = value;
            value = null;
        }


    }
}
