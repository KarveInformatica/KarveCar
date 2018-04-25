using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a EXC_PAGOS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class EXC_PAGOS 
	{
	
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
    
		public Int32 CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the NUMFRA property.
    /// </summary>
    
		public string NUMFRA { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA property.
    /// </summary>
    
		public DateTime? FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the BRUTO property.
    /// </summary>
    
		public Decimal? BRUTO { get; set; }
 
	/// <summary>
    ///  Set or get the IVA property.
    /// </summary>
    
		public Decimal? IVA { get; set; }
 
	/// <summary>
    ///  Set or get the FPAGO property.
    /// </summary>
    
		public string FPAGO { get; set; }
 
	/// <summary>
    ///  Set or get the PROVEE property.
    /// </summary>
    
		public string PROVEE { get; set; }
	}
}
