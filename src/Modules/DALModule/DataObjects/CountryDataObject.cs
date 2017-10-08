using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    public class CountryDataObject : ICountryData
    {
        public object CountryCode { get; set ; }
        public object Name { get; set; }
    }
}
