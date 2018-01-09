using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  Internal class with data payload
    /// </summary>
    abstract class  ToolbarDataPayload : IDataPayLoadHandler
    {
        protected readonly PropertyChangedEventHandler ExecutedPayloadHandler;
        private IEventManager CurrentEventManager;
        protected DataPayLoad CurrentPayload;
        private IDataServices _dataServices;
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
            switch (payLoad.Subsystem)
            {
                case DataSubSystem.CommissionAgentSubystem:
                {
                    eventManager.SendMessage(EventSubsystem.CommissionAgentSummaryVm, payLoad);
                    break;
                }
                case DataSubSystem.VehicleSubsystem:
                {
                    eventManager.SendMessage(EventSubsystem.VehichleSummaryVm, payLoad);
                    break;
                }
                case DataSubSystem.SupplierSubsystem:
                {
                    eventManager.SendMessage(EventSubsystem.SuppliersSummaryVm, payLoad);
                    break;
                }
            }
        }
        public event ErrorExecuting OnErrorExecuting;
        public abstract void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad);       
        protected abstract  Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad); 
    }
}
