using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Company data transfer object
    /// </summary>
    public class CompanyDto : BaseDto
    {
        public CompanyDto() : base()
        {
            City = new CityDto();
            Province = new ProvinciaDto();
            Country = new CountryDto();
            Offices = new List<OfficeDtos>();
        }
        /// <summary>
        ///  Code 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  Name
        /// </summary>
        public string Name { get; set; }
        // Commercial Name
        public string CommercialName { get; set; }
        /// <summary>
        ///  Poblacion
        /// </summary>
        public string Poblacion { get; set; }
        /// <summary>
        ///  Nif
        /// </summary>
        public string Nif { get; set; }


        public CityDto City { get; set; }

        public ProvinciaDto Province { get; set; }

        public CountryDto Country { get; set; }
        /// <summary>
        ///  Offices of the company.
        /// </summary>
        public IEnumerable<OfficeDtos> Offices { get; set; }
    }
}
