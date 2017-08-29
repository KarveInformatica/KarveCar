using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
