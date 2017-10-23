using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace KarveDataServices
{
    /// <summary>
    ///  Interface resposible for the dataservice.
    /// </summary>
    public interface IVehicleDataServices
    {
        /// <summary>
        /// This give a paged version of a vehicle
        /// </summary>
        /// <param name="pageSize">Dimension of the page</param>
        /// <param name="offset">Offset to start with</param>
        /// <returns></returns>
        Task<DataSet> GetVehiclesAgentSummary(int pageSize, int offset);
        /// <summary>
        /// This returns a list of vehicle data.
        /// </summary>
        /// <returns></returns>
        IList<IVehicleData> GetVehicleDatas();

        /// <summary>
        /// Save vehicle
        /// </summary>
        /// <param name="vehicleData">Vehicle to be saved.</param>
        /// <returns></returns>
        Task<bool> SaveVehicle(IVehicleData vehicleData);

        /// <summary>
        /// Returns the data set associated with a vehicle
        /// </summary>
        /// <param name="queryList">List of query dictionary with associated table</param>
        /// <returns></returns>
        Task<IDataWrapper<IVehicleData>> GetAsyncVehicleInfo(IDictionary<string, string> queryList);

        /// <summary>
        /// This delete all the data relative to a single veichle.
        /// </summary>
        /// <param name="vehicleData">Vehicle data object</param>
        /// <returns></returns>
        Task<bool> DeleteVehicleData(IVehicleData vehicleData);

        /// <summary>
        /// This delete a vehicle. 
        /// </summary>
        /// <returns>Returns true or false in case of vehicle</returns>
        ///
        bool DeleteVehicle(string sqlQuery, string vehicleId, DataSet set);
        
    }
}
