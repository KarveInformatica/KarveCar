using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class CompanySummaryDto : BaseDto
    {
        public string Code { get; set; }
        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Nif.
        /// </summary>
        public string Nif { get; set; }
        /// <summary>
        ///  Telefono empresa.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        ///  Set or get the DIRECCION property.
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// <summary>
        ///  Set or get the POBLACION property.
        /// </summary>
        public CityDto City { get; set; }
        /// <summary>
        ///  Province 
        /// </summary>
        public ProvinciaDto Province { get; set; }
        /// <summary>
        ///  Country
        /// </summary>
        public CountryDto Country { get; set; }

    }
}
