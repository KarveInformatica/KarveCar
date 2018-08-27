using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{

    /// <summary>
    ///  CommissinAgent Summary Data Transfer object.
    /// </summary>
    public class CommissionAgentSummaryViewObject: BaseViewObject
    {
        [Display(Name = "Numero Commissionista")]
        public new string Code { set; get; }
        [Display(Name = "Nombre Commisionista")]
        public new string Name { set; get; }
        [Display(Name = "Persona riferimento")]
        public string Person { set; get; }
        [Display(Name = "Nif")]
        public string Nif { set; get; }
        [Display(Name = "Direccion")]
        public string Direction { set; get; }
        [Display(Name = "CP")]
        public string Zip { set; get; }
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
