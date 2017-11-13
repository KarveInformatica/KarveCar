using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model.Interface
{
    public interface IVehicleData
    {
        /// <summary>
        ///  This delete all data in async way 
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAsyncData();
        /// <summary>
        /// Save the vehicle data.
        /// </summary>
        /// <returns></returns>
        Task<bool> Save();
        /// <summary>
        ///  Save all updates in the vehicle
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChanges();
        /// <summary>
        /// Load valed
        /// </summary>
        /// <param name="fields">Dictionary of the fields</param>
        /// <param name="cCodiint">Vehicle code primary key</param>
        /// <returns></returns>
        Task<bool> LoadValue(IDictionary<string, string> fields, string cCodiint);
        /// <summary>
        /// Vehicle Data.
        /// </summary>
        object Value { set; get; }
        /// <summary>
        ///  This tells us if the data is valid or not.
        /// </summary>
        bool Valid { get; set; }
    }
}