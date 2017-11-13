using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    [DataContract]
    public class ClavePtoDto
    {
        [DataMember]
        public string Numero { get;  set; }
        [DataMember]
        public string Nombre { get; set; }
    }
}