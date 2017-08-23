using KarveDataServices;
using System.Data;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    ///  Implementation of the the IDataService interface to provide the stairway pattern.
    /// 
    /// </summary>
    public class DataServiceImplementation : IDataServices
    {
        private BanksDataAccessLayer _bankLayer = new BanksDataAccessLayer();
        private IPaymentDataServices _paymentDataService = new ChargeTypeDataAccessLayer();
        private ISupplierDataServices _supplierDataServices = new SupplierDataAccessLayer();
        private IHelperDataServices _helperDataServices = new HelperDataAccessLayer();

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
    }
}
