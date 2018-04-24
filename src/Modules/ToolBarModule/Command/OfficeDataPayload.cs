using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveCommon.Generic;
using KarveDataServices.DataTransferObject;
using System.Diagnostics.Contracts;
using KarveDataServices.DataObjects;

namespace ToolBarModule.Command
{
    /// <summary>
    ///  This class has the single responsabilty to save an office.
    /// </summary>
    internal class OfficeDataPayload : ToolbarDataPayload
    {
        private IOfficeDataServices _officeDataServices;
        private DataPayLoad _payload;
        public override void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad)
        {
            _officeDataServices = services.GetOfficeDataServices();
            _payload = payLoad;
            DataServices = services;
            EventManager = manager;
            ToolbarInitializationNotifier = NotifyTaskCompletion.Create<DataPayLoad>(HandleSaveOrUpdate(_payload), ExecutedPayloadHandler);
        }
        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            Contract.Requires(payLoad != null, "The payload at company data shall be not null");
            Contract.Requires(payLoad.DataObject != null, "Payload shall have data object");
            if (payLoad.DataObject is OfficeDtos dto)
            {
                IOfficeData data = _officeDataServices.GetNewOfficeDo(dto.Codigo);
                data.Value = dto;
                bool result = false;
                try
                {
                   result = await _officeDataServices.SaveAsync(data).ConfigureAwait(false);
                }
                catch (DataLayerException e)
                {
                    throw new DataLayerException("Error during saving", e);
                }
               

            // FIXME: where it is used current payload. shall enforce dry.
                if (result)
                {
                    payLoad.Sender = ToolBarModule.NAME;
                    payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                    // see if currentPayload make sense.
                    CurrentPayload = new DataPayLoad
                    {
                        PayloadType = DataPayLoad.Type.UpdateView,
                        Sender = ToolBarModule.NAME,
                        HasDataObject = true,
                        Subsystem = payLoad.Subsystem,
                        DataObject = data
                    };
                }
            }

            Contract.Ensures(payLoad != null);
            return payLoad;
        }
    }
}