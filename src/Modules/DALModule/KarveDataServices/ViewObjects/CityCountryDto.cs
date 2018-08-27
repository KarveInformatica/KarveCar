namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  CityCountryDto. Contains the viewObject for the city and the country.
    /// </summary>
    public class CityCountryDto
    {
        public string Code { set; get; }
        public CityViewObject City { set; get; }
        public CountryViewObject Country { set; get; }
    }
}