using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a TARIFIJOGRUPO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class TARIFIJOGRUPO 
	{
	
	/// <summary>
    ///  Set or get the NTARI_TFG property.
    /// </summary>
    
		public string NTARI_TFG { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO_TFG property.
    /// </summary>
    
		public string GRUPO_TFG { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO_TFG property.
    /// </summary>
    
		public Int32 CONCEPTO_TFG { get; set; }
 
	/// <summary>
    ///  Set or get the INCLUIDO_TFG property.
    /// </summary>
    
		public byte? INCLUIDO_TFG { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE_TFG property.
    /// </summary>
    
		public Decimal? IMPORTE_TFG { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
	}
}
