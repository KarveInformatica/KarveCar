using KarveDataServices.DataObjects;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// Country Data Transfer object.
    /// </summary>
    public class CountryDto: BaseDto, ICountryData
    {
        private string _cname = string.Empty; 
        /// <summary>
        ///  Code 
        /// </summary>
        
        [Display(Name="Codigo")]
        [Required]
        public override string Code { get; set; }

        /// <summary>
        ///  CountryName
        /// </summary>
        [Display(Name = "País")]
        [Required]
        public string CountryName
        {
            get { return _cname; }
            set
            {
                _cname = value;
                ShortName = _cname.Substring(0, 2).ToUpper();
            }
        }
        private bool IsInvalid()
        {
           if (string.IsNullOrEmpty(CountryName))
            {
                return true;
            }
            if ((CountryName!=null) && (CountryName.Length>30))
            {
                return true;
            }
            return false;
        }
        public override bool HasErrors { get =>IsInvalid(); set => base.HasErrors = value; }
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
