using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
namespace DataAccessLayer.DataObjects
{
    public class CountryDataObject : ICountryData
    {
        /// <summary>
        ///  code of the country
        /// </summary>
        public string Code { get; set ; }
        // name of the country
        public string Name { get; set; }
        /// <summary>
        ///  country name
        /// </summary>
        public string CountryName
        {
            get; set;
        }
    }
}
