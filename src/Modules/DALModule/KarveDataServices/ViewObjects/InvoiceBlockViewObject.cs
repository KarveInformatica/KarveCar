using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  Invoice Block Dto.
    /// </summary>
    public class InvoiceBlockViewObject: BaseViewObjectDefaultName
    {
        
        /// <summary>
        ///  Code.
        /// </summary>
        [Display(Name="Codigo Bloque Factura")]
        public override string Code { get; set; }
        /// <summary>
        ///  Description.
        /// </summary>
        [Display(Name = "Nombre Bloque Factura")]
        public override string Name { get; set; }


    }
}
