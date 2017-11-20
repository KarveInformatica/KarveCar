using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// This returns the country data
    ///  TODO: this was an old poco for auxiliares. Deprecated.
    /// </summary>
   public class CountryData: ICountryData
    {
        /// <summary>
        ///  Data
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  This gives us the contru
        /// </summary>
        public string CountryName { get; set; }
    }
}
