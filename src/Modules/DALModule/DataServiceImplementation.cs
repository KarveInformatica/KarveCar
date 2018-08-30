using System;
using System.Data;
using KarveCommon.Services;
using KarveDataServices;

namespace DataAccessLayer
{
    /// <summary>
    /// Implementation of the the IDataService interface to provide the stairway pattern.
    /// Stairway pattern is against the entourage pattern. 
    /// The Interface assembly shall be sepatated from the implementation.
    /* When your implementation project depends only on packages that only has interfaces then you can avoid Entourage
     * anti-pattern.
     * Of course that requires that you have or are able to use interface-only packages. Also, the packages should not depend on other packages. 
     * Well, it's not possible all the time, but it would be good if those packages do not contain implementation.  
     * Of course stairway pattern is useful only when you use abstraction(interfaces or abstract classes) and
     * dependency inversion. So, with Google Drive example, you could create a project for Google Drive which only
     * contains interfaces.Then you would create an implementation project which will depend on your Google Drive
     * interface project and Google Drive packages.When you need Google Drive in your project, you just depend on your
     * Google Drive interface project. No Entourage! Then in the application, depend on the Google Drive implementation
     * project and compose everything together.
     */
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
        ///  Data services for managing the fares.
        /// </summary>
        private IFareDataServices _fareDataService;
        /// <summary>
        /// Reservation request data service.
        /// </summary>
        private IReservationRequestDataService _reservationRequestDataService;

        /// <summary>
        ///  Budget rqesut data service.
        /// </summary>
        private IBudgetDataService _budgetDataService;
        private BookingIncidentDataAccessLayer _bookingIncidentDataService;
        private UserDataService _userDataService;

        /// <summary>
        /// DataService Implementation
        /// </summary>
        /// <param name="sqlExecutor">Command executor for sql</param>

        public DataServiceImplementation(ISqlExecutor sqlExecutor)
        {
            InitServices(sqlExecutor);         
        }

        /// <summary>
        ///  This test the connection fro the page.
        /// </summary>
        /// <param name="sqlExecutor">Executor instance for the page</param>
        /// <param name="connectionValue">Connection value</param>
        private void TestConnection(ISqlExecutor sqlExecutor, string connectionValue)
        {
            // ok now we try to connect 
            try
            {
                using (var connection = sqlExecutor.OpenNewDbConnection())
                {

                    if (connection == null)
                    {
                        throw new System.ArgumentException(
                            "Invalid connection string with value " + connectionValue);
                    }

                    if (connection.State != ConnectionState.Open)
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
            _bookingDataService = new BookingDataAccessLayer(sqlExecutor, null);
            _fareDataService = new FareDataServices(sqlExecutor);
            _reservationRequestDataService = new ReservationRequestDataAccessLayer(sqlExecutor);
            _budgetDataService = new BudgetDataAccessLayer(sqlExecutor);
            _bookingIncidentDataService = new BookingIncidentDataAccessLayer(sqlExecutor);
            _userDataService = new UserDataService(sqlExecutor);

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
            // this is  pretty intesting that it is eveytime a new one.

            _assistDataService = new AssistDataService(this);
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
        /// <summary>
        ///  It returns the fare data service 
        /// </summary>
        /// <returns></returns>
        public IFareDataServices GetFareDataServices()
        {
            return _fareDataService;
        }
        /// <summary>
        ///  It returns the reservation request data service
        /// </summary>
        /// <returns></returns>
        public IReservationRequestDataService GetReservationRequestDataService()

        {
            return _reservationRequestDataService;
        }
        /// <summary>
        ///  It returns the budget data service.
        /// </summary>
        /// <returns></returns>
        public IBudgetDataService GetBudgetDataServices()
        {
            return _budgetDataService;
        }

        /// <summary>
        ///  Booking incident data service
        /// </summary>
        /// <returns>The booking incident data service</returns>
        public IBookingIncidentDataService GetBookingIncidentDataService()
        {
            return _bookingIncidentDataService;
        }
        /// <summary>
        ///  User data service to retrieve the data.
        /// </summary>
        /// <returns>The user data service.</returns>
        public IUserDataService GetUserDataService()
        {
            return _userDataService;
        }

    }
}
