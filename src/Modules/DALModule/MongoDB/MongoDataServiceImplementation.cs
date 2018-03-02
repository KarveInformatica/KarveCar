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
            _connectionString = service.GetConnectionString();
            _executor = new MongoClient(_connectionString);

        }

        public IVehicleDataServices GetVehicleDataServices()
        {
            return new VehicleMongoDBServices(_executor);
        }

        public IClientDataServices GetClientDataServices()
        {
            return new ClientMongoDBServices(_executor);
           
        }

        public ISupplierDataServices GetSupplierDataServices()
        {
            return new SupplierMongoDbServices(_executor);
           
        }

        public ISettingsDataService GetSettingsDataService()
        {
            return new SettingsMongoDBServices(_executor);
          
        }

        public IHelperDataServices GetHelperDataServices()
        {
            return new HelperMongoDBServices(_executor);
        }

        public ICommissionAgentDataServices GetCommissionAgentDataServices()
        {
            return new CommisionAgentMongoDBServices();
        }

        public T GetDataService<T>()
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

        public void Reconfigure(string connectionString)
        {
            _connectionString = connectionString;
            _executor = new MongoClient(_connectionString);
        }
    }

}