using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;

namespace DataAccessLayer.DataObjects
{
    class SupplierProvinceDataObject : GenericPropertyChanged
    {
        public string SupplierName { set; get; }
        public string Province { set; get; }
        public string ProvinceCode { set; get; }
    }
}
