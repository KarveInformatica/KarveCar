using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace KarveTest.DAL.Mock
{
    class MockDataServices : IDataServices
    {
        public ICommissionAgentDataServices GetCommissionAgentDataServices()
        {
            throw new NotImplementedException();
        }

        public T GetDataService<T>()
        {
            throw new NotImplementedException();
        }

        public IHelperDataServices GetHelperDataServices()
        {
            throw new NotImplementedException();
        }

        public ISettingsDataService GetSettingsDataService()
        {
            throw new NotImplementedException();
        }

        public ISupplierDataServices GetSupplierDataServices()
        {
            throw new NotImplementedException();
        }

        public IVehicleDataServices GetVehicleDataServices()
        {
            throw new NotImplementedException();
        }
    }
}
