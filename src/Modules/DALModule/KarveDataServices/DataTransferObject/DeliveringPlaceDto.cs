using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{

    public class DeliveringPlaceDto: BaseDto
    {
        private int _codigo;

        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Display(Name = "Codigo")]
        public Int32 CODIGO
        {
            get
            {
               return _codigo;
            }
            set

            {
                Code = _codigo.ToString(); 
                _codigo = value;
            }
        }
        /// <summary>
        ///  Set or get the LUGAR property.
        /// </summary>
        [Display(Name = "Lugar")]

        public string LUGAR { get; set; }


        /// <summary>
        ///  Set or get the OFICINA property.
        /// </summary>
        [Display(Name = "Oficina")]

        public string OFICINA { get; set; }

       
        /// <summary>
        ///  Set or get the PRECIO property.
        /// </summary>
        [Display(Name = "Precio")]
        public Decimal? PRECIO { get; set; }

        /// <summary>
        ///  Set or get the FALTA property.
        /// </summary>
        [Display(Name = "Fecha de alta")]

        public DateTime? FALTA { get; set; }

        /// <summary>
        ///  Set or get the FBAJA property.
        /// </summary>
        [Display(Name = "Fecha de baja")]

        public DateTime? FBAJA { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>

        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>

        public string USUARIO { get; set; }

        /// <summary>
        ///  Set or get the CALLE property.
        /// </summary>
        [Display(Name = "Calle")]
        public string CALLE { get; set; }

        /// <summary>
        ///  Set or get the NUM property.
        /// </summary>
        [Display(Name = "Numero")]
        public string NUM { get; set; }

        /// <summary>
        ///  Set or get the POBLACION property.
        /// </summary>
        [Display(Name = "Poblacion")]
        public string POBLACION { get; set; }

        /// <summary>
        ///  Set or get the CP property.
        /// </summary>
        [Display(Name = "CP")]
        public string CP { get; set; }

        /// <summary>
        ///  Set or get the CORDGPS property.
        /// </summary>
        [Display(Name = "CoordGPS")]
        public string CORDGPS { get; set; }

        /// <summary>
        ///  Set or get the COLORFONDO_LE property.
        /// </summary>

        public Int32? COLORFONDO_LE { get; set; }

        /// <summary>
        ///  Set or get the ALIAS property.
        /// </summary>
        public string ALIAS { get; set; }
        /// <summary>
        ///  Set or get the PRODUCTO property.
        /// </summary>
        public string PRODUCTO { get; set; }
        /// <summary>
        ///  Set or get the HORAS property.
        /// </summary>
        public Decimal? HORAS { get; set; }
    }
}
