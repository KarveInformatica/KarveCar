using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using System;
using System.Security.Cryptography;
using AutoMapper;
using DataAccessLayer.DataObjects.Wrapper;

namespace DataAccessLayer
{
    /// <summary>
    /// CommissionAgentAccessLayer.
    /// This returns an abstact access layer.
    /// </summary>
    public class CommissionAgentAccessLayer : AbstractDataAccessLayer, ICommissionAgentDataServices
    {
        /// <summary>
        /// Sql query executor. This is the sql executor for ADO.NET
        /// </summary>
        private readonly ISqlQueryExecutor _sqlQueryExecutor;

        private const string PrimaryKey = "NUM_COMI";
        private const string CommissionAgentTable = "COMISIO";
        private const string CommissionAgentFile = @"\Data\CommissionAgentFields.xml";
        
        /// <summary>
        /// CommissionAgentAccessLayer
        /// </summary>
        /// <param name="executor">Executro of a query</param>
        public CommissionAgentAccessLayer(ISqlQueryExecutor executor): base(executor)
        {
            _sqlQueryExecutor = executor;
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
            if (queryDictionary == null)
            {
                queries= base.baseQueryDictionary;
            }
            else
            {
                queries = queryDictionary;
            }
            CommissionAgentFactory agentFactory = CommissionAgentFactory.GetFactory(_sqlQueryExecutor);
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
            DataSet set = await _sqlQueryExecutor.AsyncDataSetLoadBatch(query);
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
            CommissionAgentFactory commissionAgentFactory = CommissionAgentFactory.GetFactory(_sqlQueryExecutor);
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
            DataSet dataset = await _sqlQueryExecutor.AsyncDataSetLoad(GenericSql.CommissionAgentSummaryQuery);
            return dataset;
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
            CommissionAgentFactory factory = CommissionAgentFactory.GetFactory(_sqlQueryExecutor);
            ICommissionAgent agent =  factory.NewCommissionAgent();
            return agent;
        }

        
        /// <summary>
        /// This generate an unique id.
        /// </summary>
        /// <returns>Returns an unique id.</returns>
        private string GenerateUniqueId()
        {
            string id = "";
            do
            {
                byte[] data = new byte[2];
                using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetBytes(data);
                }
                var tmpNumber = BitConverter.ToUInt16(data, 0);

                id = tmpNumber.ToString();
                string str = "SELECT NUM_COMI FROM COMISIO WHERE NUM_COMI='{0}'";
                str = string.Format(str, id);
                DataTable table = _sqlQueryExecutor.ExecuteSelectCommand(str, CommandType.Text);
                if (table.Rows.Count == 0)
                {
                    break;
                }
            } while (true);

            return id;
        }
        /// <summary>
        ///  This returns a commission agent dataset 
        /// </summary>
        /// <param name="queryList">This gives us a </param>
        /// <returns>Return a dataset with the new commission agent fields</returns>
        public async Task<DataSet> GetNewCommissionAgent(IDictionary<string, string> queryList)
        {
            DataSet set = await _sqlQueryExecutor.AsyncDataSetLoadBatch(queryList);
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
            DataSet summary = await _sqlQueryExecutor.AsyncDataSetLoadBatch(queryList);
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
            IDbConnection connection = _sqlQueryExecutor.Connection;
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                value = await commissionAgent.DeleteAsyncData();
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