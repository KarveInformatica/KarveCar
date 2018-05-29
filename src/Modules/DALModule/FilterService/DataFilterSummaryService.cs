using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using Syncfusion.UI.Xaml.Grid;
using DataAccessLayer.SQL;
using AutoMapper;
using DataAccessLayer.Exception;
using KarveDapper.Extensions;

namespace DataAccessLayer.FilterService
{
    /// <summary>
    ///  DataFilterSummaryService
    /// </summary>
    /// <typeparam name="Dto"></typeparam>
    /// <typeparam name="Entity"></typeparam>
    public class DataFilterSummaryService<Dto> : AbstractDataFilterService<Dto> where Dto : class
                                                                      
    {
        /// <summary>
        ///  Store to be used within the queries.
        /// </summary>
        private QueryStoreFactory _queryStoreFactory;
        private ISqlExecutor _sqlExecutor;
        private string _currentFilter;
        /// <summary>
        /// DataFilterSummaryService is a service for filtering data without mapping. It can be used 
        /// for mapping the data.
        /// </summary>
        /// <param name="dialogService">Dialog service to be used</param>
        /// <param name="sqlExecutor">SqlExecutor to be used.</param>
        public DataFilterSummaryService(IDialogService dialogService, ISqlExecutor sqlExecutor) : base(dialogService)
        {
            _incrementalList = new IncrementalList<Dto>(LoadMoreItems);
            _queryStoreFactory = new QueryStoreFactory();
            _sqlExecutor = sqlExecutor;
            _dialogService = dialogService;
        }

        public new event OnFilteredResult FilterEventResult;
        /// <summary>
        ///  This is the interface for filtering the asynchronous data.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<object> FilterDataAsync(string filter)
        {
            _currentFilter = filter;
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    throw new DataAccessLayerException("");
                }
                //  Get first the number of pages
                var resultPages = await dbConnection.GetPageCount<Dto>(PageSize).ConfigureAwait(false);
                PageCount = resultPages.Item2;
                // Get the the defu
                var resultSet = await dbConnection.GetPagedAsync<Dto>(1, PageSize, filter).ConfigureAwait(false);
                _incrementalList = new IncrementalList<Dto>(LoadMoreItems) { MaxItemCount = resultPages.Item2 };
                _incrementalList.LoadItems(resultSet);
                FilterEventResult?.Invoke(_incrementalList);
                return resultSet;
            }
        }
        /// <summary>
        ///  This will load the asynchronous items.
        /// </summary>
        /// <param name="count">Index to count</param>
        /// <param name="baseIndex">Base index</param>
        /// <returns></returns>
        protected override async Task<IEnumerable<Dto>> LoadMoreItemsAsync(uint count, int baseIndex)
        {
            IEnumerable<Dto> resultSet = new List<Dto>();
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    resultSet = await dbConnection.GetPagedAsync<Dto>(1, PageSize, _currentFilter).ConfigureAwait(false);
                }
            }
            return resultSet;

        }
    }
}
