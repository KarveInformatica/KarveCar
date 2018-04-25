using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  RentingUseDto.
    /// </summary>
    public class RentingUseDto: BaseDto
    {
        /// <summary>
        ///  Code of renting
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        ///  Name of renting.
        /// </summary>
        public string Name { set; get; }
    }
}
