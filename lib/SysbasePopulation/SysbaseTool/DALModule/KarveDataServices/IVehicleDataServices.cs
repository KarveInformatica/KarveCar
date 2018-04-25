using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    /// <summary>
    ///  Interface for the vehicle data services.
    /// </summary>
    public interface IVehicleDataServices
    {
        /// <summary>
        /// This give a paged version of a vehicles summary
        /// </summary>
        /// <param name="pageSize">Dimension of the page</param>
        /// <param name="offset">Offset to start with</param>
        /// <remarks>
        ///     A simple use it can be:
        ///     var summaries = await service.GetVehiclesAgentSummary(10, 0); First 10 results.
        ///     var summaries = await service.GetVehiclesAgentSummary(10, 10); Results from 10 to 20.
        /// </remarks>
        /// <returns>
        /// A list of vehicles summary, where are specified the different features of the vehicles
        /// </returns>
        Task<IEnumerable<VehicleSummaryDto>> GetVehiclesAgentSummary(int pageSize, int offset);
        /// <summary>
        ///  Function to fetch the full list of the vehicles summaries in the system.
        /// </summary>
        /// <returns>
        /// A list of vehicles summary, where are specified the different features of the vehicles
        /// </returns>
        Task<IEnumerable<VehicleSummaryDto>> GetAsyncVehicleSummary();
        
        /// <summary>
        /// This saves a new inserted vehicle
        /// </summary>
        /// <param name="vehicleData">Vehicle to be saved.</param>
        /// <returns></returns>
        Task<bool> SaveVehicle(IVehicleData vehicleData);
        /// <summary>
        ///  This gives us a new id to assign to a vehicle.
        /// </summary>
        /// <returns></returns>
        string GetNewId();
        /// <summary>
        ///  This gives us a get vehicle data object
        /// </summary>
        /// <param name="primaryKeyValue">Primary key of the object</param>
        /// <returns></returns>
        Task<IVehicleData> GetVehicleDo(string primaryKeyValue);
      
        /// <summary>
        ///  This give us a delete vehicle data object
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        Task<bool> DeleteVehicleDo(IVehicleData vehicle);
        /// <summary>
        ///  This delete all the async data inside a vehicle.
        /// </summary>
        /// <param name="vehicleData"></param>
        /// <returns></returns>
         Task<bool> DeleteVehicleData(IVehicleData vehicleData);
        /// <summary>
        ///  This create a new vehicle given the primary key
        /// </summary>
        /// <param name="primaryKeyValue"></param>
        /// <returns></returns>
        IVehicleData GetNewVehicleDo(string primaryKeyValue);
        /// <summary>
        /// This give to us a async vehicles list.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IVehicleData>> GetAsyncVehicles();
        /// <summary>
        /// This save a new vehicle. It performs a vehicle update
        /// </summary>
        /// <param name="data">This are the data to be saved in a vehicle</param>
        /// <returns></returns>
        Task<bool> SaveChangesVehicle(IVehicleData data);
    }
}
