using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Office summary data transfer object.
    /// </summary>
    public class OfficeSummaryDto
    {
        /// <summary>
        ///  Codigo code.
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        ///  Nombre name
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        ///  Direction.
        /// </summary>
        public string Direction { set; get; }
        /// <summary>
        ///  City
        /// </summary>
        public string City { set; get; }
        /// <summary>
        ///  Company name
        /// </summary>
        public string CompanyName { set; get; }
        /// <summary>
        ///  Office zone/
        /// </summary>
        public string OfficeZone { set; get; }
    }
}
