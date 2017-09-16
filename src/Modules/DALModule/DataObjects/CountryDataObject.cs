using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataObjects;
namespace KarveDataAccessLayer.DataObjects
{
    public class CountryDataObject : ICountryData
    {
        public object CountryCode { get; set ; }
        public object Name { get; set; }
    }
}
