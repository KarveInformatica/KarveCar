using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  This dto is a for the reservation request summary.
    /// </summary>
    public class ReservationRequestSummary: BaseViewObject
    {
        [Display(Name = "Numero", Description = "Numero pedido")]
        public override string Code { set; get; }
        [Display(Name = "Codigo Empresa", Description = "Codigo Empresa")]
        public string CompanyCode { set; get; }
        [Display(Name = "Nome Empresa", Description = "Numero empresa")]
        public string CompanyName { set; get; }
        [Display(Name = "Data", Description = "Data")]
        public DateTime CurrentDate { set; get; }
        [Display(Name = "Día", Description = "Día Peticion Reserva")]
        public Int16? Days { get; set; }
        [Display(Name = "Grupo", Description = "Grupo Peticion Reserva")]
        public string VehicleGroup { get; set; }
        [Display(Name = "Codigo Cliente", Description = "Codigo Cliente Solicitud Reserva")]
        public string ClientCode { get; set; }
        [Display(Name = "Nombre Cliente", Description = "Nombre Cliente Solicitud Reserva")]
        public string ClientName { get; set; }
        [Display(Name = "Motivo", Description = "Motivo Solicitud Reserva")]
        public string Reason { get; set; }
        [Display(Name = "Observaciones", Description = "Observaciones")]
        public string Notes { get; set; }



    }
}
