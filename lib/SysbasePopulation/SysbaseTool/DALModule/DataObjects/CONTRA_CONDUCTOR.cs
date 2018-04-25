using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONTRA_CONDUCTOR.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONTRA_CONDUCTOR 
	{
	
	/// <summary>
    ///  Set or get the NUMERO_CTR property.
    /// </summary>
    
		public string NUMERO_CTR { get; set; }
 
	/// <summary>
    ///  Set or get the CAMBIO property.
    /// </summary>
    
		public byte CAMBIO { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE property.
    /// </summary>
    
		public string CLIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_ALTA property.
    /// </summary>
    
		public DateTime? FEC_ALTA { get; set; }
 
	/// <summary>
    ///  Set or get the HOR_ALTA property.
    /// </summary>
    
		public TimeSpan? HOR_ALTA { get; set; }
 
	/// <summary>
    ///  Set or get the FEC_BAJA property.
    /// </summary>
    
		public DateTime? FEC_BAJA { get; set; }
 
	/// <summary>
    ///  Set or get the HOR_BAJA property.
    /// </summary>
    
		public TimeSpan? HOR_BAJA { get; set; }
 
	/// <summary>
    ///  Set or get the OBSERVACIONES property.
    /// </summary>
    
		public string OBSERVACIONES { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
	}
}
