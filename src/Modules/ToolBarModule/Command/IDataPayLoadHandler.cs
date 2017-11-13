using KarveCommon.Services;
using KarveDataServices;

namespace ToolBarModule.Command
{
    internal delegate void ErrorExecuting(string errorType);
    internal interface IDataPayLoadHandler
    {
        event ErrorExecuting OnErrorExecuting;
        void ExecutePayload(IDataServices services, IEventManager manager, DataPayLoad payLoad);
      
    }
}