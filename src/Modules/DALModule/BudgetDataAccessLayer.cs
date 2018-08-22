using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Model;
using DataAccessLayer.Exception;
using Dapper;
using DataAccessLayer.SQL;
using System.ComponentModel;
using DataAccessLayer.Logic;
using KarveDapper.Extensions;
using AutoMapper;
using DataAccessLayer.Crud.Budget;
using KarveDataServices.DataObjects;

namespace DataAccessLayer
{
    /// <summary>
    ///  DataAccesLayer for the budget
    /// </summary>
    class BudgetDataAccessLayer : AbstractDataAccessLayer, IBudgetDataService
    {
        private IDataLoader<BudgetDto> _dataLoader;
        private IDataSaver<BudgetDto> _dataSaver;
        private IDataDeleter<BudgetDto> _dataDeleter;
        private IMapper _mapper;

        /// <summary>
        ///  Constructor for the budget
        /// </summary>
        /// <param name="sqlExecutor"></param>
        public BudgetDataAccessLayer(ISqlExecutor sqlExecutor) : base(sqlExecutor)
        {
            _dataLoader = new BudgetDataLoader(sqlExecutor);
            _dataSaver = new BudgetDataSaver(sqlExecutor);
            _dataDeleter = new BudgetDataDeleter(sqlExecutor);
            TableName = "PRESUP1";
            _mapper = MapperField.GetMapper();
        }
        /// <summary>
        /// Delete Asynchronous budget
        /// </summary>
        /// <param name="domainObject">Domain Object</param>
        /// <returns>Return value</returns>
        public async Task<bool> DeleteAsync(IBudgetData domainObject)
        {
            if (!domainObject.Valid)
            {
                return false;
            }
            var dto = domainObject.Value;
            var result = await _dataDeleter.DeleteAsync(dto).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Get an asynchronous data object.
        /// </summary>
        /// <param name="code">Code of the data</param>
        /// <returns>A react loader</returns>
        public async Task<IBudgetData> GetDoAsync(string code)
        {
            var result = await _dataLoader.LoadValueAsync(code).ConfigureAwait(false);
            var data = new Budget(result);
            return data;
        }

        public Task<IEnumerable<IBudgetData>> GetListAsync(IList<IBudgetData> primaryKeys)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IBudgetData>> GetListAsync(IList<string> primaryKeys)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Create a new domain object
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A budget of data.</returns>
        public IBudgetData GetNewDo(string value)
        {
            var newDto = new BudgetDto();
            newDto.NUMERO_PRE = value;
            newDto.IsNew = true;
            var domainObject = new Budget(newDto);
            return domainObject;
        }
        /// <summary>
        ///  Get the paged summary asynchronously.
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="pageSize">Paged size</param>
        /// <returns>A list of budget summary.</returns>
        public async Task<IEnumerable<BudgetSummaryDto>> GetPagedSummaryDoAsync(int index, int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            var pager = new DataPager<BudgetSummaryDto>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            IEnumerable<BudgetSummaryDto> data = new List<BudgetSummaryDto>();
            try
            { 
                data = await pager.GetPagedSummaryDoAsync(QueryType.QueryBudgetSummaryPaged, pageStart, pageSize).ConfigureAwait(false);
            } catch (System.Exception ex)
            {
                throw new DataAccessLayerException(ex.Message);
            }
            return data;
        }

        /// <summary>
        /// Get a collection of data sorted and paged.
        /// </summary>
        /// <param name="sortChain">Sorted chain</param>
        /// <param name="index">Index position</param>
        /// <param name="pageSize">Dimension of the page</param>
        /// <returns></returns>
        public async Task<IEnumerable<BudgetSummaryDto>> GetSortedCollectionPagedAsync(Dictionary<string, ListSortDirection> sortChain, long index, int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            var dataPager = new DataPager<BudgetSummaryDto>(SqlExecutor);
            var pageStart = index;
            if (pageStart <= 0)
                pageStart = 1;
            NumberPage = await GetPageCount(pageSize).ConfigureAwait(false);
            var datas = await dataPager.GetPagedSummaryDoSortedAsync(QueryType.QueryBudgetSummaryPaged, sortChain, index, pageSize).ConfigureAwait(false);
            return datas;
        }
        /// <summary>
        ///  Get the complete collection unpaged of all budgets presents in the database.
        /// </summary>
        /// <returns>A list of budget objects</returns>
        public async Task<IEnumerable<BudgetSummaryDto>> GetSummaryAllAsync()
        {
            var queryStore = QueryStoreFactory.GetQueryStore();
            queryStore.AddParam(QueryType.QueryBudgetSummary);
            var query = queryStore.BuildQuery();
            IEnumerable<BudgetSummaryDto> outResult = new List<BudgetSummaryDto>();
            using (var dbConnection = SqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection == null)
                {
                    throw new DataAccessLayerException("GetSummaryAllAsync cannot connect");
                }
                outResult = await dbConnection.QueryAsync<BudgetSummaryDto>(query).ConfigureAwait(false);
            }
            return outResult;
        }
        /// <summary>
        /// Get a new identifier. 
        /// </summary>
        /// <returns>Returns an unique identifier for the budget.</returns>
        public string NewId()
        {
            string uniqueId = string.Empty;
            using (var connection = SqlExecutor.OpenNewDbConnection())
            {
                if (connection != null)
                {
                    var pet = new PRESUP1();
                    uniqueId = connection.UniqueId(pet);
                    return uniqueId;
                }
            }
            return uniqueId;
        }
        /// <summary>
        /// Save all the data associated in the b
        /// </summary>
        /// <param name="domainObject"></param>
        /// <returns>Return a saved value.</returns>
        public async Task<bool> SaveAsync(IBudgetData domainObject)
        {
            if (!domainObject.Valid)
            {
                return false;
            }
            var savedReservation = await _dataSaver.SaveAsync(domainObject.Value).ConfigureAwait(false);
            return savedReservation;
        }

}


}
