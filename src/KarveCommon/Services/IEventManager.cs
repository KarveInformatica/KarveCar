﻿using System;

namespace KarveCommon.Services
{
    /// <summary>
    ///  Delegate to be triggered for a new message in the mailbox.
    ///  Each view model can configure a mailbox to receive a message.
    ///  The message is a direct message from another view model.
    /// </summary>
    /// <param name="payLoad">Data present in the mailbox</param>
    public delegate void MailBoxMessageHandler(DataPayLoad payLoad);
    /// <summary>
    /// Class containing the different subsystem.
    /// </summary>
    public class EventSubsystem
    {
        /// <summary>
        ///  Commission agent subsytem name
        /// </summary>
        public const string CommissionAgentSummaryVm = "CommisionAgentSummaryVm";
        /// <summary>
        ///  Supplier subsystem name
        /// </summary>
        public const string SuppliersSummaryVm = "ProvidersControlViewModel";
        /// <summary>
        ///  Vehicle subsystem name
        /// </summary>
        public const string VehichleSummaryVm = "VehicleControlViewModel";
        /// <summary>
        ///  Helper subsystem name
        /// </summary>
        public const string HelperSubsystem = "HelperSubsystem";
        /// <summary>
        ///  Client subsystem name.
        /// </summary>
        public const string ClientSummaryVm = "ClientsControlViewModel";
        /// <summary>
        ///  Name of the office
        /// </summary>
        public const string OfficeSummaryVm = "OfficeControlViewModel";
        /// <summary>
        ///  Name of the company
        /// </summary>
        public const string CompanySummaryVm = "CompanyControlViewModel";
        /// <summary>
        /// Fare control view model
        /// </summary>
        public const string FareSummaryVm = "FareControlViewModel";
        /// <summary>
        ///  Contract control view model
        /// </summary>
        public const string ContractSummaryVm = "ContractControlViewModel";
        /// <summary>
        ///  Inovice control view model.
        /// </summary>
        public static string InvoiceSubsystemVm = "InvoiceSubsystem";
        /// <summary>
        ///  BookingSubsystem view model.
        /// </summary>
        public static string BookingSubsystemVm = "BookingSubsystemViewModel";

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
        /// Register a view model to a mailbox to receive message (direct messaging)
        /// </summary>
        /// <param name="id">Identifier of the view model.</param>
        /// <param name="messageHandler">Message handler delegate</param>
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
        /// <summary>
        ///  Delete an observer.
        /// </summary>
        /// <param name="observer"></param>
        void DeleteObserver(IEventObserver observer);
        /// <summary>
        ///  Check if a mailbox is registered.
        /// </summary>
        /// <param name="id">Mailbox identifier</param>
        /// <param name="payLoad">payload identifier</param>
        /// <returns>True if a mailbox is available.</returns>
        bool IsRegisteredMailbox(string id, DataPayLoad payLoad);
        /// <summary>
        ///  Returns if the event manager has been notified. 
        ///  A notification happens when a DataPayload has been received.
        /// </summary>
        bool IsNotified {  get; }

        //void Clear(global::MasterModule.ViewModels.ProvidersControlViewModel providersControlViewModel);
    }
}