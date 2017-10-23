using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CONTRA_CANCELA_CARGOS.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CONTRA_CANCELA_CARGOS 
	{
	
	/// <summary>
    ///  Set or get the CONTRATO_CCC property.
    /// </summary>
    
		public string CONTRATO_CCC { get; set; }
 
	/// <summary>
    ///  Set or get the PROPUESTA_CCC property.
    /// </summary>
    
		public Int32 PROPUESTA_CCC { get; set; }
 
	/// <summary>
    ///  Set or get the TCARGO_CCC property.
    /// </summary>
    
		public byte TCARGO_CCC { get; set; }
 
	/// <summary>
    ///  Set or get the LINEA property.
    /// </summary>
    
		public Int32 LINEA { get; set; }
 
	/// <summary>
    ///  Set or get the DESCRIP_CCC property.
    /// </summary>
    
		public string DESCRIP_CCC { get; set; }
 
	/// <summary>
    ///  Set or get the IMPORTE_CCC property.
    /// </summary>
    
		public Decimal? IMPORTE_CCC { get; set; }
	}
}
