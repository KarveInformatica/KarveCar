using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  This makes sense in case of a company.
    /// </summary>
    class Company : ICompanyData
    {
        public CompanyViewObject Value { get; set; }

        public IEnumerable<ProvinceViewObject> ProvinciaDto { get; set; }
        public IEnumerable<CountryViewObject> CountryDto { get ; set; }
        public IEnumerable<CityViewObject> CityDto { get ; set; }
        // fixme this no makes sense
        public IEnumerable<ZonaOfiViewObject> ClientZoneDto { get; set ; }
        public IEnumerable<ClientZoneViewObject> ZoneDto { get ; set; }
        public IEnumerable<DelegaContableViewObject> ContableDelegaDto { get; set; }
        public IEnumerable<OfficeViewObject> OfficeDto { get; set ; }
        public bool Valid { get; set ; }
    }
}
