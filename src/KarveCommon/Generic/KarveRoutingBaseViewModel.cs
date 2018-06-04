using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using NLog;
using System.Windows.Input;
using Prism.Commands;
using Prism.Regions;
using System.ComponentModel;

namespace KarveCommon.Generic
{
    /* 
     *  This class has the single responsability to provide common primitives
     *  for routing messages between view models and communication. Between view model
     *  we have an event manager. Event manager has the resposabilities to:
     *  1. Implement a mailbox system. 
     *     A mailbox system is a direct messaging mechanisms between view models.
     *  2. Implement a observer for each subsystem
     *  3. Implement toolbar notification.
     *  
     */
    public abstract class KarveRoutingBaseViewModel : KarveViewModelBase
    {

        protected IEventManager EventManager;
        protected const string RegionName = "TabRegion";
      


        /// <summary>
        /// Base view model for routing.
        /// </summary>
        public KarveRoutingBaseViewModel() : base()
        {
            ActiveSubsystemCommand = new DelegateCommand(ActiveSubSystem);
        }
        /// <summary>
        /// Karve Routing View Model Constructor.
        /// </summary>
        /// <param name="services">Data Services. They enable data retrieving.</param>
        /// <param name="assistService">Interaction controller. It enables modal view that shows an incremental grid of data.</param>
        public KarveRoutingBaseViewModel(IDataServices services, IInteractionRequestController interactionRequest) : base(services, interactionRequest)
        {
        }
        /// <summary>
        /// Karve Routing View Model Constructor.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="controller"></param>
        /// <param name="dialogService"></param>
        /// <param name="eventManager"></param>
        public KarveRoutingBaseViewModel(IDataServices services, IInteractionRequestController controller, IDialogService dialogService, IEventManager eventManager) : base(services, controller,dialogService)
        {
            EventManager = eventManager;
        }
        /// <summary>
        ///  Get the routing name for the payload for sending the payload to the event manager.
        ///  The event manager will switch the values following the payload
        /// </summary>
        /// <param name="name">Name of routing.</param>
        /// <returns>The route for the events.</returns>
        protected abstract string GetRouteName(string name);
        /// <summary>
        /// Makes a payload with a data object or a data transfer object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Name of the form/tab</param>
        /// <param name="object">Object to be sent to the data</param>
        /// <param name="queries">Queries optional to be sent to the info view.</param>
        /// <returns></returns>
        protected DataPayLoad BuildShowPayLoadDo<T>(string name, T Object, IDictionary<string, string> queries = null)
        {
            var currentPayload = new DataPayLoad();
            // name that it is give from the subclass, it may be a master
            var routedName = GetRouteName(name);
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            currentPayload.Registration = routedName;
            currentPayload.HasDataObject = true;
            currentPayload.DataObject = Object;
            if (queries != null)
            {
                currentPayload.Queries = queries;
            }
            return currentPayload;
        }
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
        /// <summary>
        /// This command enable the selection of the active subsystem by XAML 
        /// using an interaction trigger when the view has been loaded or changed.
        /// </summary>
        public virtual ICommand ActiveSubsystemCommand { set; get; }
        /// <summary>
        ///  Register the current active subsystem. The toolbar needs to know which subsytem is active.
        ///  (TODO: Decouple the handling of messages from the toolbar module.).
        ///  Each view belongs to a subsystem that it is tighted with a domain concept: i.e vehicles,
        ///  providers, invoices, booking. So when a view is active, its view model send a registration 
        ///  payload to the toolbar.  This is needed for the new/delete command in the toolbar. 
        ///  The toolbar when knows the active subsystem sends through the mediatior / event manager, 
        ///  a payload to the controller of the subsystem for creating or deleting a view.
        /// </summary>
        protected virtual void ActiveSubSystem()
        {
            // change the active subsystem in the toolbar state.
            RegisterToolBar();
        }
        /// <summary>
        ///  This shall be used by different view models to set the registration payload.
        /// </summary>
        /// <param name="payLoad"> This is the payalod to be be registered</param>
        protected abstract void SetRegistrationPayLoad(ref DataPayLoad payLoad);

        /// <summary>
        ///  Register the toolbar.
        /// </summary>
        protected void RegisterToolBar()
        {
            // each module notify the toolbar.
            var payLoad = new DataPayLoad();
            SetRegistrationPayLoad(ref payLoad);
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            EventManager.NotifyToolBar(payLoad);

        }
        /// <summary>
        ///  Associate to the mailbox a name.A view model can through the mediator/event manager 
        ///  receive a payload in broacast (directed to each viewmodel belonging to a system) or
        ///  directly through a mailbox. The mailbox handler will manage the DataPayload. It 
        ///  can be an insert/delete/update/whatever from another view model.
        /// </summary>
        /// <param name="mailboxName">Mailbox name</param>
        protected void RegisterMailBox(string mailboxName)
        {
            if (MailBoxHandler != null)
            {
               
                EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
            }


        }

