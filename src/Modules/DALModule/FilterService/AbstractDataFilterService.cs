using KarveCommon.Generic;
using KarveCommonInterfaces;
using KarveDataServices;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.FilterService
{
    /// <summary>
    ///  Abstract summary for allowing the filtering in a grid.
    /// </summary>
    public abstract class AbstractDataFilterService<Dto> : IDisposable, IDataFilterService
    {
        protected IncrementalList<Dto> _incrementalList;
        protected IDialogService _dialogService;
        public PropertyChangedEventHandler PagingEvent;
        private int _pageSize;
        private int _pageCount;
        private string _currentFilter;

        public event OnFilteredResult FilterEventResult;


        /// <summary>
        ///  Set or Get the size of the page.
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        ///  Set or Get the number of pages.
        /// </summary>
        public int PageCount { get => _pageCount; set => _pageCount = value; }


        public AbstractDataFilterService(IDialogService dialogService)
        {
            _dialogService = dialogService;
            PagingEvent += OnPagedEvent;

        }
        /// <summary>
        ///  This is meant to be overriden only when the PageEvent is needed
        /// </summary>
        /// <param name="sender">Sender of the paging</param>
        /// <param name="e">Event handler</param>
        protected void OnPagedEvent(object sender, PropertyChangedEventArgs e)
        {
            var listCompletion = sender as INotifyTaskCompletion<IEnumerable<Dto>>;
            if ((listCompletion != null) && (listCompletion.IsSuccessfullyCompleted))
            {
                _incrementalList.LoadItems(listCompletion.Result);
            }

            if ((listCompletion != null) && (listCompletion.IsFaulted))
            {
                _dialogService?.ShowErrorMessage("Error Loading data " + listCompletion.ErrorMessage);
            }
        }
       
        /// <summary>
        ///  Load more items.
        /// </summary>
        /// <param name="count">Count of the items</param>
        /// <param name="baseIndex">Index of base</param>
        protected void LoadMoreItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<Dto>>(LoadMoreItemsAsync(count, baseIndex), PagingEvent);
        }
        /// <summary>
        ///  LoadMoreItemsAsync
        /// </summary>
        /// <param name="count">Numero of the coutn</param>
        /// <param name="baseIndex">Index of the base</param>
        /// <returns></returns>
        protected abstract Task<IEnumerable<Dto>> LoadMoreItemsAsync(uint count, int baseIndex);
        /// <summary>
        ///  Filter data asynchronously
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public abstract Task<object> FilterDataAsync(string query);

        public void Dispose()
        {
            PagingEvent -= OnPagedEvent;
        }
      
       
    }
}
