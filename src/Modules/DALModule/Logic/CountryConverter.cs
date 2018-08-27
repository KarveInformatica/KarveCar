using KarveDataServices.ViewObjects;
using AutoMapper;
using DataAccessLayer.DataObjects;

namespace DataAccessLayer.Logic
{
    /// <summary>
    /// POCO to Dto converter for the country domain object
    /// </summary>
    public class CountryConverter : ITypeConverter<Country, CountryViewObject>
    {
        public CountryViewObject Convert(Country source, CountryViewObject destination, ResolutionContext context)
        {
            CountryViewObject dto = new CountryViewObject();
            dto.Code = source.SIGLAS;
            dto.CountryName = source.PAIS;
            dto.Language = source.IDIOMA_PAIS;
            if (source.INTRACO.HasValue)
            {
                var value = source.INTRACO.Value;
                dto.IsIntraco = value == 1;
            }
            return dto;
        }
    }
}

