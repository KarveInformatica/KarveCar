using System.Collections.Generic;
using System.Data;
using System;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;
using Dapper;
using DataAccessLayer.Model;
using KarveDataServices.DataTransferObject;
using NLog;
using DataAccessLayer.SQL;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;

namespace DataAccessLayer
{
    /// <summary>
    /// CommissionAgentAccessLayer.
    /// This returns an abstact access layer.
    /// </summary>
    internal class CommissionAgentAccessLayer : AbstractDataAccessLayer, ICommissionAgentDataServices
    {
        /// <summary>
        /// Sql query executor. This is the sql executor for ADO.NET
        /// </summary>
        private readonly ISqlExecutor _sqlExecutor;

        private const string PrimaryKey = "NUM_COMI";
        private const string CommissionAgentTable = "COMISIO";
        private const string CommissionAgentFile = @"\Data\CommissionAgentFields.xml";
        private Logger logger = LogManager.GetLogger("CommisionAgentAccessLayer");
        private QueryStoreFactory _queryStoreFactory = new QueryStoreFactory();

        /// <summary>
        /// CommissionAgentAccessLayer
        /// </summary>
        /// <param name="executor">Executro of a query</param>
        public CommissionAgentAccessLayer(ISqlExecutor executor): base(executor)
        {
            _sqlExecutor = executor;
            base.InitData(CommissionAgentFile);
        }
        /// <summary>
        ///  This returns to us a commission agent object.
        /// </summary>
        /// <param name="queryDictionary">Dictionary of fields to be included in the query.</param>
        /// <param name="commissionAgentId">Agent id to be fetched</param>
        /// <returns>The commission agent list.</returns>
        public async Task<ICommissionAgent> GetCommissionAgentDo( string commissionAgentId, IDictionary<string, string> queryDictionary = null)
        {
            IDictionary<string, string> queries;
            logger.Debug("GetCommissionAgentData Object");
            if (queryDictionary == null)
            {
                queries= base.baseQueryDictionary;
            }
            else
            {
                queries = queryDictionary;
            }
            CommissionAgentFactory agentFactory = CommissionAgentFactory.GetFactory(_sqlExecutor);
            ICommissionAgent createdAgent =  await agentFactory.GetCommissionAgent(queries, commissionAgentId);
            return createdAgent;
        }
        /// <summary>
        /// Gives us a commission agent collection list
        /// </summary>
        /// <param name="fields">Fields to be present in the query</param>
        /// <param name="pageSize">Page dimension</param>
        /// <param name="startAt">Initialization of the object</param>
        /// <returns>Return the list commission agents.</returns>
        public async Task<IList<ICommissionAgent>> GetCommissionAgentCollection(IDictionary<string,string> fields, int pageSize = 0, int startAt =0)
        {
            logger.Debug("GetCommissionAgentCollection ");
            CommissionAgentFactory commissionAgentFactory = CommissionAgentFactory.GetFactory(_sqlExecutor);
            IList<ICommissionAgent> commissionAgents = await commissionAgentFactory.CreateCommissionAgentList(fields, pageSize, startAt);
            return commissionAgents;
        }

        /// <summary>
        /// Get the commission agent summary in an ADO.NET database.
        /// </summary>
        /// <param name="paged">optional parameter indicating if the agent shall be paged</param>
        /// <param name="pageSize">optional parameter indicating the dimension of the page size</param>
        /// <returns>Returns the data set of all commission agents present in the system.</returns>
        public async Task<DataSet> GetCommissionAgentSummary(bool paged = false, long pageSize = 0)
        {
            DataSet dataset = await _sqlExecutor.AsyncDataSetLoad(GenericSql.CommissionAgentSummaryQuery).ConfigureAwait(false);
            logger.Debug("GetCommissionAgentSummary " + GenericSql.CommissionAgentSummaryQuery);
            if (dataset == null)
            {
                logger.Debug("GetCommissionAgent Null DataSet ");
            }
            return dataset;
        }

        /// <summary>
        ///  Retrieve the list of all commission agents and convert them in a data transfer object list.
        /// </summary>
        /// <returns>The list of commission agents</returns>
        public async Task<IEnumerable<CommissionAgentSummaryDto>> GetCommissionAgentSummaryDo()
        {
            IEnumerable<CommissionAgentSummaryDto> summary = new ObservableCollection<CommissionAgentSummaryDto>();
            IQueryStore store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryCommissionAgentSummary);
            var query = store.BuildQuery();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        summary = await connection.QueryAsync<CommissionAgentSummaryDto>(query).ConfigureAwait(false);
                    }
                } catch (System.Exception ex)
                {
                    throw new DataLayerException("CommissionAgentLoadException", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            return summary;
        }
        /// <summary>
        /// This is the generation of an unique identifier.
        /// </summary>
        /// <returns>Identifier of the commission agents</returns>
        public string GetNewId()
        {
            string id = string.Empty;
            using (IDbConnection conn = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    COMISIO comisio = new COMISIO();
                    id = conn.UniqueId<COMISIO>(comisio);

                }
                catch (System.Exception ex)
                {
                    throw new DataLayerException("CommissionAgentNewId", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
            return id;
        }
        /// <summary>
        /// New commission agent
        /// </summary>
        /// <returns>Returns the commission agent.</returns>
        public ICommissionAgent GetNewCommissionAgentDo()
        {
            CommissionAgentFactory factory = CommissionAgentFactory.GetFactory(_sqlExecutor);
            string id = GetNewId();
            logger.Debug("GetCommissionAgent " + id);
            ICommissionAgent agent =  factory.NewCommissionAgent(id);
            return agent;
        }
        /// <summary>
        /// New commission agent
        /// </summary>
        /// <returns>Returns the commission agent.</returns>
        public ICommissionAgent GetNewCommissionAgentDo(string id)
        {
            CommissionAgentFactory factory = CommissionAgentFactory.GetFactory(_sqlExecutor);
            ICommissionAgent agent = factory.NewCommissionAgent(id);
            return agent;
        }
        /// <summary>
        /// Save commission agent
        /// </summary>
        /// <param name="commissionAgent">Commission Agent to be saved.</param>
        /// <returns>Returns true if the commission agent has been changed.</returns>
        public async Task<bool> SaveCommissionAgent(ICommissionAgent commissionAgent)
        {
            bool changedTask = await commissionAgent.Save().ConfigureAwait(false);
            return changedTask;
        }
       
        /// <summary>
        /// Save commission agent.
        /// </summary>
        /// <param name="commissionAgent">Commission agent saved.</param>
        /// <returns>True when the commission agent has been deleted.</returns>
        public async Task<bool> DeleteCommissionAgent(ICommissionAgent commissionAgent)
        {
            bool value = false;

            IDbConnection connection = _sqlExecutor.Connection;
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                value = await commissionAgent.DeleteAsyncData().ConfigureAwait(false);
            }
            if (!value)
            {
                logger.Debug("Failed to delete commission agent");
            }
            return value;
        }
        /// <summary>
        /// Delete a commission agent
        /// </summary>
        /// <param name="sqlQuery">Query of the commission agent.</param>
        /// <param name="commissionAgentId">Id of the commission agent.</param>
        /// <param name="set">DataSet of the commission agent. It contains all tables related to the commission agent.</param>
        /// <returns>Return true when a commission agent has been deleted.</returns>
        public bool DeleteCommissionAgent(string sqlQuery, string commissionAgentId, DataSet set)
        {
            if (set == null)
            {
                return false;
            }
            return DeleteData(sqlQuery,commissionAgentId,PrimaryKey,set);
        }
    }
}