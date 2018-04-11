using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
    [Table("CONTACTOS_COMI")]
    public class ContactsComiPoco
    {
        /// <summary>
        ///  Set or get the COMISIO property.
        /// </summary>

        public string COMISIO { get; set; }

        /// <summary>
        ///  Set or get the CONTACTO property.
        /// </summary>
        [Key]
        public Int32 CONTACTO { get; set; }

        /// <summary>
        ///  Set or get the NOM_CONTACTO property.
        /// </summary>

        public string NOM_CONTACTO { get; set; }

        /// <summary>
        ///  Set or get the NIF property.
        /// </summary>

        public string NIF { get; set; }

        /// <summary>
        ///  Set or get the CARGO property.
        /// </summary>

        public byte? CARGO { get; set; }

        /// <summary>
        ///  Set or get the TELEFONO property.
        /// </summary>

        public string TELEFONO { get; set; }

        /// <summary>
        ///  Set or get the MOVIL property.
        /// </summary>

        public string MOVIL { get; set; }

        /// <summary>
        ///  Set or get the FAX property.
        /// </summary>

        public string FAX { get; set; }

        /// <summary>
        ///  Set or get the EMAIL property.
        /// </summary>

        public string EMAIL { get; set; }

        /// <summary>
        ///  Set or get the OBSERVA property.
        /// </summary>

        public string OBSERVA { get; set; }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>

        public string USUARIO { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>

        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the NOM_CARGO property.
        /// </summary>

        public string NOM_CARGO { get; set; }

        /// <summary>
        ///  Set or get the ESVENDE property.
        /// </summary>

        public Int32? ESVENDE { get; set; }

        /// <summary>
        ///  Set or get the DELEGA_CC property.
        /// </summary>

        public Int32? DELEGA_CC { get; set; }
        /// <summary>
        ///  Set or get the COMISIO property.
        /// </summary>
        /// 
        public PERCARGOS percargos { set; get; }
        /// <summary>
        ///  delegations
        /// </summary>
	    public COMI_DELEGA comiDelega { set; get; }

        public int CargoId { set; get; }
        public string DelegaId { set; get; }
        
    }
}
