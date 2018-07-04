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
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    class ClientOriginViewModel : GenericHelperViewModel<OrigenDto, ORIGEN>
    {
        public ClientOriginViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperClientOrigin;
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            OrigenDto dto = payLoad.DataObject as OrigenDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<OrigenDto, ORIGEN>(dto);
                dto.Code =codeId;
                payLoad.DataObject = dto;
               
            }
            return payLoad;
        }
        public override void DisposeEvents()
        {
            base.DisposeEvents();
            var value = HelperDto as OrigenDto;
            value.ClearErrors();
            HelperDto = value;
            value = null;
        }


    }
}
