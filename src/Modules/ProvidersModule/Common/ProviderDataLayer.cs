using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;

namespace ProvidersModule.Common
{
    class ProviderDataLayer: IAsyncInitialization
    {
        private IDataServices _dataServices;

        public ProviderDataLayer(IDataServices dataServices)
        {
            _dataServices = dataServices;
            Initialization = InitializeAsync();
        }

        public Task<DataSet> Initialization { get; private set; }

        private async Task<DataSet> InitializeAsync()
        { 
            ISupplierDataServices supplier = _dataServices.GetSupplierDataServices();
            DataSet set = await supplier.GetAsyncAllSupplierSummary();
            return set;
        }
    }
}
