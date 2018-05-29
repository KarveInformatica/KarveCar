
using System.Collections.Generic;
using KarveDataServices.DataObjects;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Model
{
    /// <summary>
    /// This is an object for the invoice.
    /// </summary>
    public class Invoice : DomainObject, IInvoiceData, InvoiceComponent
    {
        private string _code;
        private IEnumerable<InvoiceSummaryDto> _invoiceItems = new List<InvoiceSummaryDto>();
        private IEnumerable<VehicleSummaryDto> _vehicleSummary = new List<VehicleSummaryDto>();
        private IEnumerable<ContractDto> _contractSummary = new List<ContractDto>();
        private IEnumerable<ClientSummaryExtended> _clientSummary = new List<ClientSummaryExtended>();
        private IEnumerable<InvoiceSummaryValueDto> _invoiceSummaryValues = new List<InvoiceSummaryValueDto>();

        /// <summary>
        /// Invoice constructoe
        /// </summary>
        /// <param name="code">Code of the invoice</param>
        /// <param name="value">Value of the invoice</param>
        public Invoice(string code, InvoiceDto value)
        {
            this._code = code;
            Value = value;
            InvoiceItems = value?.InvoiceItems;
        }
        /// <summary>
        ///  Return the value of the invoice dto.
        /// </summary>
        public InvoiceDto Value { get ; set ; }

        /// <summary>
        ///  Returns the list of invoice items.
        /// </summary>
        public IEnumerable<InvoiceSummaryDto> InvoiceItems
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
        public IEnumerable<VehicleSummaryDto> VehicleSummary
        {
            get => _vehicleSummary;
            set
            {
                _vehicleSummary = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<ContractDto> ContractSummary
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

        public IEnumerable<InvoiceSummaryValueDto> InvoiceSummary
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
