using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveCommon.Generic;
using NLog;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  Internal class with data payload
    /// </summary>
    abstract class  ToolbarDataPayload : IDataPayLoadHandler
    {
        private IEventManager CurrentEventManager;
        protected DataPayLoad CurrentPayload;
        private IDataServices _dataServices;
        protected readonly PropertyChangedEventHandler ExecutedPayloadHandler;
        protected INotifyTaskCompletion<DataPayLoad> ToolbarInitializationNotifier;
        private Dictionary<DataSubSystem, string> _dictionary = new Dictionary<DataSubSystem, string>()
        {
            { DataSubSystem.CommissionAgentSubystem, EventSubsystem.CommissionAgentSummaryVm},
            { DataSubSystem.CompanySubsystem, EventSubsystem.CompanySummaryVm},
            { DataSubSystem.ClientSubsystem, EventSubsystem.ClientSummaryVm},
            { DataSubSystem.OfficeSubsystem, EventSubsystem.OfficeSummaryVm},
            { DataSubSystem.HelperSubsytsem, EventSubsystem.HelperSubsystem},
            { DataSubSystem.SupplierSubsystem, EventSubsystem.SuppliersSummaryVm},
            { DataSubSystem.VehicleSubsystem, EventSubsystem.VehichleSummaryVm }
          };

        /// <summary>
        ///  Toolbar data payload
        /// </summary>
        public ToolbarDataPayload()
        {
            ExecutedPayloadHandler += OnExecutedPayload;
           
        }
        /// <summary>
        ///  Set or Get the event manager.
        /// </summary>
        public IEventManager EventManager
        {
            set
            {
                CurrentEventManager= (IEventManager) value;
            }
            get { return CurrentEventManager; }
        }
        /// <summary>
        /// Get or Set data services.
        /// </summary>
        public IDataServices DataServices
        {
            set
            {
                _dataServices = (IDataServices)value;
            }
            get { return _dataServices; }
        }

        /// <summary>
        ///  Take any action during the event manager
        /// </summary>
        /// <param name="sender">Sender of the mesasge</param>
        /// <param name="propertyChangedEventArgs">Paramerts of the message</param>
        protected void OnExecutedPayload(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (CurrentEventManager != null)
            {
                NotifyEventManager(EventManager, CurrentPayload);
            }
        }
        /// <summary>
        ///  Notify the behaviour of the event manager.
        /// </summary>
        /// <param name="eventManager">Event manager of the toolbar.</param>
        /// <param name="payLoad"> Kind of payload.</param>
        private void NotifyEventManager(IEventManager eventManager, DataPayLoad payLoad)
        {
            if (payLoad == null)
            {
                return;
            }
            string destinationSubsystem = "";
            _dictionary.TryGetValue(payLoad.Subsystem, out destinationSubsystem);
            if (!string.IsNullOrEmpty(destinationSubsystem))
            {
                eventManager.SendMessage(destinationSubsystem, payLoad);
            }
        }
        protected void SendError(string message)
        {
            OnErrorExecuting?.Invoke(message);
        }
        /// <summary>
        ///  Launch an error for executing
        /// </summary>
        public event ErrorExecuting OnErrorExecuting;
        /// FIXME: see if the payload can be TAP.
        /// <summary>
        /// Abstract method to override for executing the payload
        /// </summary>
        /// <param name="services">DataServices</param>
        /// <param name="manager">Event manager</param>
        /// <param name="payLoad">Payload to be filed.</param>
        public abstract void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad);       
        protected abstract  Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad); 
    }
}
