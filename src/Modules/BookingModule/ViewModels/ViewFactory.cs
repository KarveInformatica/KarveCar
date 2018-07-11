using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls.HeaderedWindow;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  This is a factory for the view.
    /// </summary>
    /// <typeparam name="MainView">Type of the view</typeparam>
    /// <typeparam name="FooterView">Type of the footer</typeparam>
    /// <typeparam name="Data">Type of the domain object</typeparam>
    /// <typeparam name="SummaryDto">Type of the summary dto.</typeparam>
    class ViewFactory<MainView,FooterView, Data, SummaryDto> where MainView: UserControl
                                           where FooterView: UserControl
                                           where Data :class
                                           where SummaryDto: BaseDto 
    {

        private IRegionManager _regionManager;
        private IUnityContainer _container;
        private IRegionManager _detailsRegionManager;
        private IEventManager _eventManager;
        private IDataProvider<Data, SummaryDto> _dataProvider;
        private IIdentifier _dataIdentifier;
        
        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="regionManager">Region manager to handle the region</param>
        /// <param name="container">Container to see how does it work</param>
        /// <param name="manager">Event manager to handle events</param>
        /// <param name="dataProvider">Provider to manage the data</param>
        public ViewFactory(IRegionManager regionManager, IUnityContainer container, 
                            IEventManager manager, IDataProvider<Data, SummaryDto> dataProvider,
                            IIdentifier dataIdentifier)
        {
            _regionManager = regionManager;
            _container = container;
            _eventManager = manager;
            _container = container;
            _dataProvider = dataProvider;
            _dataIdentifier = dataIdentifier;
        }
        
        private void CreateNewItem(string name)
        {
            // The composite.
            var detailsRegion = _regionManager.Regions[RegionNames.TabRegion];
            var headeredWindow = _container.Resolve<HeaderedWindow>();
            headeredWindow.Header = name;
            var infoView = _container.Resolve<MainView>();
            var lineview = _container.Resolve<LineGridView>();
            var footerView = _container.Resolve<FooterView>();
            /* 
             * Resolve the view model. Kind of view model first approach. We can use a LineGridView 
             * for every kind of subject and for the specific.
             *  This allows the reuse better than view.
             */
            var vm = _container.Resolve<BookingInfoViewModel>();
            infoView.DataContext = vm;
            lineview.DataContext = vm;
            footerView.DataContext = vm;
            headeredWindow.DataContext = vm;
            _detailsRegionManager = detailsRegion.Add(headeredWindow, null, true);
            var headerRegion = _detailsRegionManager.Regions[RegionNames.HeaderRegion];
            var lineRegion = _detailsRegionManager.Regions[RegionNames.LineRegion];
            var footerRegion = _detailsRegionManager.Regions[RegionNames.FooterRegion];
            lineRegion.Add(lineview, null, true);
            headerRegion.Add(infoView, null, true);
            footerRegion.Add(footerView, null, true);
            headeredWindow.Focus();
        }

        private void Navigate(string code, string viewName)
        {
            Navigate<MainView>(_regionManager, code, viewName);
        }
        private void Navigate<T>(IRegionManager manager, string code, string viewName)
        {
            var navigationParameters = new NavigationParameters
            {
                {"id", code},
                {ScopedRegionNavigationContentLoader.DefaultViewName, viewName}
            };
            var uri = new Uri(typeof(T).FullName + navigationParameters, UriKind.Relative);
            manager.
                RequestNavigate(RegionNames.TabRegion, uri);
        }

        private DataPayLoad BuildShowPayLoadDo<T>(string routedName, T Object)
        {
            var currentPayload = new DataPayLoad();
            // name that it is give from the subclass, it may be a master
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            currentPayload.Registration = routedName;
            currentPayload.HasDataObject = true;
            currentPayload.DataObject = Object;
            return currentPayload;
        }
     /// <summary>
     /// Create a new form
     /// </summary>
     /// <param name="viewModelUri">The uri of the view model.</param>
     /// <param name="subsystem">The subsystem to be used.</param>
     /// <param name="viewModuleName">The name of the view model.</param>
     /// <param name="routedName">The routed name.</param>
        public void NewItem(string subname, DataSubSystem subsystem, string eventManagerName)
        {
            var id = _dataIdentifier.NewId();
            var newDo = _dataProvider.GetNewDo(id);
            var viewName = "Nueva " + "." + id;
            CreateNewItem(id);
            Uri viewModelUri = new Uri("karve://"+subname+"/id/"+id);
            var currentPayload = BuildShowPayLoadDo(viewModelUri.ToString(), newDo);
            currentPayload.Subsystem = subsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = id;
            currentPayload.Sender = viewModelUri.ToString();
            _eventManager.NotifyObserverSubsystem(eventManagerName, currentPayload);
        }
    }
}
