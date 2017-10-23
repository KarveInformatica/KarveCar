using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a COBROS_LI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class COBROS_LI 
	{
	
	/// <summary>
    ///  Set or get the COBRO_LC property.
    /// </summary>
    
		public string COBRO_LC { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA_LC property.
    /// </summary>
    
		public Int32 LINEA_LC { get; set; }
 
	/// <summary>
    ///  Set or get the EXTRA_LC property.
    /// </summary>
    
		public Int32? EXTRA_LC { get; set; }
 
	/// <summary>
    ///  Set or get the DESCRIP_LC property.
    /// </summary>
    
		public string DESCRIP_LC { get; set; }
 
	/// <summary>
    ///  Set or get the UNIDADES_LC property.
    /// </summary>
    
		public Decimal? UNIDADES_LC { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE_LC property.
    /// </summary>
    
		public Decimal? IMPORTE_LC { get; set; }
 
	/// <summary>
    ///  Set or get the SUBTOTAL_LC property.
    /// </summary>
    
		public Decimal? SUBTOTAL_LC { get; set; }
	}
}
