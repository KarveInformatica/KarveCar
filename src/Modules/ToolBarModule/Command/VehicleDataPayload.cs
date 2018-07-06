using System;
using System.Threading.Tasks;
using System.Windows;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveCommonInterfaces;

namespace ToolBarModule.Command
{
    internal class VehicleDataPayload : ToolbarDataPayload
    {
        private IVehicleDataServices _vehicleDataServices;
        private DataPayLoad _payload;
        private INotifyTaskCompletion<DataPayLoad> _initializationNotifier;
       


        public VehicleDataPayload(): base()
        {
            
        }
        public VehicleDataPayload(IDialogService dialogService) : base(dialogService)
        {

        }
  /// <summary>
  /// 
  /// </summary>
  /// <param name="payLoad"></param>
  /// <returns></returns>
        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            bool result = false;
            bool isInsert = payLoad.PayloadType == DataPayLoad.Type.Insert;
            IVehicleData vehicleData = (IVehicleData)payLoad.DataObject;
            // pre: DataServices and vehicle shall be present.
            if (DataServices == null)
            {
                DataPayLoad nullDataPayLoad = new NullDataPayload();
                return nullDataPayLoad;
            }
            _vehicleDataServices = DataServices.GetVehicleDataServices();
            if (vehicleData == null)
            {
                string message = (payLoad.PayloadType == DataPayLoad.Type.Insert) ? "Error during the insert" : "Error during the update";
                ShowErrorMessage(message);
               // OnErrorExecuting?.Invoke(message);
            }
            // FIXME: unify the update and the insert.
            switch (payLoad.PayloadType)
            {
                case DataPayLoad.Type.Update:
                case DataPayLoad.Type.Insert:
                {
                    result = await _vehicleDataServices.SaveAsync(vehicleData).ConfigureAwait(false);
                    break;
                }
            }
            if (result)
            {
               
                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                CurrentPayload = payLoad;

            }
            else
            {
                string message = isInsert ? "Error during the insert" : "Error during the update";
                ShowErrorMessage(message);
              //  OnErrorExecuting?.Invoke(message);
            }
            return payLoad;

        }
        /// <summary>
        ///  Save or execute a payload
        /// </summary>
        /// <param name="services"></param>
        /// <param name="manager"></param>
        /// <param name="payLoad"></param>
        public override void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad)
        {

            _vehicleDataServices = services.GetVehicleDataServices();
            _payload = payLoad;
            EventManager = manager;
            DataServices = services;
            _initializationNotifier = NotifyTaskCompletion.Create<DataPayLoad>(HandleSaveOrUpdate(payLoad), ExecutedPayloadHandler);

        }
    }
}