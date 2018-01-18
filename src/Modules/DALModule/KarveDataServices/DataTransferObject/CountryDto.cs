using KarveDataServices.DataObjects;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// Country Data Transfer object.
    /// </summary>
    public class CountryDto: ICountryData
    {
        /// <summary>
        ///  Code 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  CountryName
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        ///  CountryCode
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// IsIntraco.
        /// </summary>
        public bool IsIntraco { get; set; }
    }
}
