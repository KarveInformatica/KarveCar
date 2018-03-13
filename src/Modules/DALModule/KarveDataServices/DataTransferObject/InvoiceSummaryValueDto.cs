using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  This class is resposible for showing the values of all invoices present in the system.
    /// </summary>
    /*
     select numero_fac as InvoiceName, serie_fac as InvoiceSerie, 
referen_fac as InvoiceRef, cliente_fac as InvoiceCode, l.CONTRATO_LIF as InvoiceContract,c.nombre as ClientName, 
fecha_fac as InvoiceDate, cuota_fac as InvoiceFee, basesin as InvoiceBase, todo_fac as TotalInvoice, f.FRATIPIMPR as InvoiceType,
c2.contable as Account, sublicen_fac as CompanyCode, s.NOMBRE as CompanyName, oficina_fac as OfficeCode, asiento_fac as Seat, fserv_a as InvoiceTo, 
fserv_de as InvoiceFrom,
observaciones_fac as Notes, usuario_fac as InvoiceUser, ultmodi_fac as LastModificatoin, 
vienede_fac as ComeFrom 
from facturas as f
left outer join sublicen as s on f.sublicen_fac = s.CODIGO
left outer join Lifac as l on l.NUMERO_LIF = f.NUMERO_FAC
inner join clientes1 as c on f.cliente_fac = c.numero_cli 
inner join clientes2 as c2 on c.numero_cli = c2.numero_cli;
         
         */
    public class InvoiceSummaryValueDto : NotificationObject, IEquatable<InvoiceSummaryValueDto>
    {
        private string _invoiceCode;
        private string _client;
        private string _name;
        private string _contract;
        private DateTime _date;
        private double _base;
        private double _fee;
        private double _total;
        private double _company;
        private string _office;
        private string _type;
        private string _number;
        private string _invoiceName;
        private string _invoiceSerie;
        private string _invoiceRef;

        /*

{QueryType.QueryInvoiceSummaryExtended, "select numero_fac as InvoiceName, serie_fac as InvoiceSerie, referen_fac as InvoiceRef, cliente_fac as InvoiceCode, l.CONTRATO_LIF as InvoiceContract,c.nombre as ClientName, fecha_fac as InvoiceDate, cuota_fac as InvoiceFee, basesin as InvoiceBase, todo_fac as TotalInvoice, f.FRATIPIMPR as InvoiceType, c2.contable as Account, sublicen_fac as CompanyCode, s.NOMBRE as CompanyName, oficina_fac as OfficeCode, asiento_fac as Seat, fserv_a as InvoiceTo, fserv_de as InvoiceFrom, observaciones_fac as Notes, usuario_fac as InvoiceUser, ultmodi_fac as LastModificatoin, vienede_fac as ComeFrom from facturas as f " +
"left outer join sublicen as s on f.sublicen_fac = s.CODIGO " +
"left outer join Lifac as l on l.NUMERO_LIF = f.NUMERO_FAC " +
"inner join clientes1 as c on f.cliente_fac = c.numero_cli " +
"inner join clientes2 as c2 on c.numero_cli = c2.numero_cli;" }
*/


        /// <summary>
        ///  Set or Get the InvoiceCode.
        /// </summary>
        [Display(Name = "Num.Factura", Description = "Numero Factura")]
        public string InvoiceName
        {
            set { _invoiceName = value; RaisePropertyChanged("InvoiceName"); }
            get { return _invoiceName; }
        }

        /// <summary>
        ///  Set or Get the InvoiveSerie.
        /// </summary>
        [Display(Name = "Serie Factura", Description = "Serie Factura")]
        public string InvoiceSerie
        {
            set { _invoiceSerie = value; RaisePropertyChanged("InvoiceSerie"); }
            get { return _invoiceSerie; }
        }
        /// <summary>
        ///  Referencia Factura.
        /// </summary>
        [Display(Name = "Referencia Factura", Description = "Referencia Factura")]
        public string InvoiceRef
        {
            set { _invoiceRef = value; RaisePropertyChanged("InvoiceRef"); }
            get { return _invoiceRef; }
        }
        /// <summary>
        ///  Set or Get the InvoiceCode.
        /// </summary>
        [Display(Name = "Cod.Cliente", Description = "Codigo de Cliente")]
        public string InvoiceCode
        {
            set { _invoiceCode = value; RaisePropertyChanged("InvoiceCode"); }
            get { return _invoiceCode; }
        }
        /// <summary>
        ///  Set or Get the Client name.
        /// </summary>
        [Display(Name = "Cliente", Description = "Codigo de Cliente")]
        public string ClientName
        {
            set
            {
                _client = value;
                RaisePropertyChanged("ClientName");
            }
            get
            {
                return _client;
            }
        }

        /// <summary>
        ///  Set or Get the contract name.
        /// </summary>
        [Display(Name = "Contracto", Description = "Numero Contracto")]
        public string InvoiceContract
        {
            set
            {
                _contract = value;
                RaisePropertyChanged("InvoiceContract");
            }
            get
            {
                return _contract;
            }
        }

        /// <summary>
        ///  Get or Set the date.
        /// </summary>
        [Display(Name = "Fecha", Description = "Fecha Factura")]
        public DateTime InvoiceDate
        {
            set
            {
                _date = value;
                RaisePropertyChanged("InvoiceDate");
            }
            get
            {
                return _date;
            }
        }
        /// <summary>
        ///  Set or get the quota
        /// </summary>
        [Display(Name = "Cuota", Description = "Cuota")]
        public double InvoiceFee
        {
            set
            {
                _fee = value;
                RaisePropertyChanged("InvoiceFee");
            }
            get
            {
                return _fee;
            }
        }

        /// <summary>
        ///  Get or Set the base
        /// </summary>
        [Display(Name = "Base", Description = "Base")]
        public double InvoiceBase
        {
            set
            {
                _base = value;
                RaisePropertyChanged("InvoiceBase");

            }
            get
            {
                return _base;

            }
        }

        /// <summary>
        ///  set or get the total
        /// </summary>
        [Display(Name = "Total", Description = "Total")]
        public double TotalInvoice
        {
            set
            {
                _total = value;
                RaisePropertyChanged("TotalInvoice");
            }
            get
            {
                return _total;
            }
        }

        /// <summary>
        ///  Set or Get the company name.
        /// </summary>
        [Display(Name = "Empresa", Description = "Nombre Impresa")]
        public string CompanyName
        {
            set
            {
                _name = value;
                RaisePropertyChanged("CompanyName");
            }
            get
            {
                return _name;
            }
        }
        
        /// <summary>
        ///  Set or Get the office
        /// </summary>
        [Display(Name = "Oficina", Description = "Oficina")]
        public string OfficeCode
        {
            set
            {
                _office = value;
                RaisePropertyChanged("OfficeCode");
            }
            get
            {
                return _office;
            }
        }
        /// <summary>
        ///  Set or get the type
        /// </summary>
        [Display(Name = "Tipo", Description = "Tipo")]
        public string InvoiceType
        {
            set
            {
                _type = value;
                RaisePropertyChanged("InvoiceType");
            }
            get
            {
                return _type;
            }
        }
        /// <summary>
        ///  set or get the number
        /// </summary>
        [Display(Name = "Asiento", Description = "Asiento")]
        public string Seat
        {
            set
            {
                _number = value;
                RaisePropertyChanged("Seat");

            }
            get
            {
                return _number;
            }
        }

        /// <summary>
        ///  Equality creation.
        /// </summary>
        /// <param name="other">Comparision invoice value data transfer object</param>
        /// <returns>Return true or false</returns>
        public bool Equals(InvoiceSummaryValueDto other)
        {
            var equality = (this.InvoiceCode == other.InvoiceCode) &&
                                (this.InvoiceBase == other.InvoiceBase)
                            && (this.ClientName == other.ClientName)
                            && (this.CompanyName == other.CompanyName)
                            && (this.InvoiceContract == other.InvoiceContract)
                            && (this.InvoiceDate == other.InvoiceDate)
                            && (this.InvoiceFee == other.InvoiceFee)
                            && (this.InvoiceCode == other.InvoiceCode)
                            && (this.InvoiceName == other.InvoiceName)
                            && (this.TotalInvoice == other.TotalInvoice)
                            && (this.OfficeCode == other.OfficeCode)
                            && (this.InvoiceType == other.InvoiceType)
                            && (this.Seat == other.Seat);
            return equality;
                           
        }
    }
}
