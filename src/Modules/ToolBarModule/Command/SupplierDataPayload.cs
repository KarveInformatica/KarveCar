using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;
using NLog;
using System.Collections.Generic;

namespace ToolBarModule.Command
{
    internal class SupplierDataPayload : ToolbarDataPayload
    {
        private ISupplierDataServices _dataServices = null;
        private DataPayLoad _payload;
        private INotifyTaskCompletion<DataPayLoad> _initializationNotifier;
        public new event ErrorExecuting OnErrorExecuting;

        private Logger log = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// This execute the payload and notify the event manager
        /// </summary>
        /// <param name="services">Services to be used</param>
        /// <param name="manager">Manager to be notified</param>
        /// <param name="payLoad">Payload to execute.</param>
        public override void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad)
        {

            _dataServices = services.GetSupplierDataServices();
            _payload = payLoad;
            EventManager = manager;
            DataServices = services;
            _initializationNotifier = NotifyTaskCompletion.Create<DataPayLoad>(HandleSaveOrUpdate(_payload), ExecutedPayloadHandler);


        }

        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            bool result = false;
            bool isInsert = false;
            ISupplierData supplierData = payLoad.DataObject as ISupplierData;
            if (supplierData == null)
            {
                string message = (payLoad.PayloadType == DataPayLoad.Type.Insert) ? "Error during the insert" : "Error during the update";
                OnErrorExecuting?.Invoke(message);
                return new DataPayLoad();
            }
            if (DataServices == null)
            {
                DataPayLoad nullDataPayLoad = new NullDataPayload();
                return nullDataPayLoad;
            }
            var checkedSupplierData = await DataServices.GetSupplierDataServices().GetAsyncSupplierDo(supplierData.Value.NUM_PROVEE);
            if (checkedSupplierData.Value == null)
            {
                payLoad.PayloadType = DataPayLoad.Type.Insert;
            }
            switch (payLoad.PayloadType)
            {
                case DataPayLoad.Type.Update:
                    {
                        result = await DataServices.GetSupplierDataServices().SaveChanges(supplierData)
                            .ConfigureAwait(false);
                        break;
                    }
                case DataPayLoad.Type.Insert:
                    {
                        isInsert = true;
                        result = await DataServices.GetSupplierDataServices().Save(supplierData).ConfigureAwait(true);
                        break;
                    }
                case DataPayLoad.Type.UpdateInsertGrid:
                    {


                        result = true;
                        if (payLoad.RelatedObject is IEnumerable<BranchesViewObject>)
                        {
                            await UpdateGridAsync<BranchesViewObject, ProDelega>(payLoad); 
                        }
                        else
                        {
                            await UpdateGridAsync<ContactsViewObject, ProContactos>(payLoad); 
                        }
                        break;
                    }
                case DataPayLoad.Type.DeleteGrid:
                    {
                        if (payLoad.RelatedObject is IEnumerable<BranchesViewObject> branches)
                        {
                            foreach (var branch in branches)
                            {
                                if (branch.IsDeleted)
                                {
                                    // a delete bulk.
                                    result = await DataServices.GetHelperDataServices().ExecuteAsyncDelete<BranchesViewObject, ProDelega>(branch);
                                }
                            }
                        }
                        ContactsViewObject contactsViewObject = payLoad.RelatedObject as ContactsViewObject;
                        if (contactsViewObject != null)
                        {
                            result = await DataServices.GetHelperDataServices().ExecuteAsyncDelete<ContactsViewObject, ProContactos>(contactsViewObject);
                        }
                        break;
                    }

            }
            if (result)
            {
                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                CurrentPayload = new DataPayLoad();
                CurrentPayload.PayloadType = DataPayLoad.Type.UpdateView;
                CurrentPayload.DataObject = supplierData;
                CurrentPayload.Sender = ToolBarModule.NAME;
                CurrentPayload.HasDataObject = true;
                CurrentPayload.Subsystem = payLoad.Subsystem;
            }
            else
            {
                string message = isInsert ? "Error during the insert" : "Error during the update";
                OnErrorExecuting?.Invoke(message);
            }
            return payLoad;
        }
    }
}
