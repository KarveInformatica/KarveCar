using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;

namespace HelperModule.ViewModels
{
   /// <summary>
   ///  View model that models the bank.
   /// </summary>
    class ClientBanksViewModel: GenericHelperViewModel<BanksViewObject, BANCO>
    {
        /// <summary>
        ///  This is unique for all class of the grid identifiers.
        /// </summary>
      
        private KarveGridParameters _bankGridParm = new KarveGridParameters();
        /// <summary>
        ///  ClientBanksViewModel
        /// </summary>
        /// <param name="dataServices">DataServices testing</param>
        /// <param name="region">Region </param>
        /// <param name="manager"> event manager to send and put messages.</param>
        public ClientBanksViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(GenericSql.BanksSql, dataServices, region, manager, dialogService)
        {
            
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.BankGrid;
        }
        public override void DisposeEvents()
        {
            base.DisposeEvents();
            var value =  HelperDto as BanksViewObject;
            value.ClearErrors();
            HelperDto = value;
            value = null;
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            BanksViewObject viewObject = payLoad.DataObject as BanksViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<BanksViewObject, BANCO>(viewObject).ConfigureAwait(false);
                viewObject.Code = codeId.Substring(0, 4);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }

    }
}
