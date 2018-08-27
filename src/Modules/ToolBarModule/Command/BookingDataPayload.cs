using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace ToolBarModule.Command
{
    internal class BookingDataPayload : ToolbarDataPayload
    {
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

        }
        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            var result = false;
            if ((payLoad.HasDataObject == false) || (payLoad.DataObject == null))
            {
                throw new ArgumentNullException($"Cannot save a null data payload with invoices");

            }
            var dto = payLoad.DataObject;
            var dataObject = payLoad.DataObject;

            if ((dataObject is IBookingData) || (dataObject is BookingViewObject))
            {
                result = await HandleBookingSaveOrUpdate(payLoad).ConfigureAwait(false);
            }
            else if ((dataObject is KarveDataServices.IReservationRequest) || (dataObject is ReservationRequestViewObject))
            {
                result = await HandleReservationSaveOrUpdate(payLoad).ConfigureAwait(false);
            }
            if (result)
            {
                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                CurrentPayload = new DataPayLoad
                {
                    PayloadType = DataPayLoad.Type.UpdateView,
                    DataObject = dataObject,
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
        private async Task<bool> HandleReservationSaveOrUpdate(DataPayLoad payLoad)
        {
            var reservationService = DataServices.GetReservationRequestDataService();
            var dataObject = payLoad.DataObject;
            var currentWorkingObject = dataObject;
            var result = false;
            if (dataObject is KarveDataServices.IReservationRequest req)
            {
                currentWorkingObject = req.Value;
            }
            if (currentWorkingObject is ReservationRequestViewObject currentDto)
            {
                // hwew we are sure that we are saving.
                var currentValue = await reservationService.GetDoAsync(currentDto.NUMERO).ConfigureAwait(false);
                if ((currentValue == null))
                {
                    payLoad.PayloadType = DataPayLoad.Type.Insert;
                }
                currentValue.Value = currentDto;
                switch (payLoad.PayloadType)
                {
                    case DataPayLoad.Type.Insert:
                    case DataPayLoad.Type.Update:
                    {
                      result = await reservationService.SaveAsync(currentValue).ConfigureAwait(false);
                      break;
                    }
                }
            }
            return result;
        }
        private async Task<bool> HandleBookingSaveOrUpdate(DataPayLoad payLoad)
        {
            await Task.Delay(100);
            return false;
        }
    }
}
