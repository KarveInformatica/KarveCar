using System;
using KarveDataServices;
using KarveCommon.Services;
using MongoDB.Driver;

namespace DataAccessLayer.MongoDB
{
    /// <summary>
    ///  This is data service for the MongoBD.
    /// </summary>
    public class MongoDataServiceImplementation : IDataServices
    {
        private IMongoClient _executor = null;
        private string _connectionString;
        public MongoDataServiceImplementation(IConfigurationService service) 
        {
            _connectionString = service.ConnectionString;
            _executor = new MongoClient(_connectionString);

        }
        /// <summary>
        ///  Access to the mongo client data service interface
        /// </summary>
        /// <returns>client data service interface</returns>
        public IClientDataServices GetClientDataServices()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  Access to the mongo client broker data service interface
        /// </summary>
        /// <returns>broker client data service interface</returns>
        public ICommissionAgentDataServices GetCommissionAgentDataServices()
        {
            throw new NotImplementedException();
        }

        public ICompanyDataServices GetCompanyDataServices()
        {
            throw new NotImplementedException();
        }

        public IContractDataServices GetContractDataServices()
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

        public IInvoiceDataServices GetInvoiceDataServices()
        {
            throw new NotImplementedException();
        }

        public IOfficeDataServices GetOfficeDataServices()
        {
            throw new NotImplementedException();
        }

        public ISettingsDataServices GetSettingsDataService()
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

        public void Reconfigure(string connectionString)
        {
            _connectionString = connectionString;
            _executor = new MongoClient(_connectionString);
        }
    }

}