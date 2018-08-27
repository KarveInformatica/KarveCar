using KarveDataServices.ViewObjects;
using AutoMapper;
using DataAccessLayer.DataObjects;

namespace DataAccessLayer.Logic
{
    /// <summary>
    /// Drto converter for the provice domain object
    /// </summary>
    public class ProvinceConverterToPOCO : ITypeConverter<ProvinceViewObject, PROVINCIA>
    {
        /// <summary>
        ///  Provincia converter
        /// </summary>
        /// <param name="source">Convert the provincia</param>
        /// <param name="destination"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public PROVINCIA Convert(ProvinceViewObject source, PROVINCIA destination, ResolutionContext context)
        {
            PROVINCIA prov = new PROVINCIA();
            prov.SIGLAS = source.Code;
            prov.PROV = source.Name;
            prov.CAPITAL = source.Capital;
            prov.PREFIJO = source.Prefix;
            prov.PAIS = source.CountryValue.Code;
            return prov;
        }
    }
}

