using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{

    /// <summary>
    ///  Forma de pago viewObject.
    /// </summary>
    public class PaymentFormViewObject: BaseViewObject
    {
        private byte _code;
        private string _name;
        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Display(Name = "Codigo")]
        [Required]
        public byte Codigo
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                base.Code = _code.ToString();
            }
        }
        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Display(Name="Nombre")]
        public string Nombre
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                base.Name = _name;
            }
        }

        /// <summary>
        ///  Set or get the CUENTA property.
        /// </summary>

        public string Cuenta { get; set; }
        
    }
}
