using Prism.Mvvm;
using Prism.Regions;

namespace InvoiceModule.ViewModels
{
    /// <summary>
    ///     Header data view model.
    /// </summary>
    internal class HeaderDataViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        private string _title = string.Empty;

        public HeaderDataViewModel()
        {
            Title = "Facturas";
        }

        /// <summary>
        ///     Title code.
        /// </summary>
        public string Title
        {
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
            get => _title;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool KeepAlive => false;
    }
}