using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;
using System;
using System.Threading.Tasks;

namespace HelperModule.ViewModels
{

    class RequestReasonViewModel : GenericHelperViewModel<RequestReasonDto, MOPETI>
    {
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            var dto = payLoad.DataObject as RequestReasonDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<RequestReasonDto, MOPETI>(dto);
                dto.Code = codeId.Substring(0, 4);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
        public RequestReasonViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService service) : base(String.Empty, dataServices, region, manager, service)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.RequestReasonGrid;
        }
        public override void DisposeEvents()
        {
            base.DisposeEvents();
            var value = HelperDto as RequestReasonDto;
            value.ClearErrors();
            HelperDto = value;
            value = null;
        }

    }
}

