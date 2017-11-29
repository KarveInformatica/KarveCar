using KarveDataServices.DataObjects;

namespace KarveDataServices.DataTransferObject
{
    public class ProvinciaDto : IProvinceData
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        public string Country { get; set; }
    }
}