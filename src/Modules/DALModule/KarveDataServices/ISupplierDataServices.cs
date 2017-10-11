using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;


namespace KarveDataServices
{


    public static class SupplierPayLoad
    {
        public const string SupplierDOName = "SupplierDataObjectInfo";
        public const string SupplierDOType = "SupplierDataObjectType";
        public const string SupplierAccountingDO = "SupplierAccountDataObject";
        public const string SupplierMonitoringDS = "SupplierMonitoringDataSet";
        public const string SupplierEvaluationDS = "SupplierEvaluationDataSet";
        public const string SupplierTransportDS = "SupplierTransportDataSet";
        public const string SupplierAssuranceDS = "SupplierAssuranceDataSet";
        public const string SupplierContactsDS = "SupplierContactsDataSet";
        public const string SupplierVisitsDS = "SupplierVisitsDataSet";
        public const string SupplierBranchesDS = "SupplierBranchesDataSet";
        public const string SupplierContactsChangedField = "SupplierContactsChanged";
        public const string SupplierSummaryTable = "SupplierSummaryTable";
    }

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
        /// Returns the supplier type information from the supplier id.
        /// </summary>
        /// <param name="id">supplier code</param>
        /// <returns></returns>
        Task<ISupplierTypeData> GetAsyncSupplierTypeById(string supplierId);
        /// <summary>
        /// Returns the complete suppliers information paged for 200 items.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncSuppliersSummaryPaged();
        
        
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
        /// <returns></returns>
        Task<DataSet> GetAsyncDelegations(string supplierId);
        /// <summary>
        ///  Returns the visits for a given supplier.
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        Task<DataSet> GetAsyncVisits(string clientId);
        /// <summary>
        ///  Returns an evaluation note for a supplier.
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        Task<DataSet> GetEvaluationNote(string supplierId);

        /// <summary>
        /// Update the data set 
        /// </summary>
        /// <param name="queries">The dictionary of the queries per table</param>
        /// <param name="set">The dataset per table</param>
        void UpdateDataSet(IDictionary<string, string> queries, DataSet set);
        //List of dataset.

        void UpdateDataSetList(IDictionary<string, string> queries, IList<DataSet> setList);
        /// <summary>
        ///  Returns the async evaluation note
        /// </summary>
        /// <param name="supplierId">supplier identifier</param>
        /// <returns></returns>
        Task<DataSet> GetAsyncEvaluationNote(string supplierId);
        
        /// <summary>
        /// Return the supplier transport information.
        /// </summary>
        /// <param name="supplierId">supplier identifier</param>
        /// <returns></returns>
        Task<DataSet> GetAsyncTransportProviderData(string supplierId);
        /// <summary>
        /// Returns the async supplier assurance data given a supplerId
        /// </summary>
        /// <param name="supplierId">supplier identifier</param>
        /// <returns></returns>       
        Task<DataSet> GetAsyncSupplierAssuranceData(string supplierId);
        /// <summary>
        /// Return the supplier contacts asynchronously
        /// </summary>
        /// <param name="supplierId">supplier identifier</param>
        /// <returns></returns>
        Task<DataSet> GetAsyncSupplierContacts(string supplierId);
        /// <summary>
        /// Returns the asynchrnous monitoring
        /// </summary>
        /// <param name="supplierId">supplier identifier</param>
        /// <returns></returns>
        Task<DataSet> GetAsyncMonitoring(string supplierId);
        /// <summary>
        /// This returns the asynchronous suppliers.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncSuppliers();
        
        /// <summary>
        /// Generate a new id.
        /// </summary>
        /// <returns></returns>
        string GetNewId();
        // This supplier id.
        Task<DataSet> GetNewSupplier(IDictionary<string, string> queryList);

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


        #endregion
    }
}
