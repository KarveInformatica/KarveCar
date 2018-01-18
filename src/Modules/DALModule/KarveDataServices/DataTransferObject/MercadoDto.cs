namespace KarveDataServices.DataTransferObject
{
    public class MercadoDto
    {
        [PrimaryKey]
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
}