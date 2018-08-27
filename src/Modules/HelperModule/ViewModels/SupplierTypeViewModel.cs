using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using KarveDataServices.ViewObjects;
using DataAccessLayer.DataObjects;
using KarveDataServices;
using Prism.Regions;
using KarveCommon.Services;
using KarveCommonInterfaces;
using System.Threading.Tasks;

namespace HelperModule.ViewModels
{
    public class SupplierTypeViewModel : GenericHelperViewModel<SupplierTypeViewObject, TIPOPROVE>
    {
        public SupplierTypeViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(string.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.SupplierTypeGrid;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            var dto = new SupplierTypeViewObject();
            string tmp = await DataServices.GetHelperDataServices().GetMappedUniqueId<SupplierTypeViewObject, TIPOPROVE>(dto);

            var supplier = payLoad.DataObject as SupplierTypeViewObject;
            if (supplier != null)
            {
                supplier.Codigo = Convert.ToByte(tmp);
                payLoad.DataObject = supplier;
            }
            return payLoad;
        }
    }
}
