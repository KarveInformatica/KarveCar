using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Invoice Block Dto.
    /// </summary>
    public class InvoiceBlockDto: BaseDto
    {
        
        /// <summary>
        ///  Code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  Description.
        /// </summary>
        public string Name { get; set; }
    }
}
