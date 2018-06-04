using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccessLayer.SQL;
using KarveDataServices;
using System.ComponentModel;

namespace DataAccessLayer
{
    /// <summary>
    ///  DataPager has the single resposability of retrieving a given interval of data starting from a position.
    /// </summary>
    /// <typeparam name="T">Type of the data to fetch</typeparam>
    public class DataPager<T> where T: class
    {
        private readonly QueryStoreFactory _factory;
        private readonly ISqlExecutor _executor;
        /// <summary>
        /// This is a data pager
        /// </summary>
        /// <param name="executor">This is the executor to be injected in a query</param>
        public DataPager(ISqlExecutor executor)
        {
            _factory = new QueryStoreFactory();
            _executor = executor;
        }
        /// <summary>
        ///  GetPagedSummaryDoAsync
        /// </summary>
        /// <param name="queryTemplate">Template of the query</param>
        /// <param name="pageIndex">Index of the page</param>
        /// <param name="pageSize">Index of the size</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetPagedSummaryDoAsync(QueryType queryTemplate, long pageIndex, long pageSize)
        {
            var storeFactory = _factory.GetQueryStore();
            var query = storeFactory.BuildQuery(queryTemplate,
                new List<string>() {pageSize.ToString(), pageIndex.ToString()});
            IEnumerable<T> pagedList = new List<T>();

            if ((pageSize <= 0) || (pageIndex <= 0))
            {
                throw new ArgumentException();
            }
            using (var dbConnection = _executor.OpenNewDbConnection())
            {
                try
                {
                    if (dbConnection != null)
                    {
                        pagedList = await dbConnection.QueryAsync<T>(query);
                    }
                } catch (System.Exception ex)
                {
                    throw new DataPagerException("DataPagerException", ex);
                }
               
            }
            return pagedList;
        }

        /// <summary>
        ///  This retrive the data paged and sorted.
        /// </summary>
        /// <param name="queryTemplate">Kind of query</param>
        /// <param name="sortChain">Direction to sorting</param>
        /// <param name="pageIndex">Starting page to index</param>
        /// <param name="pageSize">Page dimension</param>
        /// <returns>A list of data objects</returns>
        public async Task<IEnumerable<T>> GetPagedSummaryDoSortedAsync(QueryType queryTemplate, Dictionary<string, ListSortDirection> sortChain, long pageIndex, long pageSize)
        {
            var store = _factory.GetQueryStore();

            var query = store.AddParamFilterSort(queryTemplate, sortChain).BuildQuery(queryTemplate,
                new List<string>() { pageSize.ToString(), pageIndex.ToString() });
            IEnumerable<T> pagedList = new List<T>();
            if ((pageSize <= 0) || (pageIndex <= 0))
            {
                throw new ArgumentException();
            }
            using (var dbConnection = _executor.OpenNewDbConnection())
            {
                try
                {
                    if (dbConnection != null)
                    {
                        pagedList = await dbConnection.QueryAsync<T>(query);
                    }
                }
                catch (System.Exception ex)
                {
                    throw new DataPagerException("DataPagerException", ex);
                }
            }
            return pagedList;

        }
        /// <summary>
        /// Count the list of pages and the number of items of given table
        /// </summary>
        /// <param name="pageSize">Dimension of the page</param>
        /// <param name="tableName">Table of the pages</param>
        /// <returns>A tuple where the first item is the number of items and the second the pageCount</returns>
        public async Task<Tuple<int,int>> GetPageCount(int pageSize, string tableName)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException();
            }
            // find a smart way to get the query 

            var value = "SELECT COUNT(*) FROM " + tableName;
            var pageCount = 0;
            var numItems = 0;
            using (var dbConnection = _executor.OpenNewDbConnection())
            {
                try
                {
                    if (dbConnection != null)
                    {
                        numItems = await dbConnection.QueryFirstOrDefaultAsync<int>(value);
                        double items = numItems;
                        double pageDim = pageSize;
                        pageCount = (int)Math.Round(items / pageDim);
                    }
                } catch (System.Exception ex)
                {
                    throw new DataPagerException("DataPagerException", ex);
                }
            }
            return new Tuple<int, int>(numItems,pageCount);
        }
        
    }
}
