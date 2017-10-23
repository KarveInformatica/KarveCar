using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// This returns the country data.
    /// </summary>
   public class CountryData: ICountryData
    {
        public string Code { get; set; }
        public string CountryName { get; set; }
    }
}
