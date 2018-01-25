using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Client Type Dto.
    /// </summary>
    public class ClientTypeDto: BaseDto
    {
        // <summary>
        /// Set or get.
        ///</summary>

        public string Code { get; set; }
        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        public string Name { get; set; }
    }
}
