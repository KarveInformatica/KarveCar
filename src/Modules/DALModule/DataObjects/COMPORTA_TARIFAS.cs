using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a COMPORTA_TARIFAS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class COMPORTA_TARIFAS 
	{
	
	/// <summary>
    ///  Set or get the NTARI property.
    /// </summary>
    
		public string NTARI { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public Int32 CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the MAXIMO property.
    /// </summary>
    
		public Decimal? MAXIMO { get; set; }
 
	/// <summary>
    ///  Set or get the MINIMO property.
    /// </summary>
    
		public Decimal? MINIMO { get; set; }
 
	/// <summary>
    ///  Set or get the IND_INCLUIDO property.
    /// </summary>
    
		public Int32? IND_INCLUIDO { get; set; }
 
	/// <summary>
    ///  Set or get the IND_FACTURAR property.
    /// </summary>
    
		public byte? IND_FACTURAR { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO property.
    /// </summary>
    
		public byte? TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE property.
    /// </summary>
    
		public Decimal? IMPORTE { get; set; }
 
	/// <summary>
    ///  Set or get the ACUMULA_ALQ property.
    /// </summary>
    
		public Int32? ACUMULA_ALQ { get; set; }
	}
}
