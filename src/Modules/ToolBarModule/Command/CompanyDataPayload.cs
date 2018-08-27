using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using NLog;
using KarveDataServices.ViewObjects;
using System.Diagnostics.Contracts;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;

namespace ToolBarModule.Command
{
    internal class CompanyDataPayload : ToolbarDataPayload
    {
       
        private ICompanyDataServices _companyDataServices;
        private Logger currentLog = LogManager.GetCurrentClassLogger();
        public override void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad)
        {
            _companyDataServices = services.GetCompanyDataServices();
            ToolbarInitializationNotifier = NotifyTaskCompletion.Create<DataPayLoad>(HandleSaveOrUpdate(payLoad), ExecutedPayloadHandler);
        }

        protected override async Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            Contract.Requires(payLoad != null, "The payload at company data shall be not null");
            Contract.Requires(payLoad.DataObject != null, "Payload shall have data object");
            CompanyViewObject viewObject = payLoad.DataObject as CompanyViewObject;
            ICompanyData data = _companyDataServices.GetNewCompanyDo(viewObject.Code);
            data.Value = viewObject;
            bool result = await _companyDataServices.SaveAsync(data);
            // FIXME: where it is used current payload. shall enforce dry.
            if (result)
            {
                payLoad.Sender = ToolBarModule.NAME;
                payLoad.PayloadType = DataPayLoad.Type.UpdateView;
                CurrentPayload = new DataPayLoad();
                CurrentPayload.PayloadType = DataPayLoad.Type.UpdateView;
                CurrentPayload.Sender = ToolBarModule.NAME;
                CurrentPayload.HasDataObject = true;
                CurrentPayload.Subsystem = payLoad.Subsystem;
                CurrentPayload.DataObject = data;
            }
            return payLoad;
        }
    }
}