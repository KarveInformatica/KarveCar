using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using System;
using System.Collections.Generic;
using NLog;
using System.Windows.Input;
using Prism.Commands;

namespace KarveCommon.Generic
{
    /* 
     *  This class has the single responsability to provide common primitives
     *  for routing messages between view models and communication.
     *  
     */
    public abstract class KarveRoutingBaseViewModel : KarveViewModelBase
    {

        protected IEventManager EventManager;

        /// <summary>
        /// Base view model for routing.
        /// </summary>
        public KarveRoutingBaseViewModel() : base()
        {
            ActiveSubsystemCommand = new DelegateCommand(ActiveSubSystem);
        }
        /// <summary>
        /// KarveViewModelBase. Base view model of the all structure
        /// </summary>
        /// <param name="services">DataServices to be used.</param>
        public KarveRoutingBaseViewModel(IDataServices services) : base(services)
        {
        }
        /// <summary>
        ///  KarveViewModelBase.
        /// </summary>
        /// <param name="services">DataServices to be used</param>
        /// <param name="dialogService">DialogServices to be used</param>
        public KarveRoutingBaseViewModel(IDataServices services, IDialogService dialogService, IEventManager eventManager) : base(services, dialogService)
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
            DataPayLoad currentPayload = new DataPayLoad();
            // name that it is give from the subclass, it may be a master
            string routedName = GetRouteName(name);
            currentPayload.PayloadType = DataPayLoad.Type.Show;
            currentPayload.Registration = routedName;
            currentPayload.HasDataObject = true;
            currentPayload.Subsystem = DataSubSystem.CommissionAgentSubystem;
            currentPayload.DataObject = Object;
            if (queries != null)
            {
                currentPayload.Queries = queries;
            }
            return currentPayload;
        }

        public ICommand ActiveSubsystemCommand { set; get; }
        protected void ActiveSubSystem()
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
            DataPayLoad payLoad = new DataPayLoad();
            SetRegistrationPayLoad(ref payLoad);
            payLoad.PayloadType = DataPayLoad.Type.RegistrationPayload;
            EventManager.NotifyToolBar(payLoad);

        }
        /// <summary>
        ///  Associate to the mailbox a name.
        /// </summary>
        /// <param name="mailboxName">Mailbox name</param>
        protected void RegisterMailBox(string mailboxName)
        {
            if (MailBoxHandler != null)
            {
                EventManager.RegisterMailBox(mailboxName, MailBoxHandler);
            }


        }
        /// <summary>
        ///  Delete the name of a mailbox
        /// </summary>
        /// <param name="mailboxName">Mailbox.</param>
        protected void DeleteMailBox(string mailboxName)
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

    }

}