using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{

    /// <summary>
    ///  Tarifa of a contract to be used.
    /// </summary>
    public class ContractByClientDto : BaseDto
    {
        public ContractByClientDto()
        {
        }
        [Display(Name = "Contract")]
        public string Contract { set; get; }
        [Display(Name = "Salida")]
        public DateTime DepartureDate { set; get; }
        [Display(Name = "Prevista")]
        public DateTime ForecastDeparture { set; get; }
        [Display(Name = "Retorno")]
        public DateTime ReturnDate { set; get; }
        [Display(Name = "Dias")]
        public int Days { set; get; }
        [Display(Name = "Conductor")]
        public string Driver { set; get; }
        [Display(Name = "Matricula")]
        public int Matricula { set; get; }
        [Display(Name = "Marca")]
        public string Brand { set; get; }
        [Display(Name = "Modelo")]
        public string Model { set; get; }
        [Display(Name = "Tarifa")]
        public string Fare { set; get; }
        [Display(Name = "Factura")]
        public string InvoiceNumber { set; get; }
        [Display(Name = "Importe")]
        public decimal GrossInvoice { set; get; }
    }
}
