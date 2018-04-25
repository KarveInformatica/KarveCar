using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Data transfer object for the currency.
    /// </summary>
    public class CurrenciesDto : BaseDto
    {
        // Code
        public string Code
        {
            set;get;
        }
        /// <summary>
        ///  Name of the currency.
        /// </summary>
        public string Name
        {
            set; get;
        }
    }
}
