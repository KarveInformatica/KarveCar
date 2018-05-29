using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;
using System.Collections.Generic;

namespace ToolBarModule.Command
{


    /*
     * This class is the invoice data payload.The payload is useful for saving data that it is coming from the toolbar.
     */
    internal class InvoiceDataPayload : ToolbarDataPayload
    {
        private IInvoiceDataServices _invoiceDataServices;


        /// <summary>
        /// Execute the payload when the user press to save and it notifies the 
        /// </summary>
        /// <param name="services">Data services are used to store the data.</param>
        /// <param name="manager">Event manager is used to notify the caller and refresh data.</param>
        /// <param name="payLoad">Payload to be updated</param>
        public override void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad)
        {
            CurrentEventManager = manager;
            CurrentPayload = payLoad;
            DataServices = services ?? throw new ArgumentNullException($"Cannot save without DataServices");
            ToolbarInitializationNotifier =
                NotifyTaskCompletion.Create<DataPayLoad>(HandleSaveOrUpdate(payLoad), ExecutedPayloadHandler);
            _invoiceDataServices = services.GetInvoiceDataServices();
        }

        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            var result = false;
            if ((payLoad.HasDataObject == false) || (payLoad.DataObject == null))
            {
                throw new ArgumentNullException($"Cannot save a null data payload with invoices");

            }

            var dataObject = payLoad.DataObject;
            if (dataObject is IInvoiceData)
            {
                var dataInvoice = dataObject as IInvoiceData;
                dataObject = dataInvoice.Value;
            }
            if (!(dataObject is InvoiceDto invoiceData))
            {
                throw new ArgumentNullException($"Cannot save an invalid type data payload with invoices");
            }

            // here i simply dont trust the incoming payload.
            var invoiceDs = DataServices.GetInvoiceDataServices();
            var currentInvoice = await invoiceDs.GetInvoiceDoAsync(invoiceData.NUMERO_FAC);
            if ((currentInvoice == null) || (currentInvoice is NullInvoice))
            {
                payLoad.PayloadType = DataPayLoad.Type.Insert;
            }

            switch (payLoad.PayloadType)
            {
                case DataPayLoad.Type.Insert:
                case DataPayLoad.Type.Update:
                {
                    if (currentInvoice != null)
                    {
                        currentInvoice.Value = invoiceData;
                            if ((currentInvoice.InvoiceItems != null) && (currentInvoice.InvoiceItems.Any()))
                            {
                                currentInvoice.InvoiceItems = invoiceData.InvoiceItems != null ?     currentInvoice.InvoiceItems.Union(invoiceData.InvoiceItems) : invoiceData.InvoiceItems;

                                invoiceData.InvoiceItems = currentInvoice.InvoiceItems;
                            }
                            result = await invoiceDs.SaveAsync(currentInvoice).ConfigureAwait(false);
                    }

                    break;
                }
                case DataPayLoad.Type.UpdateInsertGrid:
                    {
                        if (payLoad.HasRelatedObject)
                        {
                            var relatedObject = payLoad.RelatedObject as InvoiceSummaryDto;
                            if (currentInvoice.InvoiceItems == null)
                            {
                                currentInvoice.InvoiceItems = new List<InvoiceSummaryDto>();
                            }
                            if (relatedObject != null)
                            {
                                var list = new List<InvoiceSummaryDto>() { relatedObject };
                                currentInvoice.InvoiceItems = currentInvoice.InvoiceItems.Union(list);
                            }
                            result = await invoiceDs.SaveAsync(currentInvoice).ConfigureAwait(false);
                        }
                        break;
                    }
               
            }

            if (result)
            {
                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                CurrentPayload = new DataPayLoad
                {
                    PayloadType = DataPayLoad.Type.UpdateView,
                    DataObject = invoiceData,
                    Sender = ToolBarModule.NAME,
                    HasDataObject = true,
                    Subsystem = payLoad.Subsystem
                };
            }
            else
            {
                throw new DataLayerException("Error during updating/inserting data");
            }


            return payLoad;
        }
    }
}