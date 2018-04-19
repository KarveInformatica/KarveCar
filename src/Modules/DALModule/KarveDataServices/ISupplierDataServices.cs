using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

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
       
        /// <summary>
        ///  This returns the dataset list.
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="setList"></param>
        void UpdateDataSetList(IDictionary<string, string> queries, IList<DataSet> setList);
      
        /// <summary>
        ///  Retrieve the asynchronous suppliers and store them in a dataset.
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
        Task<IEnumerable<SupplierSummaryDto>> GetSupplierAsyncSummaryDo();

        /// <summary>
        ///  Save a supplier object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> Save(ISupplierData data);
        /// <summary>
        ///  This returns a new identifier.
        /// </summary>
        /// <returns></returns>
        string GetNewId();
        #endregion
        /// <summary>
        ///  Returns a valid supplier given its code.
        /// </summary>
        /// <param name="validSupplierCode"></param>
        /// <returns></returns>
        Task<ISupplierData> GetAsyncSupplierDo(string validSupplierCode);
        /// <summary>
        ///  Assert delete async supplier do.
        /// </summary>
        /// <param name="supplierDataCode"></param>
        /// <returns></returns>
        Task<bool> DeleteAsyncSupplierDo(ISupplierData data);
        /// <summary>
        ///  Get a new supplier  data object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ISupplierData GetNewSupplierDo(string id);
        /// <summary>
        ///  This save supplier changes.
        /// </summary>
        /// <param name="supplierData"></param>
        /// <returns></returns>
        Task<bool> SaveChanges(ISupplierData supplierData);
        /// <summary>
        ///  This returns the contacts.
        /// </summary>
        /// <param name="codeId">id of the contacs</param>
        /// <returns></returns>
        Task<IEnumerable<ContactsDto>> GetAsyncContacts(string codeId);
    }
}
