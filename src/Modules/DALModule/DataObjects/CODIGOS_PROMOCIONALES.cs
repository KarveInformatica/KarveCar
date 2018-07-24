using System;
using KarveDapper.Extensions;

 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CODIGOS_PROMOCIONALES.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("CODIGOS_PROMOCIONALES")]
	public class CODIGOS_PROMOCIONALES 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_PROMO property.
    /// </summary>
        [Key]
		public string CODIGO_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE_PROMO property.
    /// </summary>
    
		public string NOMBRE_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the DTO_PROMO property.
    /// </summary>
    
		public Decimal? DTO_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the ES_ALQUILER_PROMO property.
    /// </summary>
    
		public byte? ES_ALQUILER_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the ES_SEGURO_PROMO property.
    /// </summary>
    
		public byte? ES_SEGURO_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO_PROMO property.
    /// </summary>
    
		public Int32? CONCEPTO_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the DTO_FIJO_PROMO property.
    /// </summary>
    
		public Decimal? DTO_FIJO_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the FALTA_PROMO property.
    /// </summary>
    
		public DateTime? FALTA_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the FBAJA_PROMO property.
    /// </summary>
    
		public DateTime? FBAJA_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the OBS_PROMO property.
    /// </summary>
    
		public string OBS_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO_PROMO property.
    /// </summary>
    
		public string USUARIO_PROMO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI_PROMO property.
    /// </summary>
    
		public string ULTMODI_PROMO { get; set; }
	}
}
