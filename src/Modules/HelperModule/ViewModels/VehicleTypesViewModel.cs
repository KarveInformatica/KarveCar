using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Commands;
using Prism.Regions;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  FIXME this is too complex. Refactor as other identifiers.
    /// </summary>
    public class VehicleTypesViewModel : GenericHelperViewModel<VehicleTypeDto, CATEGO>
    {
        /// <summary>
        /// VehicleTypes
        /// </summary>
        /// <param name="dataServices">Data services to be used</param>
        /// <param name="region">Region Manager to be used</param>
        /// <param name="eventManager">Event manager to be used</param>
        /// <param name="dialogService">Dialog service to be used</param>
        public VehicleTypesViewModel(IDataServices dataServices, IRegionManager region, IEventManager eventManager, IDialogService dialogService) : base(string.Empty, dataServices, region, eventManager, dialogService)
        {
            GridIdentifier = GridIdentifiers.VehicleTypes;
        }

        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            VehicleTypeDto dto = payLoad.DataObject as VehicleTypeDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<VehicleTypeDto, CATEGO>(dto);
                dto.Code = codeId.Substring(0, 2);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
