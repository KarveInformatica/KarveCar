using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// ExtendedInvoiceDto.
    /// </summary>
    class ExtendedInvoiceDto: BaseDto
    {
        [Display(Name = "Factura", Description = "Factura")]
        string Bill { set; get; }
        [Display(Name = "Referencia", Description = "Referencia")]
        string Reference { set; get; }
        [Display(Name = "Cliente", Description = "Cliente")]
        string Client { set; get; }
        [Display(Name = "Nombre", Description = "Nombre")]
        string Name { set; get; }
        [Display(Name = "Contracto", Description = "Contracto")]
        string Contract { set; get; }

        
    }
}
