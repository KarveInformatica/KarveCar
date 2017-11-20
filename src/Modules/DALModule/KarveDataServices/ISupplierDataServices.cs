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
    /// Public interface for the supplier usage,
    /// </summary>
    public interface ISupplierDataServices
    {

        #region Asynchronous methods
        /// <summary>
        ///  Returns the dataset in asynchronous way for all suppliers.
        /// </summary>
        /// <returns></returns>
        /// 
        Task<DataSet> GetAsyncAllSupplierSummary();
        
        /// <summary>
        /// Return synchnously the suppliers paged at 200 page size.
        /// </summary>
        /// <param name="startPos">Start position where compute the page</param>
        /// <returns></returns>
        DataSet GetSuppliersSummaryPaged(long startPos);
       
        /// <summary>
        /// Returns the complete suppliers information paged for 200 items.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncSuppliersSummaryPaged();
        
        //ISupplierData GetAsyncSupplierInfo()
        /// <summary>
        ///  Load a data set with all information needed for a given sheet.
        /// </summary>
        /// <param name="queryList"></param>
        /// <returns></returns>
        Task<DataSet> GetAsyncSupplierInfo(IDictionary<string, string> queryList);

        /// <summary>
        ///  Returns the delegations foreach supplier.
        /// </summary>
        /// <param name="supplierId">supplier code.</param>
        /// <returns>A tuple containing the executed query and the resulting data set.</returns>
        Task<Tuple<string, DataSet>> GetAsyncDelegations(string supplierId);
        /// <summary>
        /// Update the data set 
        /// </summary>
        /// <param name="queries">The dictionary of the queries per table</param>
        /// <param name="set">The dataset per table</param>
        void UpdateDataSet(IDictionary<string, string> queries, DataSet set);
        //List of dataset.

        void UpdateDataSetList(IDictionary<string, string> queries, IList<DataSet> setList);
      
        /// <summary>
        /// Return the supplier contacts asynchronously
        /// </summary>
        /// <param name="supplierId">supplier identifier</param>
        /// <returns></returns>
        Task<DataSet> GetAsyncSupplierContacts(string supplierId);
        /// <summary>
        /// This returns the asynchronous suppliers.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncSuppliers();

        /// <summary>
        /// This retursn a new supplier
        /// </summary>
        /// <param name="queryList">List of queries of the supplier</param>
        /// <returns></returns>
        Task<DataSet> GetNewSupplier(IDictionary<string, string> queryList);
        /// <summary>
        /// This is delete supplier.
        /// </summary>
        /// <param name="sqlQuery">Sql query</param>
        /// <param name="supplierId">Identifier of the supplier</param>
        /// <param name="supplierDataSet">DataSet</param>
        /// <returns></returns>
        bool DeleteSupplier(string sqlQuery,
            string supplierId,
            DataSet supplierDataSet);
        /// <summary>
        /// Delete a supplier.
        /// </summary>
        /// <param name="viewModelQueries"></param>
        /// <param name="primaryKey"></param>
        /// <param name="currentDataSet"></param>
        /// <returns></returns>
        bool DeleteSupplier(IDictionary<string, string> queries,  DataSet currentDataSet);
        /// <summary>
        ///  This returns a new identifier.
        /// </summary>
        /// <returns></returns>
        string GetNewId();


        #endregion
    }
}
