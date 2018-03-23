namespace KarveDataServices.DataTransferObject
{
    public class SupplierTypeDto: BaseDto
    {

        public short Codigo { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string UltimaModifica { get; set; }
    }
}