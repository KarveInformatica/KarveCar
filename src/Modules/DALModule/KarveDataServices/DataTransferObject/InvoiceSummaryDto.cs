using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  InvoiceSummaryDto.
    /// </summary>
    public class InvoiceSummaryDto: BaseDto
    {
        private string _agreementCode;
        private string _vehicleCode;
        private int _opciones;
        private string _description;
        private decimal? _quantity;
        private long _price;
        private decimal? _discount;
        private decimal? _subtotal;
        private string _unity;
        private string _fileNumber;
        private decimal? _iva;
        private string _number;

        [Display(Name = "Contracto", Description = "Codigo de Contracto")]
        public string AgreementCode
        {
            set
            {
                _agreementCode = value;
                RaisePropertyChanged("AgreementCode");
            }
            get => _agreementCode;
        }
        
        [Display(Name = "Vehiculo", Description = "Codigo de Vehiculo")]
        public string VehicleCode
        {
            set
            {
                _vehicleCode = value;
                RaisePropertyChanged("Vehiculo");
            }
            get => _vehicleCode;
        }
        [Display(Name = "Concepto", Description = "Concessine")]
        public int Opciones {
            set
            {
                _opciones = value;
                RaisePropertyChanged("Concessione");
            }
            get => _opciones;
        }
        [Display(Name = "Descripcion", Description = "Description")]
        public string Description
        {
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
            get => _description;
        }
        [Display(Name = "Cantidad", Description = "Cantidad")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal? Quantity
        {
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");
                RaisePropertyChanged("Subtotal");
            }
            get => _quantity;
        }
        [Display(Name = "Precio", Description = "Precio")]
        public long Price
        {
            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
            get => _price;
        }
        [Display(Name = "Descuento", Description = "Descuento")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal? Discount
        {
            set
            {
                _discount = value;
                RaisePropertyChanged("Discount");
                RaisePropertyChanged("Subtotal");
            }
            get => _discount;
        }


        [Display(Name = "Iva", Description = "Iva")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal? Iva
        {
            set
            {
                _iva = value;
                RaisePropertyChanged("Iva");
            }
            get => _iva;
        }
        [Display(Name = "Subtotal", Description = "Subtotal")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [ReadOnly(true)]
        public decimal? Subtotal
        {
            set
            {
                _subtotal = value;
                RaisePropertyChanged();
            }
            get
            {
                _subtotal = ((Quantity * 100) * ((100 - Discount) / 100)) * Price; 
                return _subtotal;
            }
        }

        [Display(Name = "Unidad", Description = "Unidad")]
        public string Unity
        {
            set
            {
                _unity = value;
                RaisePropertyChanged();
            }
            get => _unity;
        }
        [Display(Name = "Expediente", Description = "Expendiente")]
        public string FileNumber
        {
            set
            {
                _fileNumber = value;
                RaisePropertyChanged("FileNumber");
            }
            get => _fileNumber;
        }
        [Required]
        [Display(Name = "NumeroLinea", Description = "NumeroLinea")]
        public string Number
        {
            set
            {
                _number = value; RaisePropertyChanged();

            }
            get => _number;

        }
    }

}
