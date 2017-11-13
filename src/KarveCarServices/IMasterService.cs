using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Schema;
using KarveDataServices.DataTransferObject;

namespace KarveCarServices
{
    [ServiceContract]
    public interface IMasterService
    {
        [OperationContract]
        IList<VehicleDto> GetVehicleList();
        /// <summary>
        /// Supplier List.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<SupplierDto> GetSupplierList();
        /// <summary>
        /// Commission agent List
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        IList<ComisioDto> GetCommissionAgentList();
    }
}
