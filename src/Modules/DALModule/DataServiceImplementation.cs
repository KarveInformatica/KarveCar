using System;
using System.Data;
using KarveCommon.Generic;
using KarveCommon.Services;
using KarveDataServices;

namespace DataAccessLayer
{
    /// <summary>
    ///  Implementation of the the IDataService interface to provide the stairway pattern.
    /// 
    /// </summary>
    public class DataServiceImplementation : IDataServices
    {
        private BanksDataAccessLayer _bankLayer;
        // private readonly payment data services
        private readonly IPaymentDataServices _paymentDataService;
        // private supplier services
        private readonly ISupplierDataServices _supplierDataServices;
        // private helper data services.
        private readonly IHelperDataServices _helperDataServices;
        // private commission agent access layer.
        private readonly ICommissionAgentDataServices _commissionAgentDataServices;

        private readonly IVehicleDataServices _vehicleDataServices;


        public DataServiceImplementation(ISqlQueryExecutor sqlQueryExecutor, 
            IConfigurationService configurationService)
        {
            _paymentDataService = new ChargeTypeDataAccessLayer(sqlQueryExecutor);
            _supplierDataServices = new SupplierDataAccessLayer(sqlQueryExecutor, configurationService);
            _helperDataServices = new HelperDataAccessLayer(sqlQueryExecutor);
            _commissionAgentDataServices = new CommissionAgentAccessLayer(sqlQueryExecutor);
            _vehicleDataServices = new VehiclesDataAccessLayer(sqlQueryExecutor);
        }
     
        /// <summary>
        /// Get the payement data services that are resposibles for the paymment and charging.
        /// </summary>
        /// <returns></returns>
        public IPaymentDataServices GetPaymentDataService()
        {
            return _paymentDataService;
        }
        /// <summary>
        ///  Get teh vehicle data services that represent all veihicles.
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
        /// <returns></returns>
        public IHelperDataServices GetHelperDataServices()
        {
            return _helperDataServices;
        }

        public ICommissionAgentDataServices GetCommissionAgentDataServices()
        {
           return _commissionAgentDataServices;
        }
    }
}
