using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.Crud.Clients;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using KarveDapper.Extensions;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.SQL;
using System.ComponentModel;

namespace DataAccessLayer
{
     /// <summary>
     /// This class has the resposability to handle the client wrapper and delete, insert, update values. 
     /// </summary>
    internal class ClientDataAccessLayer : AbstractDataAccessLayer,IClientDataServices
    {
        private readonly IDataLoader<ClientDto> _dataLoader;
        private readonly IDataSaver<ClientDto> _dataSaver;
        private readonly IDataDeleter<ClientDto> _dataDeleter;
        private const string _tableName = "CLIENTES1";
        /// <summary>
        ///  Sql executor.
        /// </summary>
        private readonly ISqlExecutor _sqlExecutor;

      
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="sqlExecutor">SqlExecutor value</param>
        public ClientDataAccessLayer(ISqlExecutor sqlExecutor): base(sqlExecutor)
        {
            _sqlExecutor = sqlExecutor;
            _dataLoader = new ClientDataLoader(sqlExecutor);
            _dataSaver = new ClientDataSaver(sqlExecutor);
            _dataDeleter= new ClientDeleter(sqlExecutor);
            TableName = "CLIENTES1";
        }
        /// <summary>
        ///  Delete the client.
        /// </summary>
        /// <param name="clientData">The client value to delete</param>
        /// <returns>True if has been deleted correctly</returns>
        public async Task<bool> DeleteDoAsync(IClientData clientData)
        {
            return await _dataDeleter.DeleteAsync(clientData.Value).ConfigureAwait(false);
        }
        /// <summary>
        ///  Get async client summary.
        /// </summary>
        /// <returns>A list containing the complete list of clients</returns>
        public async Task<IEnumerable<ClientSummaryExtended>> GetSummaryAllAsync()
        {
            var store = new QueryStore();
            store.AddParam(QueryType.QueryClientSummaryExt);
            var query = store.BuildQuery();

            IEnumerable<ClientSummaryExtended> summaryDtos = new List<ClientSummaryExtended>();
            using (var connection = _sqlExecutor.OpenNewDbConnection())
            {
                if (connection == null)
                {
                    return summaryDtos;
                }
                var startStopwatch = new Stopwatch();
                startStopwatch.Start();
                summaryDtos = await connection.QueryAsync<ClientSummaryExtended>(query).ConfigureAwait(false);
                startStopwatch.Stop();
            }
            return summaryDtos;
        }
        /// <summary>
        /// This code return a client model wrapper.
        /// </summary>
        /// <param name="clientIndentifier">Identifier of the client</param>
        /// <returns>A client indentifier</returns>
        public async Task<IClientData> GetDoAsync(string clientIndentifier)
        {

            if (string.IsNullOrEmpty(clientIndentifier))
            {
                throw new ArgumentException("Empty value during client");
            }
            var entity = await _dataLoader.LoadValueAsync(clientIndentifier).ConfigureAwait(false);
            IClientData client = new Client();
            client.Value = entity;
            return client;
        }
        /// <summary>
        ///  Get client summary
        /// </summary>
        /// <param name="clientsSummaryQuery">Query of the client summary.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ClientSummaryDto>> GetSummaryDo(string clientsSummaryQuery)
        {
          
            IEnumerable<ClientSummaryDto> summaryDtos = new List<ClientSummaryDto>();
            using (var connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                   
                    summaryDtos = await connection.QueryAsync<ClientSummaryDto>(clientsSummaryQuery).ConfigureAwait(false);
                }
                finally
                {
                    connection.Close();
                }
            }
            return summaryDtos;
        }
        public IClientData GetNewDo(string code)
        {
            IClientData varClientData = new Client();
            varClientData.Value = new ClientDto {NUMERO_CLI = code};
            return varClientData;
        }
        /// <summary>
        ///  Generate an unique id from the entity key.
        /// </summary>
        /// <returns>Return a string with the client dto.</returns>
        public string GetNewId()
        {
            var value = new CLIENTES1();
            var uniqueIdTask = string.Empty;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                try
                {
                    uniqueIdTask =  connection.UniqueId(value);

                }
                finally
                {
                    connection.Close();
                }    
            }
            return uniqueIdTask;
        }
        /// <summary>
        ///  Value to save in the client data.
        /// </summary>
        /// <param name="clientData">Data client</param>
        /// <returns>True if the data has been saved correctly</returns>

        public async Task<bool> SaveAsync(IClientData clientData)
        {
            return await _dataSaver.SaveAsync(clientData.Value).ConfigureAwait(false);
        }
        /// <summary>
        ///  This return items paged
        /// </summary>
        /// <typeparam name="T">Type of the page</typeparam>
        /// <param name="pageIndex">Starting index of the page</param>
        /// <param name="pageSize">Dimension of the page</param>
        /// <returns></returns>
        public async Task<IEnumerable<ClientSummaryExtended>> GetPagedSummaryDoAsync(long pageIndex, int pageSize)
        {
            var pager = new DataPager<ClientSummaryExtended>(_sqlExecutor);
            var pageStart = pageIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await pager.GetPagedSummaryDoAsync(QueryType.QueryClientPagedSummary, pageStart, pageSize).ConfigureAwait(false);
            return datas;
        }
        /// <summary>
        ///  This returns a client summary sorted and extended collection.
        /// </summary>
        /// <param name="sortChain">Sort direction</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>A list of client extended summary</returns>
        public async Task<IEnumerable<ClientSummaryExtended>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long pageIndex, int pageSize)
        {
            var dataPager = new DataPager<ClientSummaryExtended>(SqlExecutor);
            var pageStart = pageIndex;
            if (pageStart == 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryType.QueryClientPagedSummary, sortChain, pageIndex, pageSize);
            return datas;
        }
    }
}