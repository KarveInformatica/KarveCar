using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;

namespace DataAccessLayer.MongoDB
{
    /// <summary>
    ///  Mongo position implementation.
    /// </summary>
    class MongoDbImplementation:IDataServices
    {

        public MongoDbImplementation()
        {
        }
        public IVehicleDataServices GetVehicleDataServices()
        {
            return new MongoVehicleDataAccessLayer();
        }
        public IClientDataServices GetClientDataServices()
        {
            return new MongoClientDataAccessLayer();
        }

        public ISupplierDataServices GetSupplierDataServices()
        {
           return new MongoSupplierDataAccessLayer();
        }

        public ISettingsDataServices GetSettingsDataService()
        {
            return new MongoSettingsDataAccessLayer();
        }

        public IHelperDataServices GetHelperDataServices()
        {
            return new MongoHelperDataAccessLayer();
        }

        public ICommissionAgentDataServices GetCommissionAgentDataServices()
        {
            return new MongoCommissionAgentDataAccessLayer();
        }

        public IOfficeDataServices GetOfficeDataServices()
        {
            return new MongoOfficeDataAccessLayer();
        }

        public ICompanyDataServices GetCompanyDataServices()
        {
            return new MongoCompanyDataAccessLayer();
        }

        public IContractDataServices GetContractDataServices()
        {
            return new MongoContractDataAccessLayer();
        }

        public IInvoiceDataServices GetInvoiceDataServices()
        {
            return new MongoInvoiceDataAccessLayer();
        }

        public T GetDataService<T>()
        {
            return Activator.CreateInstance<T>();
        }

        public void Reconfigure(string connectionString)
        {
        }

        public IAssistDataService GetAssistDataServices()
        {
            return new MongoAssistDataAccessLayer();
        }

        public IBookingDataService GetBookingDataService()
        {
            throw new NotImplementedException();
        }

        public IFareDataServices GetFareDataServices()
        {
            throw new NotImplementedException();
        }

        public IReservationRequestDataService GetReservationRequestDataService()
        {
            throw new NotImplementedException();
        }

        public IBudgetDataService GetBudgetDataServices()
        {
            throw new NotImplementedException();
        }
    }
}
