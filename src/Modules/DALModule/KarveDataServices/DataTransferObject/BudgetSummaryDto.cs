using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// BugdetSummaryDto.
    /// </summary>
    public class BudgetSummaryDto: BaseDto
    {
        [Display(Name = "Numero", Description = "Numero Presuppuesto")]
        public string BudgetNumber { set; get; }
        /// <summary>
        ///  Set or Get the booking date 
        /// </summary>
        [Display(Name = "Oficina", Description = "Oficina reserva")]
        public DateTime BudgetOffice { set; get; }
        [Display(Name = "Fecha Creacion", Description = "CreationDate")]
        public DateTime CreationDate { set; get; }
        [Display(Name = "Fecha Salida", Description = "SalidaDate")]
        public DateTime DepartureDate { set; get; }
        [Display(Name = "Grupo", Description = "Group")]
        public string Group { set; get; }
        [Display(Name = "Cliente", Description = "Cliente")]
        public string Client { set; get; }
        [Display(Name = "Codigo Cliente", Description = "Codigo Cliente")]
        public string ClientCode { set; get; }
        [Display(Name = "Reservation", Description = "Reserva")]
        public string Reservation { set; get; }
        [Display(Name = "Comisionista", Description = "Comisionista")]
        public string Broker { set; get; }
    }
}
