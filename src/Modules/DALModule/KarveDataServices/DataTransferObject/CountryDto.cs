using KarveDataServices.DataObjects;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// Country Data Transfer object.
    /// </summary>
    public class CountryDto: ICountryData
    {
        public string Code { get; set; }
        public string CountryName { get; set; }
    }
}
