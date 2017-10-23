using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Controls;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using Dapper;
using DataAccessLayer;
using DataAccessLayer.DataObjects;


namespace DataAccessLayer
{
    /// <summary>
    /// CommissionAgentAccessLayer.
    /// </summary>
    internal class CommissionAgentAccessLayer : ICommissionAgentDataServices
    {
        /// <summary>
        /// Sql query executor. This is the sql executor for ADO.NET
        /// </summary>
        private readonly ISqlQueryExecutor _sqlQueryExecutor;
        /// <summary>
        /// 
        /// </summary>
        public class CommissionAgentAccessLayer(ISqlQueryExecutor sqlQueryExecutor)
        {
            _sqlQueryExecutor = sqlQueryExecutor;
        }
        public async Task<IDataWrapper<ICommissionAgent>> GetCommissionAgentDo(IDictionary<string, string> queryDictionary, string commissionAgentId)
        {
            CommissionAgent agent = new  CommissionAgent(_sqlQueryExecutor);
            await agent.LoadSingleValue(queryDictionary, commissionAgentId);
            DataWrapper<CommissionAgent> wrapper = new DataWrapper<CommissionAgent>();
            wrapper.HasDataObject = true;
            wrapper.Value = agent;
        }

        public Task<IDataWrapper<ICommissionAgent>> GetCommissionAgentDo(string commissionAgentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IDataWrapper<ICommissionAgent>> GetCommissionAgent(IDictionary<string, string> query)
        {
             DataWrapper<CommissionAgent> wrapper
        }

        public Task<IEnumerable<ICommissionAgent>> GetCommissionAgentCollection(bool isPaged = false, long pageSize = 0)
        {
            throw new System.NotImplementedException();
        }

        public ICommissionAgent GetNewCommissionAgentDo()
        {
            throw new System.NotImplementedException();
        }

        public Task<DataSet> GetAsyncCommissionAgent()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveCommissionAgent(ICommissionAgent commissionAgent)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCommissionAgent(ICommissionAgent commissionAgent)
        {
            throw new System.NotImplementedException();
        }
    }
}