using System;
using System.ComponentModel.DataAnnotations;


namespace KarveDataServices.DataTransferObject
{

    /// <summary>
    ///  Data transfer object fdro 
    /// </summary>
    public class ReservationRequestDto: BaseDto
    {

        /// <summary>
        ///  Set or get the NUMERO property.
        /// </summary>
        [Display(Name="Numero")]
        [Required]
        public string NUMERO { get; set; }

        /// <summary>
        ///  Set or get the FECHA property.
        /// </summary>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]

        public DateTime? FECHA { get; set; }

        /// <summary>
        ///  Set or get the VENDEDOR property.
        /// </summary>

        public string VENDEDOR { get; set; }

        /// <summary>
        ///  Set or get the SUBLICEN property.
        /// </summary>

        public string SUBLICEN { get; set; }

        /// <summary>
        ///  Set or get the CLIENTE property.
        /// </summary>

        public string CLIENTE { get; set; }

        /// <summary>
        ///  Set or get the CATEGO property.
        /// </summary>

        public string CATEGO { get; set; }

        /// <summary>
        ///  Set or get the OBS1 property.
        /// </summary>

        public string OBS1 { get; set; }

        /// <summary>
        ///  Set or get the DIAS property.
        /// </summary>

        public Int16? DIAS { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>

        public string ULTMODI { get { return base.LastModification;  } set { base.LastModification = value; } }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>

        public string USUARIO { get { return base.CurrentUser; } set { base.CurrentUser = value; } }

        /// <summary>
        ///  Set or get the MOPETI property.
        /// </summary>

        public string MOPETI { get; set; }

        /// <summary>
        ///  Set or get the OFICINA property.
        /// </summary>

        public string OFICINA { get; set; }

        /// <summary>
        ///  Set or get the ORIGEN property.
        /// </summary>

        public byte? ORIGEN { get; set; }

        /// <summary>
        ///  Set or get the FECHA_SERV property.
        /// </summary>

        public DateTime? FECHA_SERV { get; set; }

        /// <summary>
        ///  Set or get the OTRO_VEHI property.
        /// </summary>

        public string OTRO_VEHI { get; set; }

        /// <summary>
        ///  Set or get the NOMCLI property.
        /// </summary>

        public string NOMCLI { get; set; }

        /// <summary>
        ///  Set or get the TARIFA property.
        /// </summary>

        public string TARIFA { get; set; }

        /// <summary>
        ///  Set or get the FSAL property.
        /// </summary>

        public DateTime? FSAL { get; set; }

        /// <summary>
        ///  Set or get the FRET property.
        /// </summary>

        public DateTime? FRET { get; set; }

    }

}