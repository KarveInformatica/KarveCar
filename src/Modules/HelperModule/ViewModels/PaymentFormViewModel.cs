using System;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;
using KarveCommonInterfaces;


namespace HelperModule.ViewModels
{
    public class PaymentFormViewModel : GenericHelperViewModel<PaymentFormViewObject, FORMAS>
    {
        public PaymentFormViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.PaymentFormGrid;
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            var dto = payLoad.DataObject as PaymentFormViewObject;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<PaymentFormViewObject, FORMAS>(dto);
                dto.Codigo = Convert.ToByte(codeId);
                payLoad.DataObject = dto;

            }
            return payLoad;
        }
        
    }
}
