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
        /// <summary>
        ///  Mock Vehicles dataservices.
        /// </summary>
        /// <returns></returns>
        public IVehicleDataServices GetVehicleDataServices()
        {
             return new MockVehicleDataService();
        }
        /// <summary>
        ///  Mock client data services
        /// </summary>
        /// <returns></returns>
        public IClientDataServices GetClientDataServices()
        {
            throw new MockClientDataServices();
        }
        /// <summary>
        ///  Mock supplier data services
        /// </summary>
        /// <returns></returns>
        public ISupplierDataServices GetSupplierDataServices()
        {
             return new MockSupplierDataServices();
        }
        /// <summary>
        ///  Mock setting data services
        /// </summary>
        /// <returns></returns>
        public ISettingsDataService GetSettingsDataService()
        {
             return new MockSettingsDataService();
        }
        /// <summary>
        ///  Mock helper data services
        /// </summary>
        /// <returns></returns>
        public IHelperDataServices GetHelperDataServices()
        {
             return new MockHelperDataServices();
        }
        /// <summary>
        ///  Mock commission agent data services.
        /// </summary>
        /// <returns></returns>
        public ICommissionAgentDataServices GetCommissionAgentDataServices()
        {
            return new MockCommissionAgentDataService();
        }
        /// <summary>
        /// Mock data services
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetDataService<T>()
        {
            return Activator.CreateInstance<T>();   
        }
        /// <summary>
        ///  Get assist data services
        /// </summary>
        /// <returns></returns>
        public IAssistDataService GetAssistDataService()
        {
            throw new MockAssistDataServices();
        }
        /// <summary>
        ///  Get office data services
        /// </summary>
        /// <returns></returns>
        public IOfficeDataServices GetOfficeDataServices()
        {
            return new MockOfficeDataServices();
        }
        /// <summary>
        ///  Company data services.
        /// </summary>
        /// <returns></returns>
        public ICompanyDataService GetCompanyDataServices()
        {
            throw new MockCompanyDataServices();
        }
        /// <summary>
        /// </summary>
        /// <param name="connectionString"></param>
        public void Reconfigure(string connectionString)
        {
        }
    }
}
