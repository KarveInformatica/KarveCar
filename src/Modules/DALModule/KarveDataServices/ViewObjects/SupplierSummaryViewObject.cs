using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    public class SupplierSummaryViewObject: BaseViewObject
    {
        private string _code;
        private string _name;
        private string _nif;

        [Display(Name = "Codigo Provveedor")]
        public string Codigo {
            get { return _code;  }
            set { _code = value; RaisePropertyChanged(); }
        }
        [Display(Name = "Nombre Provveedor")]
        public string Nombre
        {
            get { return _name;  }
            set { _name = value; RaisePropertyChanged(); }
        }
        [Display(Name = "Nif")]

        public string Nif {
            get
            {
                return _nif;
            }
            set {
                _nif = value;
                RaisePropertyChanged();
            }
        }
        [Display(Name = "Proveedor")]
        public string Proveedor { get; set; }

        [Display(Name = "Comercial")]
        public string Comercial { get; set; }

        ///  Set or get the TELEFONO property.

        [Display(Name = "Telefono")]
 
        public string Telefono { get; set; }
        /// <summary>
        ///  Set or get the DIRECCION property.
        /// </summary>

        public string Direccion { get; set; }


        /// <summary>
        ///  Set or get the CP property.
        /// </summary>

        public string CP { get; set; }

        /// <summary>
        ///  Set or get the POBLACION property.
        /// </summary>

        public string Poblacion { get; set; }



        /// <summary>
        ///  Set or get the PROV property.
        /// </summary>

        public string Provincia { get; set; }


        /// <summary>
        ///  AEAT
        /// </summary>

        public DateTime? AEAT { get; set; }


        // cuenta gasto.
        public string Contable { get; set; }
        /// <summary>
        ///  Set or get the DIREC2 property.
        /// </summary>

        public string Direccion2 { get; set; }
 
        // cuenta gasto.
        public string CuentaGasto { get; set; }

       
    }
}
