using System;
using System.Data;
using DataAccessLayer.MongoDB;
using KarveCommon.Services;
using KarveDataServices;

namespace DataAccessLayer
{
    /// <summary>
    /// Implementation of the the IDataService interface to provide the stairway pattern.
    /// Stairway pattern is against the entourage pattern. 
    /// The Interface assembly shall be sepatated from the implementation.
    /// </summary>
    public class DataServiceImplementation : IDataServices
    {
        // private supplier services
        private  ISupplierDataServices _supplierDataServices;
        // private helper data services.
        private  IHelperDataServices _helperDataServices;
        // private commission agent access layer.
        private  ICommissionAgentDataServices _commissionAgentDataServices;
        // private setting data servive.
        private  ISettingsDataServices _settingsDataService;
        /// <summary>
        /// Vehicle data services. 
        /// </summary>
        private IVehicleDataServices _vehicleDataServices;

        /// <summary>
        ///  Client data service
        /// </summary>
        private IClientDataServices _clientDataServices;
       
        /// <summary>
        ///  Data management for the offices
        /// </summary>
        private IOfficeDataServices _officeDataService;

        /// <summary>
        ///  Data management for the company
        /// </summary>
        private ICompanyDataServices _companyDataService;

        /// <summary>
        ///  Data service for the contracts.
        /// </summary>
        private IContractDataServices _contractDataService;
        /// <summary>
        ///  Data service for the contracts.
        /// </summary>
        private IInvoiceDataServices _invoiceDataService;
        /// <summary>
        ///  SqlExecutor.
        /// </summary>
        private ISqlExecutor _executor;
        /// <summary>
        ///  This is a data service for handling the assist
        /// </summary>
        private IAssistDataService _assistDataService;
        /// <summary>
        ///  This is a data service for handling the booking stuff.
        /// </summary>
        private IBookingDataService _bookingDataService;
        /// <summary>
        /// DataService Implementation
        /// </summary>
        /// <param name="sqlExecutor">Command executor for sql</param>
        
        public DataServiceImplementation(ISqlExecutor sqlExecutor)
        {
            InitServices(sqlExecutor);         
        }

        private void TestConnection(ISqlExecutor sqlExecutor, string connectionValue)
        {
            // ok now we try to connect 
            try
            {
                using (var dbConn = sqlExecutor.OpenNewDbConnection())
                {

                    if (dbConn == null)
                    {
                        throw new System.ArgumentException(
                            "Invalid connection string with value " + connectionValue);
                    }

                    if (dbConn.State != ConnectionState.Open)
                    {

                        throw new System.ArgumentException(
                            "Invalid connection string with value " + connectionValue);
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new System.ArgumentException("Invalid connection string with value " + connectionValue, e);
            }

        }
        /// <summary>
        ///  Reitinialize the sql executor and all the services provided by this interface with 
        ///  a new connection string.
        /// </summary>
        /// <param name="sqlExecutor">Executor to be used.</param>
        /// <param name="connectionValue">Connection value.</param>
        private void InitServices(ISqlExecutor sqlExecutor, string connectionValue = "")
        {

            if (!string.IsNullOrEmpty(connectionValue))
            {
                sqlExecutor.ConnectionString = connectionValue;
                TestConnection(sqlExecutor, connectionValue);
            }
            _executor = sqlExecutor;
            _supplierDataServices = new SupplierDataAccessLayer(sqlExecutor);
            _helperDataServices = new HelperDataAccessLayer(sqlExecutor);
            _commissionAgentDataServices = new CommissionAgentAccessLayer(sqlExecutor);
            _vehicleDataServices = new VehiclesDataAccessLayer(sqlExecutor);
            _settingsDataService = new SettingsDataService(sqlExecutor);
            _clientDataServices = new ClientDataAccessLayer(sqlExecutor);
            _officeDataService = new OfficeDataService(sqlExecutor);
            _companyDataService = new CompanyDataServices(sqlExecutor);
            _contractDataService = new ContractDataServices(sqlExecutor);
            _invoiceDataService = new InvoiceDataServices(sqlExecutor);
            _assistDataService = new AssistDataService(this);
            _bookingDataService = new BookingDataAccessLayer(sqlExecutor);

        }
        /// <summary>
        ///  Get the vehicles data services that represent all vehicles.
        /// </summary>
        /// <returns></returns>
        public IVehicleDataServices GetVehicleDataServices()
        {
            return _vehicleDataServices;
        }
        /// <summary>
        ///  Get the supplier data services. All data services that are enabled in the suppliers.
        /// </summary>
        /// <returns></returns>
        public ISupplierDataServices GetSupplierDataServices()
        {
           return _supplierDataServices;
        }
        /// <summary>
        ///  Get the assistant data services. All data services that are enabled in the helpers
        /// </summary>
        /// <returns>Return the assistant (auxliares in spanish) services</returns>
        public IHelperDataServices GetHelperDataServices()
        {
            return _helperDataServices;
        }
        /// <summary>
        ///  Get the commission agent services. All commission agent services are enabled.
        /// </summary>
        /// <returns>Return the commission agent services interface</returns>
        public ICommissionAgentDataServices GetCommissionAgentDataServices()
        {
           return _commissionAgentDataServices;
        }
        /// <summary>
        ///  Get settings data services.
        /// </summary>
        /// <returns>Return the setting for the data services.</returns>
        public ISettingsDataServices GetSettingsDataService()
        {
            return _settingsDataService;
        }
        /// <summary>
        ///  Get a generic data service.
        /// </summary>
        /// <typeparam name="T">Type of the service</typeparam>
        /// <returns></returns>
        public T GetDataService<T>()
        {
            var value = (T)Activator.CreateInstance(typeof(T), new object[] { _executor });
            return value;
        }
        /// <summary>
        ///  Get the client data services. All the services needed to manage the client operations.
        /// </summary>
        /// <returns></returns>
        public IClientDataServices GetClientDataServices()
        {
            return _clientDataServices;
        }
     
        /// <summary>
        ///  Office data services. All the services needed to manage the office operations.
        /// </summary>
        /// <returns></returns>
        public IOfficeDataServices GetOfficeDataServices()
        {
            return _officeDataService;
        }
        /// <summary>
        ///  Company data services. All the services neede to manage the company operations.
        /// </summary>
        /// <returns></returns>
        public ICompanyDataServices GetCompanyDataServices()
        {
            return _companyDataService;
        }

        /// <summary>
        ///  Initialize or Reinitialize the ADO.NET with a new connection string
        /// </summary>
        /// <param name="connectionString">ADO.NET connection string</param>
        public void Reconfigure(string connectionString)
        {
            InitServices(_executor, connectionString);
        }
        /// <summary>
        ///  Contract data services. All the services needed to manage the contract operations.
        /// </summary>
        /// <returns>Return a contract</returns>
        public IContractDataServices GetContractDataServices()
        {
           return _contractDataService;
        }
        /// <summary>
        ///  Invoice data services. All the services needed to manage the invoice.
        /// </summary>
        /// <returns></returns>
        public IInvoiceDataServices GetInvoiceDataServices()
        {
            return _invoiceDataService;
        }
        /// <summary>
        ///  Assist data services. All the services needed to manage the assist.
        /// </summary>
        /// <returns></returns>
        public IAssistDataService GetAssistDataServices()
        {
            return _assistDataService;
        }
        /// <summary>
        ///  Booking data service. All services needed to manage a booking.
        /// </summary>
        /// <returns></returns>
        public IBookingDataService GetBookingDataService()
        {
            return _bookingDataService;
        }
    }
}
