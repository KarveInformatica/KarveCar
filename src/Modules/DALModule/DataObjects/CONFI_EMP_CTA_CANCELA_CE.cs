using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONFI_EMP_CTA_CANCELA_CE.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONFI_EMP_CTA_CANCELA_CE 
	{
	
	/// <summary>
    ///  Set or get the EMPRESA_STC property.
    /// </summary>
    
		public string EMPRESA_STC { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA_STC property.
    /// </summary>
    
		public Int32 LINEA_STC { get; set; }
 
	/// <summary>
    ///  Set or get the STATUS_CLI_STC property.
    /// </summary>
    
		public byte STATUS_CLI_STC { get; set; }
 
	/// <summary>
    ///  Set or get the TCANCELA_STC property.
    /// </summary>
    
		public byte TCANCELA_STC { get; set; }
 
	/// <summary>
    ///  Set or get the CTA_STC property.
    /// </summary>
    
		public string CTA_STC { get; set; }
	}
}
