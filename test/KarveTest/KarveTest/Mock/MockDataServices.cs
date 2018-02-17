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
    public class MockDataServices: IDataServices
    {
        public IVehicleDataServices GetVehicleDataServices()
        {
             return new MockVehicleDataService();
        }

        public IClientDataServices GetClientDataServices()
        {
            throw new NotImplementedException();
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

        public IAssistDataService GetAssistDataService()
        {
            throw new NotImplementedException();
        }

        public IOfficeDataServices GetOfficeDataServices()
        {
            throw new NotImplementedException();
        }

        public ICompanyDataService GetCompanyDataServices()
        {
            throw new NotImplementedException();
        }
    }
}
