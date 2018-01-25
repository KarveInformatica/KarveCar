using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class ContactTypeDto: BaseDto
    {
        /// <summary>
        ///  Set or get the Codigo property.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  Set or get the Nombre property.
        /// </summary>
        public string Name { get; set; }
    }
}
