using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a LIRESER.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	
	[Table("LIRESER")]
	public class LIRESER
    { 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
		public string ULTMODI { get; set; }
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the TARIFA property.
    /// </summary>
    
		public string TARIFA { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO property.
    /// </summary>
    
		public string GRUPO { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public Int32 CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the DESCCON property.
    /// </summary>
    
		public string DESCCON { get; set; }
 
	/// <summary>
    ///  Set or get the FACTURAR property.
    /// </summary>
    
		public byte? FACTURAR { get; set; }
 
	/// <summary>
    ///  Set or get the INCLUIDO property.
    /// </summary>
    
		public Int16? INCLUIDO { get; set; }
 
	/// <summary>
    ///  Set or get the CANTIDAD property.
    /// </summary>
    
		public Int32? CANTIDAD { get; set; }
 
	/// <summary>
    ///  Set or get the UNIDAD property.
    /// </summary>
    
		public string UNIDAD { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO property.
    /// </summary>
    
		public Decimal? PRECIO { get; set; }
 
	/// <summary>
    ///  Set or get the SUBTOTAL property.
    /// </summary>
    
		public Decimal? SUBTOTAL { get; set; }
 
	/// <summary>
    ///  Set or get the NUMERO property.
    /// </summary>
    
		public string NUMERO { get; set; }
 
	/// <summary>
    ///  Set or get the EXTRA property.
    /// </summary>
    
		public Int16? EXTRA { get; set; }
 
	/// <summary>
    ///  Set or get the DTO_SN property.
    /// </summary>
    
		public string DTO_SN { get; set; }
 
	/// <summary>
    ///  Set or get the DIAS property.
    /// </summary>
    
		public string DIAS { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO property.
    /// </summary>
    
		public byte? TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the MONEDA property.
    /// </summary>
    
		public string MONEDA { get; set; }
 
	/// <summary>
    ///  Set or get the IVA property.
    /// </summary>
    
		public Decimal? IVA { get; set; }
 
	/// <summary>
    ///  Set or get the CLAVE_LR property.
    /// </summary>
        [Key]
		public Int64 CLAVE_LR { get; set; }
 
	/// <summary>
    ///  Set or get the MAQUINA property.
    /// </summary>
    
		public string MAQUINA { get; set; }
 
	/// <summary>
    ///  Set or get the COSTEU property.
    /// </summary>
    
		public Decimal? COSTEU { get; set; }
 
	/// <summary>
    ///  Set or get the COSTE property.
    /// </summary>
    
		public Decimal? COSTE { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO_TT property.
    /// </summary>
    
		public Decimal? PRECIO_TT { get; set; }
 
	/// <summary>
    ///  Set or get the SUBTOTAL_TT property.
    /// </summary>
    
		public Decimal? SUBTOTAL_TT { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO_IMP property.
    /// </summary>
    
		public Decimal? PRECIO_IMP { get; set; }
 
	/// <summary>
    ///  Set or get the SUBTOTAL_IMP property.
    /// </summary>
    
		public Decimal? SUBTOTAL_IMP { get; set; }
 
	/// <summary>
    ///  Set or get the COT_MULTI property.
    /// </summary>
    
		public byte? COT_MULTI { get; set; }
 
	/// <summary>
    ///  Set or get the DTO property.
    /// </summary>
    
		public Decimal? DTO { get; set; }
	}
}
