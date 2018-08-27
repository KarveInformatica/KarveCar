using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.RightsManagement;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;
using System.Windows.Input;
using Prism.Commands;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using KarveCommonInterfaces;

namespace HelperModule.ViewModels
{
    public class VehicleGroupViewModel : GenericHelperViewModel<VehicleGroupViewObject, GRUPOS>
    {
        public VehicleGroupViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService service) : base(string.Empty, dataServices, region, manager, service)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VehicleGroup;
        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            var dto = payLoad.DataObject as VehicleGroupViewObject;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<VehicleGroupViewObject, GRUPOS>(dto);
                dto.Codigo = codeId.Substring(0, 4);
                dto.Code = codeId;
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
