using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveDataServices.DataTransferObject;

namespace MasterModule.Views.VehicleAssurance.MockViewModels
{
    /// <summary>
    ///  VehicleAsssurance.
    /// </summary>
    public class VehicleAssuranceMockViewModel
    {
        private VehicleDto vehicleDto = new VehicleDto();
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
               vehicleDto = (VehicleDto)value;
            }
            get
            {
                return vehicleDto;
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
