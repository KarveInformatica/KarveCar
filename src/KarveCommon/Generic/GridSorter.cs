using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public sealed class GridSorter<T> where T: BaseDto
    {
        private IDialogService _dialogService;
        private ISorterData<T> _dataProvider;
        private int _defaultPage;
        private Dictionary<string, ListSortDirection> _sortDictionary;
        public delegate void NewPage(IEnumerable<T> page);
        public event NewPage OnNewPage;
        public delegate void InitPage(IEnumerable<T> page);
        public event NewPage OnInitPage;

        public GridSorter(IDialogService service, ISorterData<T> sorterProvider, int defaultPage)
        {
            _dialogService = service;
            _dataProvider = sorterProvider;
            _defaultPage = defaultPage;
            _sortDictionary = new Dictionary<string, ListSortDirection>();
            Loader = LoadMoreSortedItems;
        }

        public Action<uint, int> Loader { set; get; }

        private void LoadMoreSortedItems(uint count, int baseIndex)
        {
            NotifyTaskCompletion.Create<IEnumerable<T>>(
               _dataProvider.GetSortedCollectionPagedAsync(_sortDictionary, baseIndex, _defaultPage), (task, ev) => {
                   if (task is INotifyTaskCompletion<IEnumerable<T>> taskResult)
                   {
                       if (taskResult.IsSuccessfullyCompleted)
                       {
                           OnNewPage?.Invoke(taskResult.Task.Result);
                       }
                       else
                       {
                           _dialogService.ShowErrorMessage("Cannot load sorted items");
                       }
                   }
               });

        }
        private void OnNotifyIncrementalListSorted(object sender, Dictionary<string, ListSortDirection> direction)
        {
            if (sender is INotifyTaskCompletion<IEnumerable<T>> taskResult)
            {

                if (taskResult.IsSuccessfullyCompleted)
                {
                    OnInitPage?.Invoke(taskResult.Task.Result);
                }
                else
                {
                    _dialogService.ShowErrorMessage("Cannot load sorted items");
                }                
            }
        }
        public void SortCommand(object eventDictionary)
        {
            Dictionary<string, ListSortDirection> changed = eventDictionary as Dictionary<string, ListSortDirection>;
            NotifyTaskCompletion.Create<IEnumerable<T>>(_dataProvider.GetSortedCollectionPagedAsync(changed, 1,_defaultPage), (task, ev) =>
            {
                OnNotifyIncrementalListSorted(task, changed);
            });
        }
    }
}
