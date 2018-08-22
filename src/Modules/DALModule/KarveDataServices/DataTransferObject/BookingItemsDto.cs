using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{

    /// <summary>
    /// BookingItems Data Transfer Object.
    /// </summary>
    public class BookingItemsDto: BaseDto
    {
        private int _concept;
        private string _descr;
        private int? _quantity;
        private decimal? _subtotal;
        private decimal? _price;
        private decimal? _discount;
        private int _billTo;
        private bool _conceptIncluded;
        private string _unity;
        private string _fare;
        private string _group;
        private string _number;
        private short? _extra;
        private int _min;
        private int _max;
        private string _days;
        private byte? _type;
        private string _money;
        private decimal? _iva;
        private long _bookingKey;
        private string _machine;
        private decimal? _unityCost;
        private decimal? _cost;
        private decimal? _totalPrice;
        private decimal? _subtotalTt;
        private decimal? _taxablePrice;
        private decimal? _taxableSubtotal;
        private byte? _multipleQuote;

        public BookingItemsDto()
        {
            Quantity = 0;
            Min = 0;
            Max = 0;
            Quantity = 0;
            Subtotal = 0;
            Iva = 21;
            Discount = 0;
            Included = false;

        }
        /// <summary>
        ///  Set or get the TARIFA property.
        /// </summary>

        public string Fare
        {
            get
            {
                return _fare;
            }
            set
            {
                _fare = value;
                RaisePropertyChanged("Fare");
            }
        }

        /// <summary>
        ///  Set or get the GRUPO property.
        /// </summary>

        public string Group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
                RaisePropertyChanged("Group");
            }
        }

        /// <summary>
        ///  Set or get the CONCEPTO property.
        /// </summary>
        [Display(Name = "Concepto")]
        [Required(ErrorMessage = "El Concepto esta requirido")]
        public Int32 Concept {
            get
            {
                return _concept;
            }
            set
            {
                _concept = value;
                RaisePropertyChanged("Concept");
            }
        }
        ///  [Display(Name = "Contracto", Description = "Codigo de Contracto")]
        /// <summary>
        ///  Set or get the DESCCON property.
        /// </summary>
        [Required(ErrorMessage = "La Descripción esta requirida")]
        [Display(Name = "Descripción Concepto")]
        public
            string Desccon
        {
            get
            {
                return _descr;
            }
            set
            {
                _descr = value;
                RaisePropertyChanged("Desccon");
            }
        }
        /// <summary>
        ///  Set or get the INCLUIDO property.
        /// </summary>
        [Display(Name = "Incluido")]
        public bool Included
        {

            get
            {
                return _conceptIncluded;
            }
           set
            {
                _conceptIncluded = value;
                RaisePropertyChanged("Included");
            }
        }

        /// <summary>
        ///  Set or get the CANTIDAD property.
        /// </summary>
        [Display(Name = "Cantidad")]
        public Int32? Quantity {
            get
            {
                return _quantity;
            }
            set
            {
                if (value != null)
                {
                    _quantity = value;
                    ComputeSubtotal();
                }
                RaisePropertyChanged("Quantity");
            }
        }
        private void ComputeSubtotal()
        {
            var tot = _quantity * Price;
            var descImport = (tot * Discount) / 100;
            Subtotal = tot - descImport;

        }

        /// <summary>
        ///  Set or get the UNIDAD property.
        /// </summary>
        [Display(Name = "Unidad")]
        public string Unity {
            get
            {
                return _unity;
            }
            set
            {
                _unity = value;
                RaisePropertyChanged("Unity");
            }
        }

        /// <summary>
        ///  Set or get the PRECIO property.
        /// </summary>
        [Display(Name = "Precio")]
        public Decimal? Price {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                ComputeSubtotal();
                RaisePropertyChanged("Price");
            }
        }
        /// <summary>
        ///  Set or get the DTO property.
        /// </summary>
        [Display(Name = "Descuento")]
        public Decimal? Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                ComputeSubtotal();
                RaisePropertyChanged("Discount");
            }
        }
        /// <summary>
        ///  Set or get the SUBTOTAL property.
        /// </summary>
        [Display(Name = "Subtotal")]
        public Decimal? Subtotal {
            get
            {
                return _subtotal;
            }

            set
            {
                _subtotal = value;
                RaisePropertyChanged("Subtotal");
            }
        }

        /// <summary>
        ///  Set or get the FACTURAR property.
        /// </summary>
        [Display(Name = "Facturar a")]
        public int Bill
        {
            get
            {
                return _billTo;
            }
            set
            {
                _billTo = value;
                RaisePropertyChanged("Bill");
            }
        }

        /// <summary>
        ///  Set or get the NUMERO property.
        /// </summary>
        [Display(Name = "Numero")]
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                RaisePropertyChanged("Number");
            }
        }

        /// <summary>
        ///  Set or Get the EXTRA property.
        /// </summary>
        [Display(Name = "Extra")]
        public Int16? Extra
        {
            get
            {
                return _extra;
            }
            set
            {
                _extra = value;
                RaisePropertyChanged("Extra");
            }
        }



        [Display(Name="Minimo")]
        public Int32 Min
        {
            set
            {
                _min = value;
                RaisePropertyChanged("Min");
            }
            get
            {
                return _min;
            }
        }

        [Display(Name="Max")]
        public Int32 Max
        {
            set
            {
                _max = value;
                RaisePropertyChanged("Max");
            }
            get
            {
                return _max;
            }
        }



        /// <summary>
        /// Set or Get the number of days.
        /// </summary>
        [Display(Name = "Dias")]
        public string Days {
            get
            {
                return _days;
            }
            set
            {
                _days = value;
                RaisePropertyChanged("Days");
            }
        }
        /// <summary>
        ///  Set or get the Type property.
        /// </summary>
        [Display(Name = "Tipo")]

        public byte? Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                RaisePropertyChanged("Type");
            }
        }

        /// <summary>
        ///  Set or get the MONEDA property.
        /// </summary>
        [Display(Name = "Moneda")]
        public string Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
                RaisePropertyChanged("Money");

            }
        }

        /// <summary>
        ///  Set or get the IVA property.
        /// </summary>
        [Display(Name ="Iva")]
        public Decimal? Iva {
            get
            {
                return _iva;
            }
            set
            {
                _iva = value;
                RaisePropertyChanged("Iva");
            }
        }

        /// <summary>
        ///  Set or get the BookingKey.
        /// </summary>

        public Int64 BookingKey
        {
            get
            {
                return _bookingKey;
            }
            set
            {
                _bookingKey = value;
            }
        }

        /// <summary>
        ///  Set or get the MAQUINA property.
        /// </summary>

        public string Machine
        {
            get
            {
                return _machine;
            }
            set
            {
                _machine = value;
                RaisePropertyChanged("Machine");
            }
        }

        /// <summary>
        ///  Set or get the COSTEU property.
        /// </summary>
        [Display(Name ="Costo Unitario")]
        public Decimal? UnityCost
        {
            get
            {
                return _unityCost;
            }
            set
            {
                _unityCost = value;
                RaisePropertyChanged("UnityCost");
            }
        }

        /// <summary>
        ///  Set or get the COSTE property.
        /// </summary>
        [Display(Name = "Costo")]
        public Decimal? Cost {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
                RaisePropertyChanged("Cost");
            }
        }

        /// <summary>
        ///  Set or get the PRECIO_TT property.
        /// </summary>
        [Display(Name = "Precio Total")]
        public Decimal? TotalPriceTT
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
                RaisePropertyChanged("TotalPriceTT");
            }
        }

        /// <summary>
        ///  Set or get the SUBTOTAL_TT property.
        /// </summary>
        [Display(Name = "Precio Subtotal")]

        public Decimal? SubtotalTt
        {   get
            {
                return _subtotalTt;
            }
            set
            {
                _subtotalTt = value;
                RaisePropertyChanged("SubtotalTt");
            }
        }

        /// <summary>
        ///  Set or get the PRECIO_IMP property.
        /// </summary>
        [Display(Name = "Precio Imponible")]

        public Decimal? TaxablePrice
        {
            get
            {
                return _taxablePrice;
            }
            set
            {
                _taxablePrice = value;
                RaisePropertyChanged("TaxablePrice");
            }
        }

        /// <summary>
        ///  Set or get the SUBTOTAL_IMP property.
        /// </summary>
        [Display(Name = "Precio Imponible Subtotal")]

        public Decimal? TaxableSubtotal
        {
            get
            {
                return _taxableSubtotal;
            }
            set
            {
                _taxableSubtotal = value;
                RaisePropertyChanged("TaxableSubtotal");
            }
        }

        /// <summary>
        ///  Set or get the COT_MULTI property.
        /// </summary>

        public byte? MultipleQuote
        {
            get
            {
                return _multipleQuote;
            }
            set
            {
                _multipleQuote = value;
                RaisePropertyChanged("MultipleQuote");
            }
        }

      
    }
}
