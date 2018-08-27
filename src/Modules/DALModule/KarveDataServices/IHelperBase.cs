using KarveDataServices.ViewObjects;
using System.Collections.Generic;

namespace KarveDataServices
{
    /// <summary>
    /// This is the structure of the helperbase. 
    /// </summary>
    public interface IHelperBase
    {
        /// <summary>
        ///  Province Data Transfer Object.
        /// </summary>
        IEnumerable<ProvinceViewObject> ProvinciaDto { get; set; }
        /// <summary>
        ///  Country Data Transfer Object.
        /// </summary>
        IEnumerable<CountryViewObject> CountryDto { get; set; }
        /// <summary>
        /// City Data Transfer Object.
        /// </summary>
        IEnumerable<CityViewObject> CityDto { get; set; }
        /// <summary>
        /// Zone Data Transfer Object
        /// </summary>
        IEnumerable<ZonaOfiViewObject> ClientZoneDto { get; set; }
        /// <summary>
        ///  Base zona 
        /// </summary>
        IEnumerable<ClientZoneViewObject> ZoneDto { get; set; }
        /// <summary>
        ///  Set or Get ContableDelegaDto.
        /// </summary>
        IEnumerable<DelegaContableViewObject> ContableDelegaDto { get; set; }
       

    }
}