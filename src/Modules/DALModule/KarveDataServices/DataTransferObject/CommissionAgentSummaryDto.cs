using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{

    /// <summary>
    ///  CommissinAgent Summary Data Transfer object.
    /// </summary>
    public class CommissionAgentSummaryDto: BaseDto
    {
        [Display(Name = "Numero Commissionista")]
        public string Code { set; get; }
        [Display(Name = "Nombre Commisionista")]
        public string Name { set; get; }
        [Display(Name = "Persona riferimento")]
        public string Person { set; get; }
        [Display(Name = "Nif")]
        public string Nif { set; get; }
        [Display(Name = "Direccion")]
        public string Direction { set; get; }
        [Display(Name = "CP")]
        public string CP { set; get; }
        [Display(Name = "Poblacion")]
        public string City { set; get; }
        [Display(Name = "Provincia")]
        public string Province { set; get; }
        [Display(Name = "Pais")]
        public string Country { set; get; }
        [Display(Name = "N.IATA")]
        public string IATA { set; get; }
        [Display(Name = "Empresa")]
        public string Company { set; get; }
        [Display(Name = "Zona")]
        public string OfficeZone { set; get; }
    }
}
