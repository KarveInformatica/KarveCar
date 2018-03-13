using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    /*
     "select numero_fac as InvoiceName, serie_fac as InvoiceSerie, referen_fac as InvoiceRef, cliente_fac as InvoiceCode, l.CONTRATO_LIF as InvoiceContract,c.nombre as ClientName, fecha_fac as InvoiceDate, cuota_fac as InvoiceFee, basesin as InvoiceBase, todo_fac as TotalInvoice, f.FRATIPIMPR as InvoiceType, c2.contable as Account, sublicen_fac as CompanyCode, s.NOMBRE as CompanyName, oficina_fac as OfficeCode, asiento_fac as Seat, fserv_a as InvoiceTo, fserv_de as InvoiceFrom, observaciones_fac as Notes, usuario_fac as InvoiceUser, ultmodi_fac as LastModification, vienede_fac as ComeFrom from facturas as f " +
                "left outer join sublicen as s on f.sublicen_fac = s.CODIGO " +
                "left outer join Lifac as l on l.NUMERO_LIF = f.NUMERO_FAC " +
                "inner join clientes1 as c on f.cliente_fac = c.numero_cli " +
                "inner join clientes2 as c2 on c.numero_cli = c2.numero_cli;"
         
         */

        /// <summary>
        ///  FIXME: remove.
        /// </summary>
    /* This entity has the resposability to model a summary for an invoice*/
    class InvoiceSummaryExtended
    {
        /// <summary>
        ///  Name of the invoice
        /// </summary>
        string InvoiceName { set; get; }
        /// <summary>
        ///  Name of the serie
        /// </summary>
        string InvoiceSerie { set; get; }
        /// <summary>
        ///  Name of the contract
        /// </summary>
        string InvoiceContract { set; get; }
        /// <summary>
        ///  Client name
        /// </summary>
        string ClientName { set; get; }
        /// <summary>
        ///  Date of the invoice
        /// </summary>
        DateTime InvoiceDate { set; get; }
        /// <summary>
        ///  Fee of the invoice
        /// </summary>
        Decimal? InvoiceFee { set; get; }
        /// <summary>
        ///  Base of the invoice
        /// </summary>
        Decimal? InvoiceBase { set; get; }
        /// <summary>
        ///  Total invoice
        /// </summary>
        Decimal? TotalInvoice { set; get; }
        /// <summary>
        ///  Type of the invoice
        /// </summary>
        byte? InvoiceType { set; get; }
        /// <summary>
        ///  Bank account
        /// </summary>
        string Account { set; get; }
        /// <summary>
        ///  CompanyCode
        /// </summary>
        string CompanyCode { set; get; }
        /// <summary>
        ///  Company Name
        /// </summary>
        string CompanyName { set; get; }
        /// <summary>
        ///  Invoice User
        /// </summary>
        string InvoiceUser { set; get; }
        /// <summary>
        ///  Last modification
        /// </summary>
        string LastModification { set; get; }
        /// <summary>
        ///  Come from.
        /// </summary>
        string ComeFrom { set; get; }
    }
}
