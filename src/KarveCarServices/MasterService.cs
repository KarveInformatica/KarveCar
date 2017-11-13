using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace KarveCarServices
{
    // TODO: complete this.
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MasterService : IMasterService
    {
        /// <summary>
        ///  simple data service injection.
        /// </summary>
        private IDataServices _dataServices;

        public MasterService(IDataServices services)
        {
            _dataServices = services;
        }
        
/// <summary>
///  This returns the vehicle list.
/// </summary>
/// <returns></returns>
        public IList<VehicleDto> GetVehicleList()
        {
                return new List<VehicleDto>();    
        }
    /// <summary>
    /// This returns the supplier list.
    /// </summary>
    /// <returns></returns>
        public IList<SupplierDto> GetSupplierList()
        {
            return new List<SupplierDto>();
        }
    /// <summary>
    ///  This returns the commission agent list.
    /// </summary>
    /// <returns></returns>
        public IList<ComisioDto> GetCommissionAgentList()
        {
            return new List<ComisioDto>();
        }
    }
}
