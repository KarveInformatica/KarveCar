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
    /// "BudgetNumber,BudgetOffice,ClientName,GroupCode,BudgetCreationDate,DepartureDate,BookingNumber,BrokerName,Origin";
    /// </summary>
    public class BudgetSummaryDto: BaseDto
    {
        [Display(Name = "Numero", Description = "Numero Presuppuesto")]
        public string BudgetNumber { set; get; }
        /// <summary>
        ///  Set or Get the booking date 
        /// </summary>
        [Display(Name = "Oficina", Description = "Oficina reserva")]
        public string BudgetOffice { set; get; }
        /// <summary>
        /// Nombre cliente
        /// </summary>
        [Display(Name = "Nombre Cliente", Description = "Nombre Cliente")]
        public string ClientName { set; get; }
        /// <summary>
        ///  Fecha creacion.
        /// </summary>
        [Display(Name = "Fecha Creacion", Description = "CreationDate")]
        public DateTime BudgetCreationDate { set; get; }
        /// <summary>
        /// Departure Date.
        /// </summary>
        [Display(Name = "Fecha Salida", Description = "SalidaDate")]
        public DateTime DepartureDate { set; get; }
        /// <summary>
        ///  Grupo
        /// </summary>
        [Display(Name = "Grupo", Description = "Group")]
        public string GroupCode { set; get; }
        /// <summary>
        ///  Booking  Number
        /// </summary>
        [Display(Name = "Numero Reserva", Description = "Numero Reserva")]
        public string BookingNumber { set; get; }
        /// <summary>
        ///  BrokerName
        /// </summary>
        [Display(Name = "Nombre Comisionista", Description = "Nombre Comisionista")]
        public string BrokerName { set; get; }
        /// <summary>
        ///  BonusNumber
        /// </summary>
        [Display(Name = "BonusNumber", Description = "Reserva")]
        public string BonusNumber { set; get; }
        /// <summary>
        ///  Origin 
        /// </summary>
        [Display(Name = "Origin", Description = "Origin")]
        public string Origin { set; get; }
        /// <summary>
        ///  Notes.
        /// </summary>
        [Display(Name = "Notes", Description = "Notes")]
        public string Notes { set; get; }
    }
}
