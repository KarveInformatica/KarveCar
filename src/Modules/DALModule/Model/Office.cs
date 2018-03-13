using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  Office data
    /// </summary>
    public class Office : DomainObject, IOfficeData
    {
        private OfficeDtos _value = new OfficeDtos();
     
        public Office() 
        {
            Valid = false;
        }
        /// <summary>
        ///  This returns the value of an office.
        /// </summary>
        public OfficeDtos Value { get ; set ; }
        /// <summary>
        ///  Check if the province is valid or not.
        /// </summary>
        public IEnumerable<ProvinciaDto> ProvinciaDto { get ; set ; }
        /// <summary>
        ///  Check if the country is valid or not.
        /// </summary>
        public IEnumerable<CountryDto> CountryDto { get; set ; }
        /// <summary>
        ///  Check if the city is valid or not.
        /// </summary>
        public IEnumerable<CityDto> CityDto { get ; set; }
        /// <summary>
        ///  Office zone dto.
        /// </summary>
        public IEnumerable<ZonaOfiDto> ClientZoneDto { get ; set ; }
        // Client zone dto.
        public IEnumerable<ClientZoneDto> ZoneDto { get ; set ; }
        /// <summary>
        /// CurrenciesDto.
        /// </summary>
        public IEnumerable<CurrenciesDto> CurrenciesDto { get ; set ; }

}

}