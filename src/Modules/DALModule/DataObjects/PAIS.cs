using System;
using System.ComponentModel;
using KarveDapper.Extensions;
using KarveDataServices.DataObjects;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PAIS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("PAIS")]
	public class Country
	{
	
	/// <summary>
    ///  Set or get the SIGLAS property.
    /// </summary>
        [Key]
        [FieldSize("3")]
		public string SIGLAS { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>
        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>
        public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the PAIS property.
    /// </summary>
    
		public string PAIS { get; set; }

        /// <summary>
        ///  Set or get the INTRACO property.
        /// </summary>
        public byte? INTRACO { get; set; }

        /// <summary>
        ///  Set or get the IDIOMA_PAIS property.
        /// </summary>
        public byte? IDIOMA_PAIS { get; set; }

        /// <summary>
        ///  Set or get the NOM_INGLES property.
        /// </summary>
        public string NOM_INGLES { get; set; }

        /// <summary>
        ///  Set or get the SIGLASTEXTO property.
        /// </summary>
        public string SIGLASTEXTO { get; set; }

        /// <summary>
        ///  Set or get the RESTO_EUR property.
        /// </summary>
        public byte? RESTO_EUR { get; set; }

        /// <summary>
        ///  Set or get the RESTO_AMERICA property.
        /// </summary>
        public byte? RESTO_AMERICA { get; set; }

        /// <summary>
        ///  Set or get the AFRICA property.
        /// </summary>
        public byte? AFRICA { get; set; }

        /// <summary>
        ///  Set or get the SIGLAS3 property.
        /// </summary>
        public string SIGLAS3 { get; set; }

        /// <summary>
        ///  Set or get the IDIOMA_PS property.
        /// </summary>
        public Int32? IDIOMA_PS { get; set; }

        /// <summary>
        ///  Set or get the CURRENCY_PS property.
        /// </summary>

        public string CURRENCY_PS { get; set; }

        /// <summary>
        ///  Set or get the PRIORIDAD_WEB property.
        /// </summary>
        public Int32? PRIORIDAD_WEB { get; set; }
   }
}
