using System;
using System.Collections.Generic;
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
    class MarketViewModel : GenericHelperViewModel<MercadoDto, MERCADO>
    {
        /// <summary>
        ///  SetCode
        /// </summary>
        /// <param name="payLoad">Payload code to set the code</param>
        /// <param name="dataServices">Data services</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            MercadoDto marketDto = new MercadoDto();
            string activities = await DataServices.GetHelperDataServices().GetMappedUniqueId<MercadoDto, MERCADO>(marketDto);
            marketDto = payLoad.DataObject as MercadoDto;
            if (marketDto != null)
            {
                marketDto.Code = activities.Substring(0, 2);
            }
            return payLoad;
        }
        public MarketViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(String.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperMarket;
        }
    }
}
