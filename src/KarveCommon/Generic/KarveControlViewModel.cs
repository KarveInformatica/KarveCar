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
    ///  We have two kind of view models. A control view model has the resposability to trigger new view using a view first approach
    ///  or  a view model first approach. 
    ///  A view first approach is when the view is created before and launched the view model.
    ///  A view model first approach is when the view model is composed and than associated to a view. 
    ///  The second is used for headered view (cabecera-linea) mainly since it enables the reuse. 
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
        /// Command for opening a new view from each control view model.
        /// </summary>
        public ICommand OpenCommand { set; get; }

        /// <summary>
        /// This function start the incremental load for the view model.
        /// The process is always the same:
        /// 1. Get the appropriate service from data service repository
        /// 2. Launch a async+wait command to retrieve the paged data (first page).
        /// 3. The result has been notified through a Task Completion.
        /// 4. The event handler call the base class to check the result.
        /// 4.1. If the result is correct we trigger a SetResult in this class.
        /// 4.2. If the result is not correct we show a dialog service.
        /// 5. Get load incremenentally the data.
        /// </summary>
        /// public abstract void StartAndNotify();
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
       

        public override void DisposeEvents()
        {
            base.DisposeEvents();
            PagingEvent -= OnPagedEvent;

        }
        /// <summary>
        ///  Prism navigation support. 
        ///  We provide a default for avoiding spreading the navigation in the hierarchy
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
        /// <summary>
        ///  Prism navigation support. 
        ///  We provide a default for avoiding spreading the navigation in the hierarchy
        /// </summary>
        /// <param name="navigationContext"></param>
        /// 
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
        /// <summary>
        ///  Prism navigation support. 
        ///  We provide a default for avoiding spreading the navigation in the hierarchy
        /// </summary>
        /// <param name="navigationContext">Context of the navigation</param>
        /// 
        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        /// <summary>
        ///  The event manager (Mediator pattern) send a payload to a distinct subsystem.
        ///  Each member that is an event observer (Observer pattern) receives a data payload.
        ///  A DataPayload is an object to comunicate between view models and it can contains any data.
        ///  It is serializable in XML.
        /// </summary>
        /// <param name="payload">Payload to be handle</param>
        public virtual void IncomingPayload(DataPayLoad payload)
        {

        }
    }
}
