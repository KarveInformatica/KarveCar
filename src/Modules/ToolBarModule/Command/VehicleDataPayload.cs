using System;
using System.Threading.Tasks;
using System.Windows;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataObjects;

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
  /// <summary>
  /// 
  /// </summary>
  /// <param name="payLoad"></param>
  /// <returns></returns>
        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            bool result = false;
            bool isInsert = false;
            IVehicleData vehicleData = (IVehicleData)payLoad.DataObject;
            // pre: DataServices and vehicle shall be present.
            if (DataServices == null)
            {
                DataPayLoad nullDataPayLoad = new NullDataPayload();
                return nullDataPayLoad;
            }
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
                {
                    result = await DataServices.GetVehicleDataServices().SaveChangesVehicle(vehicleData).ConfigureAwait(false);
                    break;
                }
                case DataPayLoad.Type.Insert:
                {
                    isInsert = true;
                    result = await DataServices.GetVehicleDataServices().SaveVehicle(vehicleData).ConfigureAwait(true); 
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