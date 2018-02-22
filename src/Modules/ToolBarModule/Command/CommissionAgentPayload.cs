using System;
using System.ComponentModel;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace ToolBarModule.Command
{
    /// <summary>
    /// Internal class to handle the payload from the commission handler.
    /// </summary>
    internal class CommissionAgentPayload: ToolbarDataPayload
    {
        private DataPayLoad _payload;
        private INotifyTaskCompletion<DataPayLoad> _initializationNotifier;
        private ICommissionAgentDataServices _commissionAgentDataServices;
        public new event ErrorExecuting OnErrorExecuting;
        /// <summary>
        ///  This execute a payload.
        /// </summary>
        /// <param name="services">Data services to be used for executing the payload</param>
        /// <param name="manager">Manager to be used for sending messages to the view model</param>
        /// <param name="payLoad">Payload to be used for sending it.</param>
        public override void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad)
        {
            _commissionAgentDataServices = services.GetCommissionAgentDataServices();
            DataServices = services;
            _payload = payLoad;
            EventManager = manager;
            _initializationNotifier = NotifyTaskCompletion.Create<DataPayLoad>(HandleCommissionAgentSave(_payload), ExecutedPayloadHandler);
        }

        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            return await HandleCommissionAgentSave(payLoad);
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
                case DataPayLoad.Type.UpdateInsertGrid:
                {
                    isInsert = true;
                    BranchesDto branches = payLoad.RelatedObject as BranchesDto;
                    
                    if (branches != null)
                    {
                        result = await DataServices.GetHelperDataServices().ExecuteInsertOrUpdate<BranchesDto, COMI_DELEGA>(branches).ConfigureAwait(false);
                    }
                    ContactsDto contactsDto = payLoad.RelatedObject as ContactsDto;
                    if (contactsDto != null)
                    {
                        result = await DataServices.GetHelperDataServices().ExecuteInsertOrUpdate<ContactsDto, CONTACTOS_COMI>(contactsDto).ConfigureAwait(false);
                    }
                    break;
                }
                case DataPayLoad.Type.DeleteGrid:
                {
                    BranchesDto branches = payLoad.RelatedObject as BranchesDto;

                    if (branches != null)
                    {
                        result = await DataServices.GetHelperDataServices().ExecuteAsyncDelete<BranchesDto, COMI_DELEGA>(branches);

                    }
                    ContactsDto contactsDto = payLoad.RelatedObject as ContactsDto;
                    if (contactsDto != null)
                    {
                        result = await DataServices.GetHelperDataServices().ExecuteAsyncDelete<ContactsDto, CONTACTOS_COMI>(contactsDto);
                    }
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
                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateError;
                string message = isInsert ? "Error during the insert" : "Error during the update";
                payLoad.ResultString = message;
                OnErrorExecuting?.Invoke(message);
            }
            return payLoad;
        }

       
        
    }
}