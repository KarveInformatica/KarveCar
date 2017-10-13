using System.Data;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace KarveDataServices
{
    /// <summary>
    ///  This implements the commission agent data services.
    /// It is a dual interface that can work with data objects and with DataSet
    /// </summary>
    public interface ICommissionAgentDataServices
    {
        /// <summary>
        ///  Get the dataset of a commission agent given its id.
        /// </summary>
        /// <param name="query">query to build the commission agent</param>
        /// <returns></returns>
        Task<DataSet> GetCommissionAgent(IDictionary<string, string> query);
        /// <summary>
        ///  Get the commission agent data object given its id.
        /// </summary>
        /// <param name="query">Query to build the commission agent data object and its dependecies.</param>
        /// <returns></returns>
        Task<KarveDataServices.DataObjects.ICommissionAgent> GetCommissionAgentDo(IDictionary<string, string> query);
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

    }
}