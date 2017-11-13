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
        /// Get the commission agent data obejct
        /// </summary>
        /// <param name="commissionAgentId">Commission agent id</param>
        /// <param name="queryDictionary">Query dictionary</param>
        /// <returns></returns>
        Task<ICommissionAgent> GetCommissionAgentDo( string commissionAgentId, IDictionary<string, string> queryDictionary=null);
        /// <summary>
        ///  Get the data set of a commission agent.
        /// </summary>
        /// <returns>Returns the dataset of a commission agent</returns>
        Task<DataSet> GetCommissionAgent(IDictionary<string, string> query);
        
        /// <summary>
        /// Return the commission agent collection
        /// </summary>
        /// <param name="fields">  Fields of the database to be filled</param>
        /// <param name="pageSize">Dimension of the page.</param>
        /// <param name="startAt">Start at page.</param>
        /// <returns></returns>
        Task<IList<ICommissionAgent>> GetCommissionAgentCollection(IDictionary<string, string> fields, int pageSize = 0,
            int startAt = 0);
        /// <summary>
        /// This returns the a new commission agent.
        /// </summary>
        /// <returns></returns>
        ICommissionAgent GetNewCommissionAgentDo();
        /// <summary>
        /// This returns a new commission agent id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ICommissionAgent GetNewCommissionAgentDo(string id);
        /// <summary>
        /// This returns a commmission agent dataset.
        /// </summary>
        /// <param name="queryList"></param>
        /// <returns></returns>
        Task<DataSet> GetAsyncCommissionAgentInfo(IDictionary<string, string> queryList);
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
        /// <summary>
        /// This delete the commission agent given an id.
        /// </summary>
        /// <param name="sqlQuery">Sql Query to be used in case of deleting</param>
        /// <param name="commissionAgentId">Id to be deleted</param>
        /// <param name="set">DataSet to be deleted</param>
        /// <returns></returns>
        bool DeleteCommissionAgent(string sqlQuery, string commissionAgentId, DataSet set);
        /// <summary>
        /// Get the commission agent summary in an ADO.NET database.
        /// </summary>
        /// <param name="paged">optional parameter indicating if the agent shall be paged</param>
        /// <param name="pageSize">optional parameter indicating the dimension of the page size</param>
        /// <returns></returns>
        Task<DataSet> GetCommissionAgentSummary(bool paged = false, long pageSize = 0);
        /// <summary>
        /// This is the primary key.
        /// </summary>
        /// <returns></returns>
        string GetNewId();
        /// <summary>
        /// This saves the changes in the commision agent for updating.
        /// </summary>
        /// <param name="commissionAgent"></param>
        /// <returns></returns>
        Task<bool> SaveChangesCommissionAgent(ICommissionAgent commissionAgent);
    }
}