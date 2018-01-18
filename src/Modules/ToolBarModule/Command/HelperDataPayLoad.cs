using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using KarveCommon.Generic;
using System;

namespace ToolBarModule.Command
{
    internal class HelperDataPayLoad : ToolbarDataPayload
    {
        private IHelperDataServices _helperDataServices;
        public override void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad)
        {
            DataServices = services;
            EventManager = manager;
            _helperDataServices = services.GetHelperDataServices();
            CurrentPayload = payLoad;
            ToolbarInitializationNotifier = NotifyTaskCompletion.Create<DataPayLoad>(HandleSaveOrUpdate(payLoad), ExecutedPayloadHandler);
        }
        /// <summary>
        ///  In this case we dont know the type so the resposability will be of the view model.
        /// </summary>
        /// <param name="payLoad"></param>
        /// <returns></returns>
        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            var dataObject = payLoad.DataObject;
            Type type = dataObject.GetType();
            await Task.Delay(1);
            return payLoad;
        }
    }
}