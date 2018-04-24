using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Model
{
    /// <summary>
    ///  This makes sense in case of a company.
    /// </summary>
    class Company : ICompanyData
    {
        public CompanyDto Value { get; set; }
        public IEnumerable<ProvinciaDto> ProvinciaDto { get; set; }
        public IEnumerable<CountryDto> CountryDto { get ; set; }
        public IEnumerable<CityDto> CityDto { get ; set; }
        // fixme this no makes sense
        public IEnumerable<ZonaOfiDto> ClientZoneDto { get; set ; }
        public IEnumerable<ClientZoneDto> ZoneDto { get ; set; }
        public IEnumerable<DelegaContableDto> ContableDelegaDto { get; set; }
        public IEnumerable<OfficeDtos> OfficeDto { get; set ; }
    }
}
