namespace KarveDataServices.DataTransferObject
{
    public class CommissionAgentSummaryDto: BaseDto
    {
        public string Numero { set; get; }
        public string Nombre { set; get; }
        public string Persona { set; get; }
        public string Nif { set; get; }
        public string Direccion { set; get; }
        public string Poblacion { set; get; }
        public string Provincia { set; get; }
        public string Pais { set; get; }
    }
}
