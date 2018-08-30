using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataAccessLayer.DataObjects;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;

namespace HelperModule.ViewModels
{

    /// <summary>
    ///  VehicleColorsViewModel. Model of the vehicle.
    /// </summary>
    class VehicleColorsViewModel : GenericHelperViewModel<ColorViewObject, COLORFL>
    {
        private string _assist;
        
        // TODO: generic 
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataServices">DataServices to be used.</param>
        /// <param name="region">Region where the tab is present.</param>
        /// <param name="eventManager">Event manager to send and receive messages from other view models.</param>

        public VehicleColorsViewModel(IDataServices dataServices, IRegionManager region, IEventManager eventManager, IDialogService service, IConfigurationService config) : base(GenericSql.ColorTypes, dataServices, region, eventManager, service, config)
        {
            var assistList = new StringBuilder();
            
            assistList.Append("Name,");
            assistList.Append("PowderCoating,");
            assistList.Append("TwoTone,");
            assistList.Append("NoCoating");
            AssistProperties = assistList.ToString();
        }

        public string AssistProperties
        {
            set { _assist = value; RaisePropertyChanged(); }
            get { return _assist; }
        }
        /// <summary>
        /// Set the unique code for the entity
        /// </summary>
        /// <param name="payLoad">Paylod to be received</param>
        /// <param name="dataServices">DataServices</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            ColorViewObject colorViewObject = new ColorViewObject();
            string colorId = await DataServices.GetHelperDataServices().GetMappedUniqueId<ColorViewObject, COLORFL>(colorViewObject);
            colorViewObject = payLoad.DataObject as ColorViewObject;
            if (colorViewObject != null)
            {
                colorViewObject.Code = colorId.Substring(0, 6);
            }
            return payLoad;
        }
       
    }
}
