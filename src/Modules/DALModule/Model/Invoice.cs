
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
        private IEnumerable<ClientSummaryDto> _clientSummary = new List<ClientSummaryDto>();
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

        public IEnumerable<ClientSummaryDto> ClientSummary
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


        public decimal Subtotal { get; set; }
        public decimal Coste { get; set; }
        public decimal Iva { get; set; }
        public decimal Cantidad { get; set; }
    }
}
