using KarveCommon.Generic;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KarveControls.HeaderedWindow
{
    /// <summary>
    ///  HeaderedWindowFactory. Creates a window factory
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

        public static HeaderedWindowFactory<Header,Footer> GetFactory(IRegionManager manager, IUnityContainer container) 
        {
            return new HeaderedWindowFactory<Header,Footer>(manager, container);
        }
        public IRegionManager DetailsRegionManager { set; get; }
        /// <summary>
        ///  This returns an item from an headered window.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
