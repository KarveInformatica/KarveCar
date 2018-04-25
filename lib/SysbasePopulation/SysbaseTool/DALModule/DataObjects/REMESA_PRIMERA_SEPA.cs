using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a REMESA_PRIMERA_SEPA.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class REMESA_PRIMERA_SEPA 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the CLIENTE property.
    /// </summary>
    
		public string CLIENTE { get; set; }
 
	/// <summary>
    ///  Set or get the REMESA property.
    /// </summary>
    
		public string REMESA { get; set; }
 
	/// <summary>
    ///  Set or get the EMPRESA property.
    /// </summary>
    
		public string EMPRESA { get; set; }
 
	/// <summary>
    ///  Set or get the BANCO property.
    /// </summary>
    
		public string BANCO { get; set; }
 
	/// <summary>
    ///  Set or get the IBAN_DESTINO property.
    /// </summary>
    
		public string IBAN_DESTINO { get; set; }
	}
}
