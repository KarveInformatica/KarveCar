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
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
   /// <summary>
   ///  View model that models the bank.
   /// </summary>
    class ClientBanksViewModel: GenericHelperViewModel<BanksDto, BANCO>
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
        
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            BanksDto dto = payLoad.DataObject as BanksDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<BanksDto, BANCO>(dto);
                dto.Code = codeId.Substring(0, 4);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }

    }
}
