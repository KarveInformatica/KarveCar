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
        private IPaymentDataServices _paymentDataService;
        private ISupplierDataServices _supplierDataServices;
        private IHelperDataServices _helperDataServices;

        public DataServiceImplementation(ISqlQueryExecutor sqlQueryExecutor, 
            IConfigurationService configurationService)
        {
            _bankLayer = new BanksDataAccessLayer(sqlQueryExecutor);
            _paymentDataService = new ChargeTypeDataAccessLayer(sqlQueryExecutor);
            _supplierDataServices = new SupplierDataAccessLayer(sqlQueryExecutor, configurationService);
            _helperDataServices = new HelperDataAccessLayer(sqlQueryExecutor);
        }
        /// <summary>
        ///  Returns a the complete list of banks in the system.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBanks()
        {
             return new DataTable(); 
                //_bankLayer.GetAllBanksTable();
        }

        /// <summary>
        /// Get the payement data services.
        /// </summary>
        /// <returns></returns>
        public IPaymentDataServices GetPaymentDataService()
        {
            return _paymentDataService;
        }

        public IVehicleDataServices GetVehicleDataServices()
        {
            return null;
            // throw new VeichlesDataService();
        }

        public ISupplierDataServices GetSupplierDataServices()
        {
           return _supplierDataServices;
        }
        
        public IHelperDataServices GetHelperDataServices()
        {
            return _helperDataServices;
        }

        public IDataServicesSession OpenSession()
        {
            return null;
           // throw new NotImplementedException();
        }

        public void CloseSession(IDataServicesSession session)
        {
           
           /// throw new NotImplementedException();
        }
    }
}
