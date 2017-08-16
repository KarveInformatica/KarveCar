using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    class SupplierInfoDataObject : GenericPropertyChanged, ISupplierDataObjectInfo
    {

        public string Direction { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string ProvinceCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }
        public string Notes { get; set; }
        public string Persona { get; set; }
        public string DeliveringPeriod { get; set; }
        public string DischargeDate { get; set; }
        public string LeavingDate { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Email { get ; set; }
        public string Observation { get; set; }
    }
}
