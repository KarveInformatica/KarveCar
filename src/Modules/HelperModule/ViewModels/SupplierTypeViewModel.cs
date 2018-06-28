using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.DataObjects;
using KarveDataServices;
using Prism.Regions;
using KarveCommon.Services;
using KarveCommonInterfaces;
using System.Threading.Tasks;

namespace HelperModule.ViewModels
{
    public class SupplierTypeViewModel : GenericHelperViewModel<SupplierTypeDto, TIPOPROVE>
    {
        public SupplierTypeViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.SupplierTypeGrid;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            var dto = new SupplierTypeDto();
            string tmp = await DataServices.GetHelperDataServices().GetMappedUniqueId<SupplierTypeDto, TIPOPROVE>(dto);

            var supplier = payLoad.DataObject as SupplierTypeDto;
            if (supplier != null)
            {
                supplier.Codigo = Convert.ToByte(tmp);
                payLoad.DataObject = supplier;
            }
            return payLoad;
        }
    }
}
