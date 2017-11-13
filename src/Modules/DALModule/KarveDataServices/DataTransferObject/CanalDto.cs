using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    [DataContract]
    public class CanalDto
    {
        [DataMember]
        public string Canal { get; set; }
        [DataMember]
        public string Nombre { get; set; }
    }
}