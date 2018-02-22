using System;
using KarveCommon.Services;
using KarveDataServices;

// TODO using generic for setting all this.
namespace DataAccessLayer
{
    /// <summary>
    /// Implementation of the the IDataService interface to provide the stairway pattern.
    /// Stairway pattern is against the entourage pattern. 
    /// The Interface assembly shall be sepatated from the implementation. This allow to avoid the infernal dll hell,
    /// and provide a way to load different assemblies following a give implementation.
    /// </summary>
    public class DataServiceImplementation : IDataServices
    {
        // private supplier services
        private readonly ISupplierDataServices _supplierDataServices;
        // private helper data services.
        private readonly IHelperDataServices _helperDataServices;
        // private commission agent access layer.
        private readonly ICommissionAgentDataServices _commissionAgentDataServices;
        // private setting data servive.

        private readonly ISettingsDataService _settingsDataService;

        
        /// <summary>
        /// Vehicle data services. 
        /// </summary>
        private readonly IVehicleDataServices _vehicleDataServices;

        /// <summary>
        ///  Client data service
        /// </summary>
        private readonly IClientDataServices _clientDataServices;
        /// <summary>
        ///  Assist data service.
        /// </summary>
        private readonly IAssistDataService _assistDataService;

        /// <summary>
        ///  Data management for the offices
        /// </summary>
        private readonly IOfficeDataServices _officeDataService;

        /// <summary>
        ///  Data management for the company
        /// </summary>
        private readonly ICompanyDataService _companyDataService;

        /// <summary>
        ///  SqlExecutor.
        /// </summary>

        private readonly ISqlExecutor _executor;
       

        /// <summary>
        /// DataService Implementation
        /// </summary>
        /// <param name="sqlExecutor">Sql executor</param>
        
        public DataServiceImplementation(ISqlExecutor sqlExecutor)
        {
            _executor = sqlExecutor;
            _supplierDataServices = new SupplierDataAccessLayer(sqlExecutor);
            _helperDataServices = new HelperDataAccessLayer(sqlExecutor);
            _commissionAgentDataServices = new CommissionAgentAccessLayer(sqlExecutor);
            _vehicleDataServices = new VehiclesDataAccessLayer(sqlExecutor);
            _settingsDataService = new SettingsDataService(sqlExecutor);
            _clientDataServices = new ClientDataAccessLayer(sqlExecutor);
            _assistDataService = new AssistDataService(_helperDataServices);
            _officeDataService = new OfficeDataService(sqlExecutor);
            _companyDataService = new CompanyDataService(sqlExecutor);

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
        ///  This return the data access layer for the settings
        /// </summary>
        /// <returns></returns>
        public ISettingsDataService GetSettingsDataService()
        {
            return _settingsDataService;
        }

        public T GetDataService<T>()
        {
            var value = (T)Activator.CreateInstance(typeof(T), new object[] { _executor });
            return value;
        }
        /// <summary>
        ///  This returns the client data services.
        /// </summary>
        /// <returns></returns>
        public IClientDataServices GetClientDataServices()
        {
            return _clientDataServices;
        }
        /// <summary>
        ///  Assist data service.
        /// </summary>
        /// <returns></returns>
        public IAssistDataService GetAssistDataService()
        {
            return _assistDataService;
        }

        public IOfficeDataServices GetOfficeDataServices()
        {
            return _officeDataService;
        }

        public ICompanyDataService GetCompanyDataServices()
        {
            return _companyDataService;
        }
    }
}
