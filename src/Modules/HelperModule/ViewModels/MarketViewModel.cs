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
    class MarketViewModel : GenericHelperViewModel<MarketViewObject, MERCADO>
    {
        /// <summary>
        ///  SetCode
        /// </summary>
        /// <param name="payLoad">Payload code to set the code</param>
        /// <param name="dataServices">Data services</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            MarketViewObject marketViewObject = new MarketViewObject();
            string activities = await DataServices.GetHelperDataServices().GetMappedUniqueId<MarketViewObject, MERCADO>(marketViewObject);
            marketViewObject = payLoad.DataObject as MarketViewObject;
            if (marketViewObject != null)
            {
                marketViewObject.Code = activities.Substring(0, 2);
            }
            return payLoad;
        }
        public MarketViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService, IConfigurationService config) : base(String.Empty, dataServices, region, manager, dialogService, config)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperMarket;
        }
    }
}
