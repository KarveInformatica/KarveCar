using KarveDataServices;
using System.Data;
using System;
using KarveCommon.Services;

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

        public DataServiceImplementation(IKarveDataMapper mapper, 
            IConfigurationService configurationService)
        {
            _bankLayer = new BanksDataAccessLayer(mapper.DataMapper);
            _paymentDataService = new ChargeTypeDataAccessLayer(mapper.DataMapper);
            _supplierDataServices = new SupplierDataAccessLayer(mapper, configurationService);
            _helperDataServices = new HelperDataAccessLayer(mapper.DataMapper);
        }
        /// <summary>
        ///  Returns a the complete list of banks in the system.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBanks()
        {
             return _bankLayer.GetAllBanksTable();
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
            throw new NotImplementedException();
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
