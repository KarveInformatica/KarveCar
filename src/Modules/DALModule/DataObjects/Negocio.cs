using System;
using System.ComponentModel;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a NEGOCIO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class NEGOCIO 
	{

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>
        [Browsable(false)]
        public string USUARIO { get; set; }

        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
       
        public string CODIGO { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>
        [Browsable(false)]
        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Browsable(false)]
        public string NOMBRE { get; set; }
	}
}
