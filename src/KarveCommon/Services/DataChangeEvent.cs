using Prism.Events;

namespace KarveCommon.Services
{
    class DataChangeEvent: PubSubEvent<DataPayLoad>
    {
      
        public DataChangeEvent()
        {

        }
    }
}
