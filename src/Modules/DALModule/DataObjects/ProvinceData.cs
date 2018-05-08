using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
    internal class ProvinceData : IProvinceData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public bool Valid { get; set; }
    }
}