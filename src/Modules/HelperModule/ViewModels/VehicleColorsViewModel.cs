using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataAccessLayer.DataObjects;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{

    /// <summary>
    ///  VehicleColorsViewModel. Model of the vehicle.
    /// </summary>
    class VehicleColorsViewModel : GenericHelperViewModel<ColorDto, COLORFL>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataServices">DataServices to be used.</param>
        /// <param name="region">Region where the tab is present.</param>
        /// <param name="eventManager">Event manager to send and receive messages from other view models.</param>

        public VehicleColorsViewModel(IDataServices dataServices, IRegionManager region, IEventManager eventManager) : base(GenericSql.ColorTypes, dataServices, region, eventManager)
        {    
        }
        /// <summary>
        /// Set the unique code for the entity
        /// </summary>
        /// <param name="payLoad">Paylod to be received</param>
        /// <param name="dataServices">DataServices</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            ColorDto colorDto = new ColorDto();
            string colorId = await DataServices.GetHelperDataServices().GetMappedUniqueId<ColorDto, COLORFL>(colorDto);
            colorDto = payLoad.DataObject as ColorDto;
            if (colorDto != null)
            {
                colorDto.Code = colorId.Substring(0, 6);
            }
            return payLoad;
        }
       
    }
}
