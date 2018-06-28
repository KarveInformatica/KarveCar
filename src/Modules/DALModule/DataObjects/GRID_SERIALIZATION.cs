using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
    [Table("GRID_SERIALIZATION")]
    public class GRID_SERIALIZATION
    {
        [KarveDapper.Extensions.Key]
        [DbTypeField("Long")]
        public long GRID_ID { get; set; }
        [DbTypeField("String")]
        public string GRID_NAME { get; set; }
        [DbTypeField("Xml")]
        public string SERILIZED_DATA { get; set; }
    }
}
