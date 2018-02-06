using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using Model;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Transactions;
using AutoMapper;
using Dapper;
using DataAccessLayer.Model;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;
using NLog;


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
        /// <returns></returns>
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
        ///  This returns a commission agent dataset.
        /// </summary>
        /// <param name="query">Dictionary of the queries</param>
        /// <returns></returns>
        public async Task<DataSet> GetCommissionAgent(IDictionary<string, string> query)
        {
            logger.Debug("GetCommissionAgentDataSet " + query);
            DataSet set = await _sqlExecutor.AsyncDataSetLoadBatch(query);
            return set;
        }
        /// <summary>
        /// Gives us a commission agent collection list
        /// </summary>
        /// <param name="fields">Fields to be present in the query</param>
        /// <param name="pageSize">Page dimension</param>
        /// <param name="startAt">Initialization of the object</param>
        /// <returns></returns>
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
        /// <returns></returns>
        public async Task<DataSet> GetCommissionAgentSummary(bool paged = false, long pageSize = 0)
        {
            DataSet dataset = await _sqlExecutor.AsyncDataSetLoad(GenericSql.CommissionAgentSummaryQuery);
            logger.Debug("GetCommissionAgentSummary " + GenericSql.CommissionAgentSummaryQuery);
            if (dataset == null)
            {
                logger.Debug("GetCommissionAgent Null DataSet ");
            }
            return dataset;
        }

        public async Task<IEnumerable<CommissionAgentSummaryDto>> GetCommissionAgentSummaryDo()
        {
            IEnumerable<CommissionAgentSummaryDto> summary = new ObservableCollection<CommissionAgentSummaryDto>();
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    summary = await connection.QueryAsync<CommissionAgentSummaryDto>(GenericSql.CommissionAgentSummaryQuery);
                }
            }
            return summary;
        }
        /// <summary>
        /// This is the generation of an unique identifier.
        /// </summary>
        /// <returns></returns>
        public string GetNewId()
        {
            return GenerateUniqueId();
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

        protected override bool UniqueId(string id)
        {
            string str = "SELECT NUM_COMI FROM COMISIO WHERE NUM_COMI='{0}'";
            str = string.Format(str, id);
            IDbConnection connection = _sqlExecutor.Connection;
            IEnumerable<string> strResult = connection.Query<string>(str);
            logger.Info("Connect a select string " + str);
            bool unique = (!strResult.Any());
            return unique;
        }
        
        /// <summary>
        ///  This returns a commission agent dataset 
        /// </summary>
        /// <param name="queryList">This gives us a </param>
        /// <returns>Return a dataset with the new commission agent fields</returns>
        public async Task<DataSet> GetNewCommissionAgent(IDictionary<string, string> queryList)
        {
            DataSet set = await _sqlExecutor.AsyncDataSetLoadBatch(queryList);
            string commissionAgentId = GenerateUniqueId();
            for (int i = 0; i < set.Tables.Count; ++i)
            {
                if (set.Tables[i].Columns.Contains(PrimaryKey))
                {
                    if (set.Tables[i].Rows.Count > 0)
                    {
                        set.Tables[i].Rows[0][PrimaryKey] = commissionAgentId;
                    }
                    FlushDataSet(ref set, i);
                }
            }
            return set;
        }
        /// <summary>
        /// This flushes a set with null values.
        /// </summary>
        /// <param name="set">set to be flushed</param>
        /// <param name="index">data table index</param>
        private void FlushDataSet(ref DataSet set, int index)
        {
            foreach (DataColumn col in set.Tables[index].Columns)
            {
                if (col.DataType == typeof(string))
                {
                    if (col.ColumnName != PrimaryKey)
                        set.Tables[index].Rows[0][col] = "";
                }
            }

        }
        /// <summary>
        /// Get async commission agent list.
        /// </summary>
        /// <returns>Return a simple dataset.</returns>
        /// 
        public async Task<DataSet> GetAsyncCommissionAgentInfo(IDictionary<string, string> queryList)
        {
            DataSet summary = await _sqlExecutor.AsyncDataSetLoadBatch(queryList);
            return summary;
        }
        /// <summary>
        /// Save commission agent
        /// </summary>
        /// <param name="commissionAgent">Commission Agent to be saved.</param>
        /// <returns></returns>
        public async Task<bool> SaveCommissionAgent(ICommissionAgent commissionAgent)
        {
            bool changedTask = await commissionAgent.Save();
            return changedTask;
        }
        /// <summary>
        /// Save changes commission agent
        /// </summary>
        /// <param name="commissionAgent">Commission agent to be updated.</param>
        /// <returns></returns>
        public async Task<bool> SaveChangesCommissionAgent(ICommissionAgent commissionAgent)
        {
            bool changedTask = await commissionAgent.SaveChanges();
            return changedTask;
        }
        /// <summary>
        /// Save commission agent.
        /// </summary>
        /// <param name="commissionAgent">Commission agent saved.</param>
        /// <returns></returns>
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
                value = await commissionAgent.DeleteAsyncData();
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
        /// <returns></returns>
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