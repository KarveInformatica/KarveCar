namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  CityCountryDto. Contains the dto for the city and the country.
    /// </summary>
    public class CityCountryDto
    {
        public string Code { set; get; }
        public CityDto City { set; get; }
        public CountryDto Country { set; get; }
    }
}