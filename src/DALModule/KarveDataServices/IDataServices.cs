using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
    }
}
