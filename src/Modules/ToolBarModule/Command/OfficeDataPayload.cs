using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;

namespace ToolBarModule.Command
{
    internal class OfficeDataPayload : ToolbarDataPayload
    {
        public override void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad)
        {
            throw new System.NotImplementedException();
        }

        protected override Task<DataPayLoad> HandleSaveOrUpdate(DataPayLoad payLoad)
        {
            throw new System.NotImplementedException();
        }
    }
}