using KarveDataServices.DataObjects;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// Country Data Transfer object.
    /// </summary>
    public class CountryDto: ICountryData
    {
        private string _cname = string.Empty; 
        /// <summary>
        ///  Code 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///  CountryName
        /// </summary>
        public string CountryName
        {
            get { return _cname; }
            set
            {
                _cname = value;
                ShortName = _cname.Substring(0, 2).ToUpper();
            }
        }

        public byte? Language { set; get; }
        /// <summary>
        ///  CountryCode
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// IsIntraco.
        /// </summary>
        public bool IsIntraco { get; set; }

        public string ShortName { get; set; }
    }
}
