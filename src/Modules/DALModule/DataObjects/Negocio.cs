using System;
using System.ComponentModel;
using KarveDapper.Extensions;
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a NEGOCIO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("NEGOCIO")]
	public class NEGOCIO 
	{

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>
       
        public string USUARIO { get; set; }

        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Key]
        public string CODIGO { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>
        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        public string NOMBRE { get; set; }
	}
}
