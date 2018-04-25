using KarveDataServices.DataTransferObject;
using System.Collections.Generic;

namespace KarveDataServices
{
    public interface IHelperBase
    {
        /// <summary>
        ///  Province Data Transfer Object.
        /// </summary>
        IEnumerable<ProvinciaDto> ProvinciaDto { get; set; }
        /// <summary>
        ///  Country Data Transfer Object.
        /// </summary>
        IEnumerable<CountryDto> CountryDto { get; set; }
        /// <summary>
        /// City Data Transfer Object.
        /// </summary>
        IEnumerable<CityDto> CityDto { get; set; }
        /// <summary>
        /// Zone Data Transfer Object
        /// </summary>
        IEnumerable<ZonaOfiDto> ClientZoneDto { get; set; }
        /// <summary>
        ///  Base zona 
        /// </summary>
        IEnumerable<ClientZoneDto> ZoneDto { get; set; }

    }
}