
using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.DtoWrapper
{
    /// <summary>
    ///  Invoice wrapper.
    /// </summary>
    public class Invoice : DomainObject, IInvoiceData, InvoiceComponent
    {
        private string _code;
        private IEnumerable<InvoiceSummaryViewObject> _invoiceItems = new List<InvoiceSummaryViewObject>();
        private IEnumerable<VehicleSummaryViewObject> _vehicleSummary = new List<VehicleSummaryViewObject>();
        private IEnumerable<ContractViewObject> _contractSummary = new List<ContractViewObject>();
        private IEnumerable<ClientSummaryExtended> _clientSummary = new List<ClientSummaryExtended>();
        private IEnumerable<InvoiceSummaryValueViewObject> _invoiceSummaryValues = new List<InvoiceSummaryValueViewObject>();

        /// <summary>
        /// Invoice constructoe
        /// </summary>
        /// <param name="code">Code of the invoice</param>
        /// <param name="value">Value of the invoice</param>
        public Invoice(string code, InvoiceViewObject value)
        {
            this._code = code;
            Value = value;
            InvoiceItems = value?.InvoiceItems;
        }
        /// <summary>
        ///  Return the value of the invoice dto.
        /// </summary>
        public InvoiceViewObject Value { get ; set ; }

        /// <summary>
        ///  Returns the list of invoice items.
        /// </summary>
        public IEnumerable<InvoiceSummaryViewObject> InvoiceItems
        {
            set {
                _invoiceItems = value;
                if (Value != null)
                {
                    Value.InvoiceItems = value;
                }
                 RaisePropertyChanged();

            }
           
            get => _invoiceItems;
        }
        /// <summary>
        ///  Returns the list of vehicle.
        /// </summary>
        public IEnumerable<VehicleSummaryViewObject> VehicleSummary
        {
            get => _vehicleSummary;
            set
            {
                _vehicleSummary = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ContractViewObject> ContractSummary
        {
            get => _contractSummary;
            set
            {
                _contractSummary = value; 
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ClientSummaryExtended> ClientSummary
        {
            get => _clientSummary;
            set
            {
                _clientSummary = value; 
                RaisePropertyChanged();
            }
        }

        public IEnumerable<InvoiceSummaryValueViewObject> InvoiceSummary
        {
            get => _invoiceSummaryValues;
            set
            {
                _invoiceSummaryValues = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  Set or Get the subtotal
        /// </summary>
        public decimal Subtotal { get; set; }
        /// <summary>
        ///  Set or Get the cost.
        /// </summary>
        public decimal Coste { get; set; }
        /// <summary>
        ///  Set or Get the Iva.
        /// </summary>
        public decimal Iva { get; set; }
        /// <summary>
        ///  Set or Get the quantity.
        /// </summary>
        public decimal Cantidad { get; set; }
        /// <summary>
        ///  Set or Get the number of invoice.
        /// </summary>
        public int NumberOfLines { get; set; }
        /// <summary>
        ///  Set or Get the number of clients.
        /// </summary>
        public int NumberOfClients { get; set; }
        /// <summary>
        /// Set or Get the number of invoices.
        /// </summary>
        public int NumberOfInvoices { get ; set ; }
    }
}
