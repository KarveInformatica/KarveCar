using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  Internal class to handle correctly a payload.
    /// </summary>
    internal class ClientDataPayload: ToolbarDataPayload
    {
        private IClientDataServices _clientDataServices = null;
        private DataPayLoad _payload;
        private INotifyTaskCompletion<DataPayLoad> _initializationNotifier;
        ///  The ctor has been initialized correctly.
        
        /// <summary>
        ///  This execute the data payload received from the toolbar
        /// </summary>
        /// <param name="services">DataServices</param>
        /// <param name="manager">Event manager for communicating between view model</param>
        /// <param name="payLoad">DataPayload to be executed</param>
        public override void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad)
        {
            _clientDataServices = services.GetClientDataServices();
            _payload = payLoad;
            EventManager = manager;
            DataServices = services;
            // FIXME: move to the parent class.
            _initializationNotifier = NotifyTaskCompletion.Create<DataPayLoad>(HandleSaveOrUpdate(payLoad), ExecutedPayloadHandler);
        }

        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            bool result = false;
            bool isInsert = payLoad.PayloadType == DataPayLoad.Type.Insert;
            ClientViewObject clientData = payLoad.DataObject as ClientViewObject;
            // pre: DataServices and vehicle shall be present.
            if ((DataServices == null))
            {
                DataPayLoad nullDataPayLoad = new NullDataPayload();
                return nullDataPayLoad;
            }
            if (clientData == null)
            {
                string message = (isInsert) ? "Error during the insert" : "Error during the update";
                SendError(message);
                // i return a null payload.
                return new NullDataPayload();
            }
            // FIXME: check for the law of demeter.
            var clientDo = await DataServices.GetClientDataServices().GetDoAsync(clientData.NUMERO_CLI);
            if (clientDo == null)
            {
                payLoad.PayloadType = DataPayLoad.Type.Insert;
            }
            AbstractDomainWrapperFactory factory = AbstractDomainWrapperFactory.GetFactory(DataServices);
            IClientData clientWrapper = await factory.CreateClientAsync(clientData).ConfigureAwait(false); 
            clientWrapper.Value = clientData;
            result = await DataServices.GetClientDataServices().SaveAsync(clientWrapper).ConfigureAwait(false);             if(result)
            {
                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                CurrentPayload = payLoad;
                CurrentPayload.HasDataObject = true;
                CurrentPayload.DataObject = clientDo;
                CurrentPayload.Subsystem = payLoad.Subsystem;
            }
            else
            {
                string message = isInsert ? "Error during the insert" : "Error during the update";
                SendError(message);
            }
            return payLoad;
        }
    }
}
