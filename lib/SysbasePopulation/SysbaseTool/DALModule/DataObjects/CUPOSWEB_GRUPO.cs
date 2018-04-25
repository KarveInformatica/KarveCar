using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a CUPOSWEB_GRUPO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class CUPOSWEB_GRUPO 
	{
	
	/// <summary>
    ///  Set or get the CODIGO_CWG property.
    /// </summary>
    
		public Int32 CODIGO_CWG { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO_CWG property.
    /// </summary>
    
		public string GRUPO_CWG { get; set; }
 
	/// <summary>
    ///  Set or get the DESDE_CWG property.
    /// </summary>
    
		public DateTime? DESDE_CWG { get; set; }
 
	/// <summary>
    ///  Set or get the HASTA_CWG property.
    /// </summary>
    
		public DateTime? HASTA_CWG { get; set; }
 
	/// <summary>
    ///  Set or get the CUPO_CWG property.
    /// </summary>
    
		public Int32? CUPO_CWG { get; set; }
 
	/// <summary>
    ///  Set or get the BAJA_CWG property.
    /// </summary>
    
		public byte? BAJA_CWG { get; set; }
	}
}
