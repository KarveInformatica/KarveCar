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
        private ISqlExecutor _executor;
        private object _serviceConf;

        /// <summary>
        /// DataService Implementation
        /// </summary>
        /// <param name="sqlExecutor">Sql executor</param>
        /// <param name="configurationService">Configuration service. Global services for the application</param>
        public DataServiceImplementation(ISqlExecutor sqlExecutor)
        {
            /* move to generic all this a good schema might be 
                _supplierDataServices = new DataAccessLayer<ISupplierData>(sqlExecutor);
                _helperDataServices = new DataAccessLayer<IHelperData>(sqlExecutor);
                _DataServices = new DataAccessLayer<I>(sqlExecutor);
             */
            _supplierDataServices = new SupplierDataAccessLayer(sqlExecutor);
            _helperDataServices = new HelperDataAccessLayer(sqlExecutor);
            _commissionAgentDataServices = new CommissionAgentAccessLayer(sqlExecutor);
            _vehicleDataServices = new VehiclesDataAccessLayer(sqlExecutor);
            _settingsDataService = new SettingsDataService(sqlExecutor);
        }
        /* this looks like a smell
         * 
        /// <summary>
        /// This is the data service implmentation 
        /// </summary>
        /// <param name="executor">SqlExecutor that implements the execution </param>
        /// <param name="serviceConf">Configuration of the service</param>
        public DataServiceImplementation(ISqlExecutor executor, object serviceConf)
        {
            _executor = executor;
            _serviceConf = serviceConf;
        }
        */

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

        public ISettingsDataService GetSettingsDataService()
        {
            return _settingsDataService;
        }

    }
}
