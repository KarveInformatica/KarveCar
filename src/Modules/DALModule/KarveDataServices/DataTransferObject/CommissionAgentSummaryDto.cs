using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    public class CommissionAgentSummaryDto: BaseDto
    {
        [Display(Name = "Numero Commissionista")]
        public string Numero { set; get; }
        [Display(Name = "Nombre Commisionista")]
        public string Nombre { set; get; }
        [Display(Name = "Persona riferimento")]
        public string Persona { set; get; }
        [Display(Name = "Nif")]
        public string Nif { set; get; }
        [Display(Name = "Direccion")]
        public string Direccion { set; get; }
        [Display(Name = "Poblacion")]
        public string Poblacion { set; get; }
        [Display(Name = "Provincia")]
        public string Provincia { set; get; }
        [Display(Name = "Pais")]
        public string Pais { set; get; }
    }
}
