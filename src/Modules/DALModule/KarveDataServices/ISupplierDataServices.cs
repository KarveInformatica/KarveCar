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
        /// This retrives the data supplier type for a given data object
        /// </summary>
        /// <param name="id"> data object id.</param>
        /// <returns></returns>
        Task<ISupplierTypeData> GetAsyncSupplierTypesDataObject(string id);
        /// <summary>
        /// This retrives the data object info for a given data object
        /// </summary>
        /// <param name="id"> data object id.</param>
        /// <returns></returns>
        Task<ISupplierDataInfo> GetAsyncSupplierDataObjectInfo(string id);
        /// <summary>
        /// This retrives all complete summary from proveedores from provve1 and provve2.
        /// </summary>
        /// <returns>Returns a dataset from complete summary.</returns>
        Task<DataSet> GetAsyncCompleteSummary();
        /// <summary>
        /// This returns all async provider types.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncAllProviderTypes();
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
        ///  Returns TIPOCOMP. 
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        Task<DataSet> GetAsyncProviderType(string supplierId);
        /// <summary>
        /// This insert a new supplier in the database.
        /// </summary>
        /// <param name="info"> General information about the supplier</param>
        /// <param name="td">Type of the supplier</param>
        /// <param name="ao">Account object information</param>
        /// <param name="monitoringData">DataSet for monitoring the data</param>
        /// <param name="evaluationData">DataSet of the evaluation</param>
        /// <param name="transportData">DataSet of the transport</param>
        /// <param name="assuranceProviderData">DataSet for the assurance</param>
        /// <param name="contactsChanged">Value to check if the contacts are changed</param>
        /// <param name="visitsData">Data of the visit</param>
        /// <returns></returns>
        Task<bool> Insert(ISupplierDataInfo info, 
                    ISupplierTypeData td, 
                    ISupplierAccountObjectInfo ao, 
                    DataSet monitoringData, 
                    DataSet evaluationData, 
                    DataSet transportData, 
                    DataSet assuranceProviderData, 
                    bool contactsChanged, 
                    DataSet visitsData);

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
        
        /// <summary>
        ///  Return the supplier data object in asynchnouns way
        /// </summary>
        /// <param name="supplierId">Supplier Id</param>
        /// <param name="env">Enviroment variables</param>
        /// <returns></returns>
        Task<ISupplierAccountObjectInfo> GetAsyncSupplierAccountInfo(string supplierId, object env);
        /// <summary>
        ///  Returns the async evaluation note
        /// </summary>
        /// <param name="supplierId">supplier identifier</param>
        /// <returns></returns>
        Task<DataSet> GetAsyncEvaluationNote(string supplierId);
        void UpdateTable(DataTable table);

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
        /// Update the asynchronous supplier identifier.
        /// </summary>
        /// <param name="dataInfo">Data object for the supplier</param>
        /// <param name="dataType">Data object for the supplier type</param>
        /// <param name="ao">Data set for the accounting information for the supplier</param>
        /// <param name="monitoringData">Data set for the monitoring information for the supplier</param>
        /// <param name="evaluationData">Data set for the evaluation data for the supplier</param>
        /// <param name="transportProviderData">Data set for the transport for the supplirt</param>
        /// <param name="assuranceProviderData">Data set for the assurance data provider </param>
        /// <param name="contactsProviderData">Data set for the contacts</param>
        /// <param name="visitsProviderData">Data set for the visits</param>
        /// <param name="contactsChanged">Check if the contact are changed.</param>
        /// <returns>true if the update is correct. It may launch an exception.</returns>
        Task<bool> Update(ISupplierDataInfo dataInfo, ISupplierTypeData dataType, 
                        ISupplierAccountObjectInfo ao, DataSet monitoringData, DataSet evaluationData, 
                        DataSet transportProviderData, DataSet assuranceProviderData, 
                        DataSet contactsProviderData, DataSet visitsProviderData, bool contactsChanged);
        /// <summary>
        /// Open a session to the database provider
        /// </summary>
        void OpenDataSession();
        /// <summary>
        /// Close a session to the database provider.
        /// </summary>
        void CloseDataSession();

        Task<DataSet> GetAsyncSuppliers();

        #endregion
    }
}
