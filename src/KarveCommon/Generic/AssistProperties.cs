using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
    /// <summary>
    ///  Generic class that has the resposnabilty to refresh properties.
    /// </summary>
    public class AssistProperties
    { 
        
        public object CountryDto { set; get; }
        public object CityDto { set; get; }
        public object CompanyDto { set; get; }
        public object ClientZoneDto { set; get; }
        public object OrigenDto { set; get; }
        public object BrokerDto { set; get; }
        public object ClientMarketDto { set; get; }
        public object ResellerDto { set; get; }
        public object ClientTypeDto { set; get; }
    }
}
