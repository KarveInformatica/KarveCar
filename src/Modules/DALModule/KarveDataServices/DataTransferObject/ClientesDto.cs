using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    [DataContract]
    public class ClientesDto: BaseDto
    {
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Movil { get;  set; }
        [DataMember]
        public string Nombre { get; set; }
    }
}