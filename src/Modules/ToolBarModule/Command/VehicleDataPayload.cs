using KarveCommon.Services;
using KarveDataServices;

namespace ToolBarModule.Command
{
    internal class VehicleDataPayload : IDataPayLoadHandler
    {
        public event ErrorExecuting OnErrorExecuting;

        public void ExecutePayload(IDataServices services, IEventManager manager, DataPayLoad payLoad)
        {
            throw new System.NotImplementedException();
        }
    }
}