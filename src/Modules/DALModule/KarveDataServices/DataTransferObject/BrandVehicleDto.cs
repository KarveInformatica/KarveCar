using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// Data transfer object of each vehicle.
    /// </summary>
    [DataContract]
    public class BrandVehicleDto : BaseDto
    {
        [DataMember]
        public string Codigo { get;  set; }
        [DataMember]
        public string Nombre { get;  set; }
    }
}