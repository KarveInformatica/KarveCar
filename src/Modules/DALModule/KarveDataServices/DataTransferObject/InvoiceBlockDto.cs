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
    public class InvoiceBlockDto
    {
        /// <summary>
        ///  Last modification
        /// </summary>
        public string LastModification { get; set; }
        /// <summary>
        ///  Code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  Description.
        /// </summary>
        public string Description { get; set; }
    }
}
