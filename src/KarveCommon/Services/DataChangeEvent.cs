using Prism.Events;

namespace KarveCommon.Services
{
    public class DataChangeEvent: PubSubEvent<DataPayLoad>
    {
      
        public DataChangeEvent()
        {

        }
    }
}
