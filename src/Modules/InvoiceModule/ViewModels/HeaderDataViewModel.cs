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
        private bool _linevisible;
        private bool _footervisible;

        public HeaderDataViewModel()
        {
            Title = "Facturas";
            LineVisible = true;
            FooterVisible = true;
        }

        /// <summary>
        /// LineVisible
        /// </summary>
        public bool LineVisible
        {
            set
            {
                _linevisible = value;
                RaisePropertyChanged();
            }
            get => _linevisible;
        }

        /// <summary>
        /// LineVisible
        /// </summary>
        public bool FooterVisible
        {
            set
            {
                _footervisible = value;
                RaisePropertyChanged();
            }
            get => _footervisible;
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