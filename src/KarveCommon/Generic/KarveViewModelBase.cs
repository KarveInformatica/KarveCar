using KarveDataServices;
using KarveCommon.Services;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    public abstract class KarveViewModelBase : BindableBase, IEventObserver
    {
        public abstract void incomingPayload(DataPayLoad payload);
        public abstract Task<DataPayLoad> LoadData(IDataServices services, IConfigurationService conf, IDictionary<string, object> data);
    }
}
