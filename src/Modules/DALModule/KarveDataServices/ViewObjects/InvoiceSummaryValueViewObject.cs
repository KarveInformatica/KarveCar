using Syncfusion.Windows.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  This class is resposible for showing the values of all invoices present in the system.
    /// </summary>
    
    public class InvoiceSummaryValueViewObject : BaseViewObject, IEquatable<InvoiceSummaryValueViewObject>
    {
        private string _invoiceCode;
        private string _client;
        private string _contract;
        private DateTime _date;
        private double _base;
        private double _fee;
        private double _total;
        private string _company;
        private string _office;
        private string _type;
        private string _number;
        private string _invoiceName;
        private string _invoiceSerie;
        private string _invoiceRef;
       // private string _amountTotal;

        /// <summary>
        ///  Set or Get the InvoiceCode.
        /// </summary>
        [Display(Name = "Num.Factura", Description = "Numero Factura")]
        public string InvoiceName
        {
            set { _invoiceName = value;
               
                RaisePropertyChanged("InvoiceName"); }
            get => _invoiceName;
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
            get => _invoiceCode;
        }
        /// <summary>
        ///  Set or Get the Client name.
        /// </summary>
        [Display(Name = "Cliente", Description = "Nombre de Cliente")]
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
        /// </summary>
        ///
       /*
        [Display(Name = "TI", Description = "Total Importe")]
        public string TotalImporte
        {
            set
            {
                _amountTotal = value;
                RaisePropertyChanged("AmountTotal");
            }
            get => _amountTotal;
        }
        */
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
                _company = value;
                RaisePropertyChanged("CompanyName");
            }
            get
            {
                return _company;
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
        public bool Equals(InvoiceSummaryValueViewObject other)
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
