using KarveCommon.Generic;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System.Windows;

namespace KarveControls.HeaderedWindow
{
    /// <summary>
    ///  HeaderedWindowFactory. Creates a window factory. A headered window is a view with a header, several lines in a grid
    ///  and footer. The line region (composed of a grid with several lines) can be hidden as well the footer, resulting in just
    ///  one window with a single header. Basically:
    ///  1. Header View / User Control
    ///  2. One Central User Controls that contains a grid
    ///  3. One footer.
    /// </summary>
    /// <typeparam name="Header">Type of the header.</typeparam>
    /// <typeparam name="Footer">Type of the footer.</typeparam>
    public class HeaderedWindowFactory<Header, Footer> where Header: FrameworkElement where Footer: FrameworkElement
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;
        private HeaderedWindowFactory(IRegionManager manager, IUnityContainer container)
        {
            _regionManager = manager;
            _container = container;
        }
        /// <summary>
        ///  Retrieve the factory.
        /// </summary>
        /// <param name="manager">The manager to be used.</param>
        /// <param name="container">The container to be used for resolving the views.</param>
        /// <returns></returns>
        public static HeaderedWindowFactory<Header,Footer> GetFactory(IRegionManager manager, IUnityContainer container) 
        {
            return new HeaderedWindowFactory<Header,Footer>(manager, container);
        }
        /// <summary>
        ///  Set or Get the region manager.
        /// </summary>
        public IRegionManager DetailsRegionManager { set; get; }
    
        /// <summary>
        /// Create a new composite view headered window.
        /// </summary>
        /// <param name="name">The title of the window</param>
        /// <param name="viewModel">The view model to be used in the view as DataContext</param>
        /// <returns>A new headered window</returns>
        public HeaderedWindow CreateNewItem(string name, KarveViewModelBase viewModel)
        {
            // The composite.
            var detailsRegion = _regionManager.Regions[RegionNames.TabRegion];
            var headeredWindow = _container.Resolve<HeaderedWindow>();
            headeredWindow.Header = name;
            var infoView = _container.Resolve<Header>();
            var lineview = _container.Resolve<LineGridView>();
            var footerView = _container.Resolve<Footer>();
            /* 
             * Resolve the view model. Kind of view model first approach. We can use a LineGridView 
             * for every kind of subject and for the specific.
             *  This allows the reuse better than view.
             */
            infoView.DataContext = viewModel;
            lineview.DataContext = viewModel;
            footerView.DataContext =viewModel;
            headeredWindow.DataContext =viewModel;
            DetailsRegionManager = detailsRegion.Add(headeredWindow, null, true);
            var headerRegion = DetailsRegionManager.Regions[RegionNames.HeaderRegion];
            var lineRegion = DetailsRegionManager.Regions[RegionNames.LineRegion];
            var footerRegion = DetailsRegionManager.Regions[RegionNames.FooterRegion];
            lineRegion.Add(lineview, null, true);
            headerRegion.Add(infoView, null, true);
            footerRegion.Add(footerView, null, true);
            return headeredWindow;
        }
    }
}
