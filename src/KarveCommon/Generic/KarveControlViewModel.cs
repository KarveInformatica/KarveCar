using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using Prism.Regions;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  Generic class implementation for a KarveControlViewModel.
    /// </summary>
    public abstract class KarveControlViewModel : KarveRoutingBaseViewModel, INavigationAware, IEventObserver, IDisposeEvents
    {
        
        /// <summary>
        ///  KarveControlViewModel. Base view model for all the control view models.
        /// </summary>
        /// <param name="services">Services</param>
        /// <param name="requestController">Request controller</param>
        /// <param name="dialogService">Dialog service</param>
        /// <param name="eventManager">Event manager</param>
        protected KarveControlViewModel(IDataServices services, IInteractionRequestController requestController, IDialogService dialogService, IEventManager eventManager) : base(services, requestController, dialogService, eventManager)
        {
            PagingEvent += OnPagedEvent;
        }



        /// <summary>
        ///  This command is useful for opening a new window.
        /// </summary>
        public ICommand OpenCommand { set; get; }

        /// <summary>
        ///  StartLoading and notiy
        /// </summary>
        public abstract void StartAndNotify();
        /// <summary>
        /// Get the route name has been left to the abstract.
        /// </summary>
        /// <param name="name">Name of the routing</param>
        /// <returns></returns>
        protected abstract override string GetRouteName(string name);
        /// <summary>
        ///  Register the payload
        /// </summary>
        /// <param name="payLoad">Payload to be registered</param>
        protected abstract override void SetRegistrationPayLoad(ref DataPayLoad payLoad);
        /// <summary>
        /// Navigate to the view
        /// </summary>
        /// <param name="code">Code of the view to navigate</param>
        /// <param name="viewName">Viewname to view</param>
        protected void Navigate<T>(IRegionManager manager, string code, string viewName)
        {
            var navigationParameters = new NavigationParameters
            {
                {"id", code},
                {ScopedRegionNavigationContentLoader.DefaultViewName, viewName}
            };
            var uri = new Uri(typeof(T).FullName + navigationParameters, UriKind.Relative);
            manager.
                RequestNavigate("TabRegion", uri);
        }

        public override void DisposeEvents()
        {
            base.DisposeEvents();
            PagingEvent -= OnPagedEvent;

        }
        /// <summary>
        ///  The idea here is to provide safe default.
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        public virtual void IncomingPayload(DataPayLoad payload)
        {

        }
    }
}
