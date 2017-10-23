using System.Data;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using System.Collections.Generic;

namespace KarveDataServices
{
    /// <summary>
    ///  This implements the commission agent data services.
    /// It is a dual interface that can work with data objects and with DataSet
    /// </summary>
    public interface ICommissionAgentDataServices
    {
        /// <summary>
        ///  Get the data object of the commission agent.
        /// </summary>
        /// <param name="queryDictionary">This return the </param>
        /// <param name="commissionAgentId">query to build the commission agent</param>
        /// <returns>Return the data object of the commisssion agent</returns>
        Task<IDataWrapper<ICommissionAgent>> GetCommissionAgentDo(IDictionary<string, string> queryDictionary, string commissionAgentId);
        /// <summary>
        ///  Get the data set of a commission agent.
        /// </summary>
        /// <returns>Returns the dataset of a commission agent</returns>
        Task<IDataWrapper<ICommissionAgent>> GetCommissionAgent(IDictionary<string, string> query);
        /// <summary>
        /// Get the commission agent collection
        /// </summary>
        /// <param name="isPaged">IsPaged</param>
        /// <param name="pageSize">Dimension of the page</param>
        /// <returns></returns>
        Task<IEnumerable<ICommissionAgent>> GetCommissionAgentCollection(bool isPaged = false, long pageSize = 0);
        /// <summary>
        /// This returns the a new commission agent.
        /// </summary>
        /// <returns></returns>
        ICommissionAgent GetNewCommissionAgentDo();
        /// <summary>
        /// This returns the dataset of the commisison agent.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetAsyncCommissionAgent();
        /// <summary>
        /// Save commission agent data services.
        /// </summary>
        /// <param name="commissionAgent"></param>
        /// <returns></returns>
        Task<bool> SaveCommissionAgent(ICommissionAgent commissionAgent);
        /// <summary>
        /// This returns the data set of the commission agent.
        /// </summary>
        /// <param name="commissionAgent">Commission agent to delete</param>
        /// <returns>True if the commission agent has been deleted with succcess.</returns>
        Task<bool> DeleteCommissionAgent(ICommissionAgent commissionAgent);
        /*
        /// <summary>
        /// Get the commission agent summary in an ADO.NET database.
        /// </summary>
        /// <param name="paged">optional parameter indicating if the agent shall be paged</param>
        /// <param name="pageSize">optional parameter indicating the dimension of the page size</param>
        /// <returns></returns>
        Task<DataSet> GetCommissionAgentSummary(bool paged = false, long pageSize = 0);
        /// <summary>
        /// Get the commission agent list of objects.
        /// <param name="maxSize">Maximum size of the page, if 0 paging is disabled</param>
        /// </summary>
        /// <returns> A list of object up to max size in case of paging</returns>
        Task<IList<KarveDataServices.DataObjects.ICommissionAgent>> GetCommissionAgentDoList(long maxSize = 0);
        /// <summary>
        /// This return a new fresh supplier with a dictionary of queries.
        /// </summary>
        /// <param name="queryList"></param>
        /// <returns>A dataset of the all tables of the supplier</returns>
        Task<DataSet> GetNewCommissionAgent(IDictionary<string, string> queryList);
        /// <summary>
        /// This returns a new commission agent data object with a querylist.
        /// </summary>
        /// <returns></returns>
        Task<ICommissionAgent> GetNewCommissionAgentDo(IDictionary<string, string> commissionAgent);
        /// <summary>
        ///  This deletes a commission agent from the database with optional validation rules. 
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="supplierId"></param>
        /// <param name="supplierDataSet"></param>
        /// <returns></returns>
        bool DeleteCommissionAgent(string sqlQuery, string supplierId, DataSet supplierDataSet);
        /// <summary>
        /// Delete a supplier.
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="currentDataSet"></param>
        /// <returns></returns>
        bool DeleteCommissionAgents(IDictionary<string, string> queries, DataSet currentDataSet, IList<ValidationRule> validationRules);
        /// <summary>
        /// Delete a commission agent data object.
        /// </summary>
        /// <param name="commissionAgent">commission agent data object</param>
        /// <param name="queriesDictionary">query dictionary associated to the data object.</param>
        /// <returns></returns>
        Task<bool> DeleteCommissionAgentDo(ICommissionAgent commissionAgent, IDictionary<string, string> queriesDictionary);
        */
    }
}