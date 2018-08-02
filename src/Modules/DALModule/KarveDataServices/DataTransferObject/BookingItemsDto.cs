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

        public BookingItemsDto()
        {
            Quantity = 0;
            Min = 0;
            Max = 0;
            Quantity = 0;
            Subtotal = 0;
            Iva = 21;
            Discount = 0;
        }
        /// <summary>
        ///  Set or get the TARIFA property.
        /// </summary>

        public string Fare { get; set; }

        /// <summary>
        ///  Set or get the GRUPO property.
        /// </summary>

        public string Group { get; set; }

        /// <summary>
        ///  Set or get the CONCEPTO property.
        /// </summary>
        [Display(Name = "Concepto")]

        public Int32 Concept {
            get
            {
                return _concept;
            }
            set
            {
                _concept = value;
                RaisePropertyChanged();
            }
        }
        ///  [Display(Name = "Contracto", Description = "Codigo de Contracto")]
        /// <summary>
        ///  Set or get the DESCCON property.
        /// </summary>
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
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Set or get the INCLUIDO property.
        /// </summary>
        [Display(Name = "Incluido")]
        public bool Included
        {
            get; set;
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
                RaisePropertyChanged();
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
        public string Unity { get; set; }

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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  Set or get the NUMERO property.
        /// </summary>
        [Display(Name = "Numero")]
        public string Number { get; set; }

        /// <summary>
        ///  Set or Get the EXTRA property.
        /// </summary>
        [Display(Name = "Extra")]
        public Int16? Extra { get; set; }



        [Display(Name="Minimo")]
        public Int32 Min { set; get; }

        [Display(Name="Max")]
        public Int32 Max { set; get; }



        /// <summary>
        /// Set or Get the number of days.
        /// </summary>
        [Display(Name = "Dias")]
        public string Days { get; set; }
        /// <summary>
        ///  Set or get the Type property.
        /// </summary>
        [Display(Name = "Tipo")]

        public byte? Type { get; set; }

        /// <summary>
        ///  Set or get the MONEDA property.
        /// </summary>
        public string Money { get; set; }

        /// <summary>
        ///  Set or get the IVA property.
        /// </summary>
        [Display(Name ="Iva")]
        public Decimal? Iva { get; set; }

        /// <summary>
        ///  Set or get the BookingKey.
        /// </summary>

        public Int64 BookingKey { get; set; }

        /// <summary>
        ///  Set or get the MAQUINA property.
        /// </summary>

        public string Machine { get; set; }

        /// <summary>
        ///  Set or get the COSTEU property.
        /// </summary>
        [Display(Name ="Costo Unitario")]
        public Decimal? UnityCost { get; set; }

        /// <summary>
        ///  Set or get the COSTE property.
        /// </summary>
        [Display(Name = "Costo")]
        public Decimal? Cost { get; set; }

        /// <summary>
        ///  Set or get the PRECIO_TT property.
        /// </summary>

        public Decimal? TotalPriceTT { get; set; }

        /// <summary>
        ///  Set or get the SUBTOTAL_TT property.
        /// </summary>

        public Decimal? SubtotalTt { get; set; }

        /// <summary>
        ///  Set or get the PRECIO_IMP property.
        /// </summary>

        public Decimal? TaxablePrice { get; set; }

        /// <summary>
        ///  Set or get the SUBTOTAL_IMP property.
        /// </summary>

        public Decimal? TaxableSubtotal { get; set; }

        /// <summary>
        ///  Set or get the COT_MULTI property.
        /// </summary>

        public byte? MultipleQuote { get; set; }

      
    }
}
