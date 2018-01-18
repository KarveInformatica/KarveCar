using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace KarveTest.Mock
{
    /// <summary>
    ///  MockDataServices.
    /// </summary>
    class MockDataServices: IDataServices
    {
        public IVehicleDataServices GetVehicleDataServices()
        {
             return new MockVehicleDataService();
        }

        public ISupplierDataServices GetSupplierDataServices()
        {
             return new MockSupplierDataServices();
        }

        public ISettingsDataService GetSettingsDataService()
        {
             return new MockSettingsDataService();
        }

        public IHelperDataServices GetHelperDataServices()
        {
             return new MockHelperDataServices();
        }

        public ICommissionAgentDataServices GetCommissionAgentDataServices()
        {
            return new MockCommissionAgentDataService();
        }
        public T GetDataService<T>()
        {
            return Activator.CreateInstance<T>();   
        }
    }
}
