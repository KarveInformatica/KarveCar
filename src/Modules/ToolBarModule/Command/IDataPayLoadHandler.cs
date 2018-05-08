using KarveCommon.Services;
using KarveDataServices;

namespace ToolBarModule.Command
{
    public delegate void ErrorExecuting(string errorType);
    internal interface IDataPayLoadHandler
    {
        event ErrorExecuting OnErrorExecuting;
        void ExecutePayload(IDataServices services, IEventManager manager, ref DataPayLoad payLoad);
      
    }
}