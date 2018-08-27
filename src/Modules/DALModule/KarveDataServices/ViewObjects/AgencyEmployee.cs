using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  Agency employee data.
    /// </summary>
    public class AgencyEmployeeViewObject: BaseViewObject
    { 
        /// <summary>
        ///  Set or get the NUM_EAGE property.
        /// </summary>

        [Display(Name="Numero Agencia")]

        public string NUM_EAGE { get; set; }

        /// <summary>
        ///  Set or get the AGENCIA property.
        /// </summary>
        [Display(Name = "Agencia")]

        public string AGENCIA { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Display(Name = "Nombre")]

        public string NOMBRE { get; set; }

        /// <summary>
        ///  Set or get the DNI property.
        /// </summary>
        [Display(Name = "DNI")]

        public string DNI { get; set; }

        /// <summary>
        ///  Set or get the DIRECCION property.
        /// </summary>
        [Display(Name = "Dirección")]

        public string DIRECCION { get; set; }

        /// <summary>
        ///  Set or get the POBLACION property.
        /// </summary>
        [Display(Name = "Población")]

        public string POBLACION { get; set; }

        /// <summary>
        ///  Set or get the PROVINCIA property.
        /// </summary>
        [Display(Name = "Provincia")]

        public string PROVINCIA { get; set; }

        /// <summary>
        ///  Set or get the CP property.
        /// </summary>
        [Display(Name = "Codigo Postal")]

        public string CP { get; set; }

        /// <summary>
        ///  Set or get the OBS1 property.
        /// </summary>
        [Display(Name = "Observaciones")]

        public string OBS1 { get; set; }

        /// <summary>
        ///  Set or get the TELEFONO property.
        /// </summary>
        [Display(Name = "Telefono")]

        public string TELEFONO { get; set; }

        /// <summary>
        ///  Set or get the NACIOPER property.
        /// </summary>

        public string NACIOPER { get; set; }

        /// <summary>
        ///  Set or get the NACIODOMI property.
        /// </summary>

        public string NACIODOMI { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>
        [Display(Name = "LastModification")]

        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>
        [Display(Name = "CurrentUser")]

        public string USUARIO { get; set; }

        /// <summary>
        ///  Set or get the FAX property.
        /// </summary>

        public string FAX { get; set; }

        /// <summary>
        ///  Set or get the COORDGPS property.
        /// </summary>

        public string COORDGPS { get; set; }

        /// <summary>
        ///  Set or get the MOVIL2 property.
        /// </summary>

        public string MOVIL2 { get; set; }
    }
}
