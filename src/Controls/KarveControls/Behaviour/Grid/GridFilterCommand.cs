using System;

using System.Windows.Input;
using KarveDataServices;
using KarveCommonInterfaces;

namespace KarveControls.GridFilter
{

    public class GridFilterCommand : ICommand
    {
        private IDataFilterService _dataFilterService;
        
        public GridFilterCommand(IDataFilterService filterService)
        {
            _dataFilterService = filterService;
        }

        public event EventHandler CanExecuteChanged;

        public object FilterView { set; get; }

        public bool CanExecute(object parameter)
        {
            return true;  
        }
        public void Execute(object parameter)
        {
            var filter = parameter as IQueryFilter;
            var query = filter.Resolve();
            _dataFilterService.FilterEventResult += _dataFilterService_FilterEventResult;
           _dataFilterService.FilterDataAsync(query);
        }
        private void _dataFilterService_FilterEventResult(object data)
        {
            FilterView = data;
        }
    }

}