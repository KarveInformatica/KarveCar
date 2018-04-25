using KarveDataServices.DataObjects;

namespace KarveDataServices.DataTransferObject
{
    public class ProvinciaDto : BaseDto, IProvinceData
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  Code of the country. It is a redondant field
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        ///  Capital of the province
        /// </summary>
        public string Capital { get; set; }
        // Prefix of the province.
        public string Prefix { get; set; }
        // value of the province.
        public CountryDto CountryValue { set; get; }
    }
}