using System;
using KarveDapper.Extensions;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    /// Represents a CATEGO.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    [Table("CATEGO")]
    public class CATEGO 
	{

        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>
        [Key]
        [PrimaryKey]
        public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the NUMNEU_LC property.
    /// </summary>
    
		public Int16? NUMNEU_LC { get; set; }
 
	/// <summary>
    ///  Set or get the ESVEHICULO_T property.
    /// </summary>
    
		public byte? ESVEHICULO_T { get; set; }
 
	/// <summary>
    ///  Set or get the ORDEN property.
    /// </summary>
    
		public byte? ORDEN { get; set; }
 
	/// <summary>
    ///  Set or get the NOMWEB property.
    /// </summary>
    
		public string NOMWEB { get; set; }
 
	/// <summary>
    ///  Set or get the DIAS_MARGEN property.
    /// </summary>
    
		public Int32? DIAS_MARGEN { get; set; }
 
	/// <summary>
    ///  Set or get the INFREV property.
    /// </summary>
    
		public string INFREV { get; set; }
 
	/// <summary>
    ///  Set or get the MESES_GARANTIA property.
    /// </summary>
    
		public Int16? MESES_GARANTIA { get; set; }
	}
}
