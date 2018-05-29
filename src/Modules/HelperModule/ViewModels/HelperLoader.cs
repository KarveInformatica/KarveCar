using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;
using Syncfusion.UI.Xaml.Grid;
using KarveCommonInterfaces;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  TODO: fix the srp issues.
    /// </summary>
    /// <typeparam name="Dto">Data transfer object to be mapped</typeparam>
    /// <typeparam name="Entity">Entity to be mapped</typeparam>
    public class HelperLoader<Dto, Entity>: IDisposable where Dto: class
                                           where Entity: class
    {
        public PropertyChangedEventHandler PageEvent;
        private IDataServices _services;
        private IEnumerable<Dto> _loadedView;
        private IncrementalList<Dto> _helperView;
        private INotifyTaskCompletion<IEnumerable<Dto>> _initializationNotifier;
        private PropertyChangedEventHandler _loadCompleted;
        private IHelperDataServices _helperDataServices;
        private long _currentIndex;
        private const int _defaultPageSize = 500;
      
        /// <summary>
        ///  Helper loader. This loader helps to load the data from dataservices
        /// </summary>
        /// <param name="services">Data services to be loaded.</param>
        public HelperLoader(IDataServices services)
        {
            _services = services;
            _helperDataServices = services.GetHelperDataServices();
            _loadCompleted += OnLoadCompleted;
            _currentIndex = 0;
            PageSize = _defaultPageSize;
        }
        /// <summary>
        ///  Set or Get the Page Size
        /// </summary>
        public int PageSize { set; get; }

        /// <summary>
        ///  This event is able to dispose the load compled.
        /// </summary>
        public void Dispose()
        {
            _loadCompleted -= OnLoadCompleted;
        
        }
        // TODO: check error.
        private void OnLoadCompleted(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IEnumerable<Dto>> pageSender = sender as INotifyTaskCompletion<IEnumerable<Dto>>;
            if (pageSender.IsFaulted)
            {
                throw new DataLayerException("Error loading data");
            }
        }
        private void OnPageEvent(object sender, PropertyChangedEventArgs e)
        {
            INotifyTaskCompletion<IEnumerable<Dto>> pageSender = sender as INotifyTaskCompletion<IEnumerable<Dto>>;
            // now it is successfully completed.
            if (pageSender.IsSuccessfullyCompleted)
            {
                INotifyTaskCompletion<IEnumerable<Dto>> listCompletion =
               sender as INotifyTaskCompletion<IEnumerable<Dto>>;
                if ((listCompletion != null) && (listCompletion.IsSuccessfullyCompleted))
                {
                    if (HelperView is IncrementalList<Dto> summary)
                    {
                        summary.LoadItems(listCompletion.Result);
                        HelperView = summary;
                    }
                }

                if ((listCompletion != null) && (listCompletion.IsFaulted))
                {
                   throw new DataLayerException("Error Loading data " + listCompletion.ErrorMessage);
                }
            }
        }
        /// <summary>
        ///  Retrieve a page or send a data error loading exception.
        /// </summary>
        /// <param name="sender">Sender of the page</param>
        /// <param name="e">Changed arguments to be used.</param>
        /// <returns>An incremental list of the pages</returns>
        public IncrementalList<Dto> FetchPage(object sender, PropertyChangedEventArgs e)
        {
            var pageSender = sender as INotifyTaskCompletion<IEnumerable<Dto>>;
            // now it is successfully completed.
            if (pageSender.IsSuccessfullyCompleted)
            {
                if ((sender is INotifyTaskCompletion<IEnumerable<Dto>> listCompletion) && (listCompletion.IsSuccessfullyCompleted))
                {
                    if (listCompletion.Result is IncrementalList<Dto> summary)
                    {
                        return summary;
                    }
                }

            }
            throw new DataLayerException("Error Loading data " + pageSender.ErrorMessage);
            
        }

        /// <summary>
        ///  This load a page.
        /// </summary>
        /// <param name="baseIndex">Index of the page</param>
        /// <param name="pageSize">Dimension of the page</param>
        public void LoadPaged(long baseIndex, int pageSize)
        {
            NotifyTaskCompletion.Create<IEnumerable<Dto>>(
              _helperDataServices.GetPagedSummaryDoAsync<Dto,Entity>(baseIndex, PageSize), PageEvent);

        }
        /// <summary>
        ///  Load event.
        /// </summary>
        /// <param name="value"></param>
        public void Load(string value)
        {
            _initializationNotifier = NotifyTaskCompletion.Create(LoadDto(value), _loadCompleted);

        }
        /// <summary>
        ///  Load all the entities.
        /// </summary>
        public void LoadAll()
        {
            _initializationNotifier = NotifyTaskCompletion.Create(LoadDtoAll(), _loadCompleted);
        }

        /// <summary>
        ///  Load Data Transfer All. Violate SRP.
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<Dto>> LoadDtoAll()
        {
            IEnumerable<Dto> list = null;
            try

            {
                list = await _helperDataServices.GetMappedAllAsyncHelper<Dto, Entity>();
            }
            catch (Exception e)
            {
                throw new DataLayerException(e.Message, e);
            }
            if (list == null)
            {
                return null;
            }
            var value = new ObservableCollection<Dto>(list);
            _helperView.LoadItems(value);
            return value;
        }
        /// <summary>
        ///  HelperView.
        /// </summary>
        public IncrementalList<Dto> HelperView
        {
            set { _helperView = value; }
            get { return _helperView; }
        }
        /// <summary>
        ///  This load a data transfer object.
        /// </summary>
        /// <param name="query">This load a dto.</param>
        /// <returns></returns>
        private async Task<IEnumerable<Dto>> LoadDto(string query) 
        {
            // we want to make in a way that we will not show more 
            var listOfVehicles = await _helperDataServices.GetMappedAsyncHelper<Dto, Entity>(query);
            if (listOfVehicles == null)
            {
                return null;
            }
            _loadedView = listOfVehicles;
            var currentList = new IncrementalList<Dto>(LoadMoreItems) { MaxItemCount = _loadedView.Count()};
            var shortListView = _loadedView.Take<Dto>(500);
            HelperView.LoadItems(shortListView);
            return currentList;
        }
        /// <summary>
        ///  LoadMoreItems
        /// </summary>
        /// <param name="index"></param>
        /// <param name="baseIndex">Base index to be used</param>
        private void LoadMoreItems(uint index, int baseIndex)
        {
            var currentList =_loadedView.Skip(baseIndex).Take(100).ToList();
            HelperView.LoadItems(currentList);
        }
    } 
}