        protected bool IsMessageForMe<DtoType,DomainType>(DataPayLoad payLoad, string codeDomain, string codeDto)
        {
            if (!(payLoad.DataObject is DtoType dto))
            {
                if (payLoad.DataObject is DomainType domainObject)
                {
                    if (codeDomain != PrimaryKeyValue)
                    {
                        return false;

                    }
                }
            }
            else
            {
                if (codeDto != PrimaryKeyValue)
                {
                    return false;

                }

            }

            return true;
        }
        /// <summary>
        ///  Delete the name of a mailbox
        /// </summary>
        /// <param name="mailboxName">Mailbox.</param>
        protected virtual void DeleteMailBox(string mailboxName)
        {
            if (MailBoxHandler != null)
            {
                EventManager.DeleteMailBoxSubscription(mailboxName);
                
            }
        }
        /// <summary>
        /// Name of the mailbox.
        /// </summary>
        protected string MailboxName { set; get; }

        
        protected virtual void HandleMessageBoxPayLoad(DataPayLoad payLoad)
        {
            switch (payLoad.PayloadType)
            {
                case DataPayLoad.Type.Delete:
                    DeleteItem(payLoad);
                    break;
                case DataPayLoad.Type.Insert:
                    NewItem();
                    break;
                case DataPayLoad.Type.Update:
                    break;
                case DataPayLoad.Type.RegistrationPayload:
                    break;
                case DataPayLoad.Type.Show:
                    break;
                case DataPayLoad.Type.UpdateView:
                    StartNotify();
                    break;
                case DataPayLoad.Type.UpdateData:
                    break;
                case DataPayLoad.Type.Any:
                    break;
                case DataPayLoad.Type.CultureChange:
                    break;
                case DataPayLoad.Type.UpdateInsertGrid:
                    break;
                case DataPayLoad.Type.DeleteGrid:
                    break;
                case DataPayLoad.Type.RevertChanges:
                    break;
                case DataPayLoad.Type.UpdateError:
                    break;
                case DataPayLoad.Type.UnregisterPayload:
                    break;
                case DataPayLoad.Type.Dispose:
                    break;
                case DataPayLoad.Type.ShowNavigate:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected virtual void StartNotify()
        {
           
        }

        protected virtual void NewItem()
        {

        }
        

        protected virtual void DeleteItem(DataPayLoad payLoad)
        {

        }

        /// <summary>
/// This method happens when the item is deleted for the toolbar.
/// </summary>
/// <param name="primaryKey"></param>
/// <param name="PrimaryKeyValue"></param>
/// <param name="subSystem"></param>
/// <param name="subSystemName"></param>
protected void DeleteEventCleanup(string primaryKey, string PrimaryKeyValue, DataSubSystem subSystem,
            string subSystemName)
        {
            if (primaryKey == PrimaryKeyValue)
            {
                DataPayLoad payLoad = new DataPayLoad
                {
                    Subsystem = subSystem,
                    SubsystemName = subSystemName,
                    PrimaryKeyValue = PrimaryKeyValue,
                    PayloadType = DataPayLoad.Type.Delete
                };
                EventManager.NotifyToolBar(payLoad);
               
                PrimaryKeyValue = "";
            }
        }

        protected void UnregisterToolBar(string key)
        {
            var payLoadUnregister = new DataPayLoad
            {
                PayloadType = DataPayLoad.Type.UnregisterPayload,
                PrimaryKeyValue = key
            };
            EventManager.NotifyToolBar(payLoadUnregister);
        }
        /// <summary>
        ///  This build a data payload, enforcing the value that cames from the UI.
        /// </summary>
        /// <param name="eventDictionary">Dictionary that it cames from the UI components</param>
        /// <returns>A payload to be sent to other view models.</returns>
        protected DataPayLoad BuildDataPayload(IDictionary<string, object> eventDictionary)
        {
            DataPayLoad payLoad = new DataPayLoad {ObjectPath = ViewModelUri};
            if (string.IsNullOrEmpty(payLoad.PrimaryKeyValue))
            {
                payLoad.PrimaryKeyValue = PrimaryKeyValue;
                payLoad.PayloadType = DataPayLoad.Type.Update;
            }
            if (eventDictionary.ContainsKey("DataObject"))
            {
                if (eventDictionary["DataObject"] == null)
                {
                    DialogService?.ShowErrorMessage("DataObject is null");
                }
                var data = eventDictionary["DataObject"];
                if (eventDictionary.ContainsKey("Field"))
                {
                    var name = eventDictionary["Field"] as string;
                    GenericObjectHelper.PropertySetValue(data, name, eventDictionary["ChangedValue"]);
                }
                payLoad.DataObject = data;
                payLoad.HasDataObject = true;
                eventDictionary["DataObject"] = data;
                payLoad.DataDictionary = eventDictionary;
            }
            return payLoad;
        }

    }

}