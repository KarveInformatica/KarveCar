using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// CityDto. Data Transfer object for the city
    /// </summary>
    public class CityDto : BaseDto
    {
        /// <summary>
        ///  Code.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  Country
        /// </summary>
        public string Pais { get; set; }
        /// <summary>
        ///  City
        /// </summary>
        public string Poblacion { get; set; }
        /// <summary>
        ///  CountryDto.
        /// </summary>
        public CountryDto Country { get; set; }
    }
}
