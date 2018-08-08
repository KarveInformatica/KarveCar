using KarveCommon.Generic;
using KarveCommon.Services;
using KarveControls.HeaderedWindow;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Windows.Controls;

namespace BookingModule.ViewModels
{
    /// <summary>
    ///  Abstract view factory that is able to create new views in the tab region.
    /// </summary>
    /// <typeparam name="Data">Domain data. It is a value object</typeparam>
    /// <typeparam name="SummaryDto">Data object to be used in the data provider</typeparam>
    abstract class AbstractViewFactory<Data, SummaryDto> where Data: class where SummaryDto: BaseDto
    {

        protected IRegionManager RegionManager;
        protected IUnityContainer Container;
        protected IRegionManager DetailsRegionManager;
        protected IEventManager EventManager;
        protected IDataProvider<Data, SummaryDto> DataProvider;
             protected IIdentifier DataIdentifier;

        protected AbstractViewFactory(IRegionManager regionManager, IUnityContainer container, IEventManager manager, IDataProvider<Data, SummaryDto> dataProvider, IIdentifier dataIdentifier)
        {
            RegionManager = regionManager;
            Container = container;
            EventManager = manager;
            DataProvider = dataProvider;
            DataIdentifier = dataIdentifier;
        }

        public void NewItem<ViewType>(string subname, string baseUri, DataSubSystem subsystem, string eventManagerName)
        {
            var id = DataIdentifier.NewId();
            var newDo = DataProvider.GetNewDo(id);
            var tmp = subname;
            var upperFirst = tmp.ToUpper();
            tmp = upperFirst[0] + subname.Substring(1);
            var viewName = KarveLocale.Properties.Resources.lnew + " " + tmp + "." + id;
            var uri = new Uri(baseUri + Guid.NewGuid().ToString());
            var currentPayload = BuildShowPayLoadDo(uri.ToString(), newDo);
            currentPayload.Subsystem = subsystem;
            currentPayload.PayloadType = DataPayLoad.Type.Insert;
            currentPayload.PrimaryKeyValue = id;
            currentPayload.Sender = "karve://viewfactory";
            currentPayload.Destination = uri;
            CreateNewItem<ViewType>(viewName, uri, currentPayload);
            EventManager.NotifyObserverSubsystem(eventManagerName, currentPayload);
        }

        internal protected abstract void CreateNewItem<ViewType>(string viewName, Uri uri, DataPayLoad payload);

        protected void Navigate<T>(IRegionManager manager, string code, string viewName)
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
  
        protected DataPayLoad BuildShowPayLoadDo<T>(string routedName, T Object)
        {
            var currentPayload = new DataPayLoad();
            // name that it is give from the subclass, it may be a master
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            currentPayload.Registration = routedName;
            currentPayload.HasDataObject = true;
            currentPayload.DataObject = Object;
            return currentPayload;
        }
    }

    class ViewFactory<Data, SummaryDto> : AbstractViewFactory<Data,SummaryDto>
                                                  where Data:class
                                                  where SummaryDto: BaseDto
    {
        public ViewFactory(IRegionManager regionManager, IUnityContainer container,
                           IEventManager manager, IDataProvider<Data, SummaryDto> dataProvider,
                           IIdentifier dataIdentifier) : base(regionManager, container, manager, dataProvider, dataIdentifier)
        {
            RegionManager = regionManager;
            Container = container;
            EventManager = manager;
            Container = container;
            DataProvider = dataProvider;
            DataIdentifier = dataIdentifier;
        }

        internal protected override void CreateNewItem<ViewType>(string viewName, Uri uri, DataPayLoad payLoad)
        {
            Navigate<ViewType>(RegionManager, payLoad.PrimaryKeyValue, viewName);
        }

    }
    /// <summary>
    ///  This is a factory for the view.
    /// </summary>
    /// <typeparam name="MainView">Type of the view</typeparam>
    /// <typeparam name="FooterView">Type of the footer</typeparam>
    /// <typeparam name="Data">Type of the domain object</typeparam>
    /// <typeparam name="SummaryDto">Type of the summary dto.</typeparam>
    class ViewFactory<MainView,FooterView, Data, SummaryDto>: AbstractViewFactory<Data, SummaryDto>
                                           where MainView: UserControl
                                           where FooterView: UserControl
                                           where Data :class
                                           where SummaryDto: BaseDto  
    {
        private IRegionManager _detailsRegionManager;


        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="regionManager">Region manager to handle the region</param>
        /// <param name="container">Container to see how does it work</param>
        /// <param name="manager">Event manager to handle events</param>
        /// <param name="dataProvider">Provider to manage the data</param>
        public ViewFactory(IRegionManager regionManager, IUnityContainer container, 
                            IEventManager manager, IDataProvider<Data, SummaryDto> dataProvider,
                            IIdentifier dataIdentifier): base(regionManager, container, manager, dataProvider, dataIdentifier)
        {
            RegionManager = regionManager;
            Container = container;
            EventManager = manager;
            Container = container;
            DataProvider = dataProvider;
            DataIdentifier = dataIdentifier;
        }

        internal protected override void CreateNewItem<T>(string name, Uri uri, DataPayLoad payLoad)
        {
            // The composite.
            var detailsRegion = RegionManager.Regions[RegionNames.TabRegion];
            var headeredWindow = Container.Resolve<HeaderedWindow>();
            headeredWindow.Header = name;
            var infoView = Container.Resolve<MainView>();
            var lineview = Container.Resolve<LineGridView>();
            var footerView = Container.Resolve<FooterView>();
            /* 
             * Resolve the view model. Kind of view model first approach. We can use a LineGridView 
             * for every kind of subject and for the specific.
             *  This allows the reuse better than view.
             */
            var vm = Container.Resolve<BookingInfoViewModel>();
            vm.ViewModelUri = uri;
            // datacontext has inheritance.
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
        
        
    }
}
