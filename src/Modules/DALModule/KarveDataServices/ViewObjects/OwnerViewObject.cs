using EmailValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    public class OwnerViewObject: BaseViewObject
    {

        public bool IsInvalid()
        {
            if ((Nombre != null) && (Nombre.Length > 150))
            {
                ErrorList.Add(ConstantDataError.NameTooLong);
                return true;
            }
            if (EMail != null)
            {
                var email = EmailValidator.Validate(EMail);
                if (!email)
                {
                    ErrorList.Add(ConstantDataError.InvalidEmail);
                }
                return true;
            }
            return false;
        }

        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
        /// <summary>
        ///  Set or get the NUM_PROPIE property.
        /// </summary>

        public string Codigo { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>

        public string Nombre { get; set; }

        /// <summary>
        ///  Set or get the DIRECCION property.
        /// </summary>

        public string Direccion { get; set; }
  
        /// <summary>
        ///  Set or get the POBLACION property.
        /// </summary>

        public string Poblacion { get; set; }
        /// <summary>
        ///  codigo postal
        /// </summary>
        public string CP { get; set; }


        public string Provincia { get; set;}
        /// <summary>
        ///  Set or get the NIF property.
        /// </summary>

        public string NIF { get; set; }

        /// <summary>
        ///  Set or get the TELEFONO property.
        /// </summary>

        public string Telefono { get; set; }

        /// <summary>
        /// Fax
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        ///  Set or get the EMAIL property.
        /// </summary>
        public string EMail { get; set; }
    }
}
