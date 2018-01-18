using System.Runtime.Serialization;

namespace KarveDataServices.DataTransferObject
{
    [DataContract]
    public class ChannelDto: BaseDto
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}