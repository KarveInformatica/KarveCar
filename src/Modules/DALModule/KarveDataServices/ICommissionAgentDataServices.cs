using System.Data;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
using System.Collections.Generic;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    /// <summary>
    ///  This implements the commission agent data services.
    /// It is a dual interface that can work with data objects and with DataSet
    /// </summary>
    public interface ICommissionAgentDataServices: IPageCounter, ISorterData<CommissionAgentSummaryDto>, IIdentifier, IDataProvider<ICommissionAgent, CommissionAgentSummaryDto>
    {
        /// <summary>
        /// Get the commission agent data obejct
        /// </summary>
        /// <param name="commissionAgentId">Commission agent id</param>
        /// <param name="queryDictionary">Query dictionary</param>
        /// <returns></returns>
        Task<ICommissionAgent> GetCommissionAgentDo( string commissionAgentId, IDictionary<string, string> queryDictionary=null);
      
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
        /// Get the commission agent summary in an ADO.NET database.
        /// </summary>
        /// <param name="paged">optional parameter indicating if the agent shall be paged</param>
        /// <param name="pageSize">optional parameter indicating the dimension of the page size</param>
        /// <returns></returns>
        Task<DataSet> GetDataSetSummaryAsync(bool paged = false, long pageSize = 0);
        
     }
}