using System;

namespace KarveCommon.Services
{
    /// <summary>
    ///  Delegate to be triggered for a new message in the mailbox.
    /// </summary>
    /// <param name="payLoad">Data present in the mailbox</param>
    public delegate void MailBoxMessageHandler(DataPayLoad payLoad);
    /// <summary>
    /// Class containing the different subsystem.
    /// </summary>
    public class EventSubsystem
    {
        public const string CommissionAgentSummaryVm = "CommisionAgentSummaryVm";
        public const string SuppliersSummaryVm = "ProvidersControlViewModel";
        public const string VehichleSummaryVm = "VehicleControlViewModel";
    }
    /// <summary>
    /// Interface for communication between view models.
    /// </summary>
    public interface IEventManager
    {
        /// <summary>
        ///  This register an interface for a subsystem
        /// </summary>
        /// <param name="id">Identifier of the subsystem</param>
        /// <param name="obs">Event observer</param>
        void RegisterObserverSubsystem(string id, IEventObserver obs);
        /// <summary>
        /// This notify the subsystem
        /// </summary>
        /// <param name="id">Identifier of the subsystem to be notified</param>
        /// <param name="dataPayload">Message to be sent</param>
        void NotifyObserverSubsystem(string id, DataPayLoad dataPayload);
        /// <summary>
        ///  This register the global observer to be notified
        /// </summary>
        /// <param name="obs">Observer to be registered.</param>
        void RegisterObserver(IEventObserver obs);
        /// <summary>
        ///  Notify a message globally.
        /// </summary>
        /// <param name="payload"></param>
        void NotifyObserver(DataPayLoad payload);
        /// <summary>
        /// Register a toolbar observer
        /// </summary>
        /// <param name="obs">Observer to be registered</param>
        void RegisterObserverToolBar(IEventObserver obs);
        /// <summary>
        /// Notify the toolbar view model
        /// </summary>
        /// <param name="payload">Message to be sent</param>
        void NotifyToolBar(DataPayLoad payload);
        /// <summary>
        /// Delete an observer subsystem
        /// </summary>
        /// <param name="id">Identifier of the subsystem</param>
        /// <param name="obs">Observer to be notified</param>
        void DeleteObserverSubSystem(string id, IEventObserver obs);
        /// <summary>
        /// Disable the notifications
        /// </summary>
        /// <param name="id">Identificator of the subsystem</param>
        /// <param name="obs">Observer to be notified</param>
        void DisableNotify(string id, IEventObserver obs);
        /// <summary>
        /// Enable the notification for the susbsystem
        /// </summary>
        /// <param name="id">Identifier of the subsystem</param>
        /// <param name="obs">Observer to be notified</param>
        void EnableNotify(string id, IEventObserver obs);
        /// <summary>
        /// Register a view model to a mailbox to receive message (direct messaging)
        /// </summary>
        /// <param name="id">Identifier of the view model.</param>
        /// <param name="messageHandler">Message handler</param>
        void RegisterMailBox(string id, MailBoxMessageHandler messageHandler);
        /// <summary>
        /// Delete a mailbox subscription for a view model.
        /// </summary>
        /// <param name="id"></param>
        void DeleteMailBoxSubscription(string id);
        /// <summary>
        /// Send a message to a view module through a mailbox. When the message arrives to the mailbox, 
        /// an event new mail has been triggered.
        /// </summary>
        /// <param name="viewModuleId">Identifier of the view module</param>
        /// <param name="payLoad">Message to be sent.</param>
        void SendMessage(string viewModuleId, DataPayLoad payLoad);
    }
}