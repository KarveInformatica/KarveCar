using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Public current situation dto.
    /// </summary>
    public class CurrentSituationDto: BaseDto
    {
        /// <summary>
        ///  code
        /// </summary>
        public byte Code { set;get; }
        /// <summary>
        ///  name.
        /// </summary>
        public string Name { get; set; }
    }
}
