using System;
using KarveDataServices;
namespace DataAccessLayer.MongoDB
{
    /// <summary>
    ///  This is data service for the MongoBD.
    /// </summary>
    public class MongoDataServiceImplementation : IDataServices
    {
        private INoSqlExecutor _executor = null;

        public MongoDataServiceImplementation() 
        {
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

        public IAssistDataService GetAssistDataService()
        {
            return new AssistMongoDBServices(_executor);
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