using System;
using System.ComponentModel;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;

namespace ToolBarModule.Command
{
    /// <summary>
    /// Internal class to handle the payload from the commission handler.
    /// </summary>
    internal class CommissionAgentPayload: IDataPayLoadHandler
    {
        private DataPayLoad _payload;
        private INotifyTaskCompletion<DataPayLoad> _initializationNotifier;
        private readonly PropertyChangedEventHandler _onExecutedPayload;
        private ICommissionAgentDataServices _commissionAgentDataServices;
        private IEventManager _eventManager;
        public CommissionAgentPayload()
        {
            _onExecutedPayload+=OnExecutedPayload;
        }

        private void OnExecutedPayload(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            DataPayLoad payLoad = _payload;
            
            NotifyEventManager(_eventManager, payLoad);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services">Data services to be used for executing the payload</param>
        /// <param name="manager">Manager to be used for sending messages to the view model</param>
        /// <param name="payLoad">Payload to be used for sending it.</param>
        public void ExecutePayload(IDataServices services, IEventManager manager, DataPayLoad payLoad)
        {
            _commissionAgentDataServices = services.GetCommissionAgentDataServices();
            _payload = payLoad;
            _eventManager = manager;
            _initializationNotifier = NotifyTaskCompletion.Create<DataPayLoad>(HandleCommissionAgentSave(_payload), _onExecutedPayload);
        }

        private void NotifyEventManager(IEventManager eventManager, DataPayLoad payLoad)
        {
            eventManager.SendMessage(EventSubsystem.CommissionAgentSummaryVm, payLoad);
        }
        
        private async Task<DataPayLoad> HandleCommissionAgentSave(DataPayLoad payLoad)
        {
            bool result = false;
            bool isInsert = false;
            ICommissionAgent agent = (ICommissionAgent)payLoad.DataObject;
            if (agent== null)
            {
                string message = (payLoad.PayloadType == DataPayLoad.Type.Insert) ? "Error during the insert" : "Error during the update";
                OnErrorExecuting?.Invoke(message);
            }
            switch (payLoad.PayloadType)
            {
                case DataPayLoad.Type.Update:
                {
                    result = await _commissionAgentDataServices.SaveChangesCommissionAgent(agent).ConfigureAwait(false);
                    break;
                }
                case DataPayLoad.Type.Insert:
                {
                    isInsert = true;
                    result = await _commissionAgentDataServices.SaveCommissionAgent(agent).ConfigureAwait(false);
                    break;
                }
            }
            if (result)
            {
                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
             
                
            }
            else
            {
                string message = isInsert ? "Error during the insert" : "Error during the update";
                OnErrorExecuting?.Invoke(message);
            }
            return payLoad;
        }

        public event ErrorExecuting OnErrorExecuting;
        
    }
}