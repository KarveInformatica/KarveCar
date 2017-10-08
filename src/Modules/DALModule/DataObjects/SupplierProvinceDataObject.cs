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
