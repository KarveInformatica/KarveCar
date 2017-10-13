using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
namespace KarveDataServices
{
    /// <summary>
    ///  Interface resposible for the dataservice.
    /// </summary>
    public interface IVehicleDataServices
    {
        /// <summary>
        /// This is the vehicles agent summary dataservice.
        /// </summary>
        /// <param name="pageSize">Page dimension. Data is not paged if pageSize is zero</param>
        /// <returns></returns>
        Task<DataSet> GetVehiclesAgentSummary(int pageSize);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IList<IVehicleData> GetVehicleDatas();
    }
}
