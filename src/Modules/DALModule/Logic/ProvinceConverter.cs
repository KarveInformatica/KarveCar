using KarveDataServices.ViewObjects;
using AutoMapper;
using DataAccessLayer.DataObjects;

namespace DataAccessLayer.Logic
{
    /// <summary>
    /// POCO to Dto converter for the provice domain object
    /// </summary>
    public class ProvinceConverter : ITypeConverter<PROVINCIA, ProvinceViewObject>
    {
        public ProvinceViewObject Convert(PROVINCIA source, ProvinceViewObject destination, ResolutionContext context)
        {
            ProvinceViewObject prov = new ProvinceViewObject();
            prov.Code = source.SIGLAS;
            prov.Name = source.PROV;
            prov.Capital = source.CAPITAL;
            prov.Prefix = source.PREFIJO;
            prov.Country = source.PAIS;
            prov.CountryValue = new CountryViewObject();
            // TODO: avoid this replication
            prov.CountryValue.CountryCode = source.PAIS;
            prov.CountryValue.Code = source.PAIS;
            return prov;
        }
    }
}

