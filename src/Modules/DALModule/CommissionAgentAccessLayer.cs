using System.Collections.Generic;
using System.Data;
using System;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataObjects;
using System.Collections.ObjectModel;
using System.Transactions;
using Dapper;
using DataAccessLayer.DtoWrapper;
using KarveDataServices.ViewObjects;
using NLog;
using DataAccessLayer.SQL;
using DataAccessLayer.DataObjects;
using KarveDapper.Extensions;
using System.ComponentModel;

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
            TableName = CommissionAgentTable;
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
            queries = queryDictionary ?? base.BaseQueryDictionary;
            var agentFactory = CommissionAgentFactory.GetFactory(_sqlExecutor);
            var createdAgent =  await agentFactory.GetCommissionAgent(queries, commissionAgentId);
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
            var commissionAgentFactory = CommissionAgentFactory.GetFactory(_sqlExecutor);
            var commissionAgents = await commissionAgentFactory.CreateCommissionAgentList(fields, pageSize, startAt);
            return commissionAgents;
        }

        /// <summary>
        /// Get the commission agent summary in an ADO.NET database.
        /// </summary>
        /// <param name="paged">optional parameter indicating if the agent shall be paged</param>
        /// <param name="pageSize">optional parameter indicating the dimension of the page size</param>
        /// <returns>Returns the data set of all commission agents present in the system.</returns>
        public async Task<DataSet> GetDataSetSummaryAsync(bool paged = false, long pageSize = 0)
        {
            var dataset = await _sqlExecutor.AsyncDataSetLoad(GenericSql.CommissionAgentSummaryQuery).ConfigureAwait(false);
            logger.Debug("GetDataSetSummaryAsync " + GenericSql.CommissionAgentSummaryQuery);
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
        public async Task<IEnumerable<CommissionAgentSummaryViewObject>> GetSummaryAllAsync()
        {
            IEnumerable<CommissionAgentSummaryViewObject> summary = new ObservableCollection<CommissionAgentSummaryViewObject>();
            var store = _queryStoreFactory.GetQueryStore();
            store.AddParam(QueryType.QueryCommissionAgentSummary);
            var query = store.BuildQuery();
            using (var connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        summary = await connection.QueryAsync<CommissionAgentSummaryViewObject>(query).ConfigureAwait(false);
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
        /// New commission agent
        /// </summary>
        /// <returns>Returns the commission agent.</returns>
        public ICommissionAgent GetNewDo()
        {
            var factory = CommissionAgentFactory.GetFactory(_sqlExecutor);
            var id = NewId();
            logger.Debug("GetCommissionAgent " + id);
            var agent =  factory.NewCommissionAgent(id);
            return agent;
        }
        /// <summary>
        /// New commission agent
        /// </summary>
        /// <returns>Returns the commission agent.</returns>
        public ICommissionAgent GetNewDo(string id)
        {
            var factory = CommissionAgentFactory.GetFactory(_sqlExecutor);
            var agent = factory.NewCommissionAgent(id);
            return agent;
        }
        /// <summary>
        /// Save commission agent
        /// </summary>
        /// <param name="commissionAgent">Commission Agent to be saved.</param>
        /// <returns>Returns true if the commission agent has been changed.</returns>
        public async Task<bool> SaveAsync(ICommissionAgent commissionAgent)
        {
            var isPresent = false;
            using (var connection = _sqlExecutor.OpenNewDbConnection())
            {
                var dto = commissionAgent.Value;
                var value = await connection.GetAsync<COMISIO>(dto.NUM_COMI).ConfigureAwait(false);
                isPresent = (value != null);
            }

            var changedTask = false;
            if (!isPresent)
            {
                changedTask = await commissionAgent.Save().ConfigureAwait(false);
            }
            else
            {
                changedTask = await commissionAgent.SaveChanges().ConfigureAwait(false);
            }
            return changedTask;
        }
       
        /// <summary>
        /// Save commission agent.
        /// </summary>
        /// <param name="commissionAgent">Commission agent saved.</param>
        /// <returns>True when the commission agent has been deleted.</returns>
        public async Task<bool> DeleteAsync(ICommissionAgent commissionAgent)
        {
            var value = false;

            var connection = _sqlExecutor.Connection;
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
        ///  This returns a sorted summary sorted and extended collection.
        /// </summary>
        /// <param name="sortChain">Sort direction</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list of sorted clients</returns>
        public async Task<IEnumerable<CommissionAgentSummaryViewObject>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long pageIndex, int pageSize)
        {
            var dataPager = new DataPager<CommissionAgentSummaryViewObject>(SqlExecutor);
            var pageStart = pageIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryType.QueryCommissionAgentPaged, sortChain, pageIndex, pageSize);
            return datas;
        }

        public string NewId()
        {
            var id = string.Empty;
            using (var conn = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    var comisio = new COMISIO();
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
        public async  Task<ICommissionAgent> GetDoAsync(string code)
        {
            var agent = await GetCommissionAgentDo(code).ConfigureAwait(false);
            return agent;
        }

        public async Task<IEnumerable<CommissionAgentSummaryViewObject>> GetPagedSummaryDoAsync(int pageIndex, int pageSize)
        {
            var paged = new DataPager<CommissionAgentSummaryViewObject>(_sqlExecutor);
            NumberPage = await GetPageCount(pageSize);
            var pagedValue = await paged.GetPagedSummaryDoAsync(QueryType.QueryCommissionAgentPaged, pageIndex, pageSize);
            return pagedValue;
        }

        public Task<IEnumerable<ICommissionAgent>> GetListAsync(IList<string> primaryKeys)
        {
            throw new NotImplementedException();
        }
    }
}