using System;
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
        private long _vehicleCode;
        private long _opciones;
        private string _description;
        private string _quantity;
        private long _price;
        private decimal _discount;
        private long _subtotal;
        private string _unity;
        private string _fileNumber;

        [Display(Name = "Contracto", Description = "Codigo de Contracto")]
        public string AgreementCode
        {
            set
            {
                _agreementCode = value;
                RaisePropertyChanged("AgreementCode");
            }
            get
            {
                return _agreementCode;
            }
        }
        [Display(Name = "Vehiculo", Description = "Codigo de Vehiculo")]
        public long VehicleCode
        {
            set
            {
                _vehicleCode = value;
                RaisePropertyChanged("Vehiculo");
            }
            get
            {
                return _vehicleCode;
            }
        }
        [Display(Name = "Opciones", Description = "Codigo de Vehiculo")]
        public long Opciones {
            set
            {
                _opciones = value;
                RaisePropertyChanged("Opciones");
            }
            get
            {
                return _opciones;
            }
        }
        [Display(Name = "Descripcion", Description = "Description")]
        public string Description
        {
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
            }
            get
            {
                return _description;
            }
        }
        [Display(Name = "Cantidad", Description = "Cantidad")]
        public string Quantity
        {
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");
            }
            get
            {
                return _quantity;
            }
        }
        [Display(Name = "Precio", Description = "Precio")]
        public long Price
        {
            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
            get
            {
                return _price;
            }
        }
        [Display(Name = "Descuento", Description = "Descuento")]
        public Decimal Discount
        {
            set
            {
                _discount = value;
                RaisePropertyChanged("Discount");
            }
            get
            {
                return _discount;
            }
        }
        [Display(Name = "Subtotal", Description = "Subtotal")]
        public long Subtotal
        {
            set
            {
                _subtotal = value;
                RaisePropertyChanged("Subtotal");
            }
            get
            {
                return _subtotal;
            }
        }
        [Display(Name = "Unidad", Description = "Unidad")]
        public string Unity
        {
            set
            {
                _unity = value;
                RaisePropertyChanged("Unidad");
            }
            get
            {
                return _unity;
            }
        }
        [Display(Name = "Expediente", Description = "Expendiente")]
        public string FileNumber
        {
            set
            {
                _fileNumber = value;
                RaisePropertyChanged("FileNumber");
            }
            get
            {
                return _fileNumber;
            }
        }
    }

}
