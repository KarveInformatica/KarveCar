using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;

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
            IClientData clientData = payLoad.DataObject as IClientData;
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
            var clientDo = await DataServices.GetSupplierDataServices().GetAsyncSupplierDo(clientData.Value.Numero);
            if (clientDo == null)
            {
                payLoad.PayloadType = DataPayLoad.Type.Insert;
            }
            result = await DataServices.GetClientDataServices().SaveAsync(clientData);
            if(result)
            {

                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                CurrentPayload.HasDataObject = true;
                CurrentPayload.DataObject = clientDo;
                CurrentPayload.Subsystem = payLoad.Subsystem;
                CurrentPayload = payLoad;
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
