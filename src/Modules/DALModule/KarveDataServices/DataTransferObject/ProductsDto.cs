namespace KarveDataServices.DataTransferObject
{
    public class ProductsDto: BaseDto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
    }
}