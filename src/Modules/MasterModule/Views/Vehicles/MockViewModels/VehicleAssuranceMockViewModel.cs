using System.Windows.Input;
using KarveDataServices.ViewObjects;

namespace MasterModule.Views.Vehicles.MockViewModels
{
    /// <summary>
    ///  VehicleAsssurance.
    /// </summary>
    public class VehicleAssuranceMockViewModel
    {
        private VehicleViewObject _vehicleViewObject = new VehicleViewObject();
        /// <summary>
        ///  mock assit command
        /// </summary>
        public ICommand AssistCommand { set; get; }
        /// <summary>
        ///  mock assurance query for assurance control
        /// </summary>
        public string AssuranceQuery { set; get; }
        /// <summary>
        ///  mock assurance data object
        /// </summary>
        public object DataObject {
            set
            {
               _vehicleViewObject = (VehicleViewObject)value;
            }
            get
            {
                return _vehicleViewObject;
            }
        }
        /// <summary>
        ///  item changed command
        /// </summary>
        public ICommand ItemChangedCommand { set; get; }
        /// <summary>
        ///  mock data object for 
        /// </summary>
        public object MetaDataObject { set; get; }
        /// <summary>
        ///  agent query.
        /// </summary>
        public object AgentQuery { set; get; }

        /// <summary>
        /// Constants strings.
        /// </summary>
        public StringConstants StringConstants
        {
            get
            {
                StringConstants sc = new StringConstants();
                return sc;
            }
            
        }
    }
}
