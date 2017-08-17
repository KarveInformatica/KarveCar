using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
   public class SupplierInfoDataObject : GenericPropertyChanged, ISupplierDataObjectInfo
    {


        private string _countryCode;
        private string _direction;
        public string Direction {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
                OnPropertyChanged("Direction");
            }
        }
        public string CountryCode {
            get
            {
                return _countryCode;
            }
            set
            {
                _countryCode = value;
                OnPropertyChanged("CountryCode");
            }
        }
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
