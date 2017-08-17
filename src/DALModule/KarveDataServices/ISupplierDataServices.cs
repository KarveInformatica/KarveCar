using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace KarveDataServices
{
    /// <summary>
    ///  common interface for the 
    /// </summary>
    public interface ISupplierDataServices
    {

        #region Asynchronous methods
        /// <summary>
        ///  Returns the dataset in asynchronous way for all suppliers.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncAllSupplierSummary();
        /// <summary>
        /// This retrives the data supplier type for a given data object
        /// </summary>
        /// <param name="id"> data object id.</param>
        /// <returns></returns>
        Task<ISupplierTypeDataObject> GetAsyncSupplierTypesDataObject(string id);
        /// <summary>
        /// This retrives the data object info for a given data object
        /// </summary>
        /// <param name="id"> data object id.</param>
        /// <returns></returns>
        Task<ISupplierDataObjectInfo> GetAsyncSupplierDataObjectInfo(string id);
        #endregion
    }
}
