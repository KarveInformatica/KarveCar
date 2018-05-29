using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KarveCommonInterfaces;
using Syncfusion.UI.Xaml.Grid;
using KarveDataServices;
using KarveDapper.Extensions;
using DataAccessLayer.SQL;
using AutoMapper;
using KarveCommon.Generic;
using System.ComponentModel;
using DataAccessLayer.Exception;

namespace DataAccessLayer.FilterService
{
    /// <summary>
    ///  This returns the query filters on the data.
    ///  It trigger an event for every kind of service.
    /// </summary>
    public class DataFilterService<Dto, Entity> : AbstractDataFilterService<Dto> where Dto: class
                                                                     where Entity : class
    {
        private ISqlExecutor _sqlExecutor;
        private IMapper _mapper;
        private INotifyTaskCompletion<IEnumerable<Dto>> _taskCompletion;
        private QueryStoreFactory _queryStoreFactory;
        private string _currentFilter;

        /// <summary>
        ///  event to received when the items gets loaded.
        /// </summary>
        public new  event OnFilteredResult FilterEventResult = delegate { };

        /// <summary>
        /// This allows you to have a filter.
        /// </summary>
        /// <param name="_sqlExecutor">SqlExeutor.</param>
        public DataFilterService(ISqlExecutor sqlExecutor, IMapper mapper, IDialogService dialogService) : base(dialogService)
        {
            _incrementalList = new IncrementalList<Dto>(LoadMoreItems);
            _queryStoreFactory = new QueryStoreFactory();
            _mapper = mapper;
            _sqlExecutor = sqlExecutor;
            _dialogService = dialogService;
            PageSize = 500;
            PageCount = 0;
        }
       

        /// <summary>
        ///  This function uses a query filter, it gets resolved and return an incremental list of the data views.
        /// </summary>
        /// <param name="filter">clause on the where in which you can filter</param>
        /// <returns>A list of objects</returns>
        public override async Task<object> FilterDataAsync(string filter)
        {
            _currentFilter = filter;
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection!=null)
                {
                    throw new DataAccessLayerException("");
                }
                //  Get first the number of pages
                var resultPages = await dbConnection.GetPageCount<Entity>(PageSize).ConfigureAwait(false);
                PageCount = resultPages.Item2;
                // Get the the defu
                var resultSet = await dbConnection.GetPagedAsync<Entity>(1, PageSize, filter).ConfigureAwait(false);
                var dtoResultSet = _mapper.Map<IEnumerable<Entity>, IEnumerable<Dto>>(resultSet);
                _incrementalList = new IncrementalList<Dto>(LoadMoreItems) { MaxItemCount = resultPages.Item2 };
                _incrementalList.LoadItems(dtoResultSet);
                FilterEventResult?.Invoke(_incrementalList);
                return dtoResultSet;
            }
        }
        /// <summary>
        ///  LoadMoreItemsAsync. This is giving you an asynchronous items to load data.
        /// </summary>
        /// <param name="count">Count of the item</param>
        /// <param name="baseIndex">Index of the item</param>
        /// <returns>A list of items</returns>
        protected override async Task<IEnumerable<Dto>> LoadMoreItemsAsync(uint count, int baseIndex)
        {
            IEnumerable<Dto> resultSet = new List<Dto>();
            using (var dbConnection = _sqlExecutor.OpenNewDbConnection())
            {
                if (dbConnection != null)
                {
                    var set = await dbConnection.GetPagedAsync<Entity>(1, PageSize, _currentFilter).ConfigureAwait(false);
                    resultSet = _mapper.Map<IEnumerable<Entity>, IEnumerable<Dto>>(set);
                }
            }
            return resultSet;
        }

    
    }
}
