using System.Data;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IDataServices
    {
        /// <summary>
        ///  Get all banks in the system
        /// </summary>
        /// <returns></returns>
        DataTable GetAllBanks();

        /// <summary>
        /// Returns the payment data services.
        /// </summary>
        /// <returns></returns>
        IPaymentDataServices GetPaymentDataService();

        /// <summary>
        /// Returns the vehicle data services.
        /// </summary>
        IVehicleDataServices GetVehicleDataServices();
        /// <summary>
        ///  This returns all subsystem that is needed for the suppliers.
        /// </summary>
        /// <returns></returns>
        ISupplierDataServices GetSupplierDataServices();
    }

}
