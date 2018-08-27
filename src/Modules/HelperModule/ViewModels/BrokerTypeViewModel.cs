using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;

namespace HelperModule.ViewModels
{


    public class BrokerTypeViewModel : GenericHelperViewModel<CommissionTypeViewObject, TIPOCOMI>
    {
        public BrokerTypeViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.BrokerTypeGrid;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            var dto = new CommissionTypeViewObject();
            string tmp = await DataServices.GetHelperDataServices().GetMappedUniqueId<CommissionTypeViewObject, TIPOCOMI>(dto);
            var brokerType = payLoad.DataObject as CommissionTypeViewObject;
            if (brokerType != null)
            {
                brokerType.Codigo = tmp;
                payLoad.DataObject = brokerType;
            }
            return payLoad;
        }
    }
    
}
