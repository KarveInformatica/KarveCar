using DataAccessLayer.DataObjects;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;
using KarveCommon.Services;
using System.Threading.Tasks;
using KarveCommonInterfaces;

namespace HelperModule.ViewModels
{
    public class SupplierCurrencyViewModel : GenericHelperViewModel<CurrencyViewObject, DIVISAS>
    {
        public SupplierCurrencyViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService, IConfigurationService config) : base(string.Empty, dataServices, region, manager, dialogService, config)
        {
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            var dto = payLoad.DataObject as CurrencyViewObject;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<CurrencyViewObject, DIVISAS>(dto);
                dto.Codigo = codeId.Substring(0, 4);
                dto.Code = codeId;
                payLoad.DataObject = dto;
            }
            return payLoad;

        }
    }
}
