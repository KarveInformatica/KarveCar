using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a Reg_Novel.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class Reg_Novel 
	{
	
	/// <summary>
    ///  Set or get the Id_Reg property.
    /// </summary>
    
		public Int32 Id_Reg { get; set; }
 
	/// <summary>
    ///  Set or get the Fecha property.
    /// </summary>
    
		public DateTime? Fecha { get; set; }
 
	/// <summary>
    ///  Set or get the Texto property.
    /// </summary>
    
		public string Texto { get; set; }
 
	/// <summary>
    ///  Set or get the Descripcion property.
    /// </summary>
    
		public string Descripcion { get; set; }
 
	/// <summary>
    ///  Set or get the Usuario property.
    /// </summary>
    
		public string Usuario { get; set; }
 
	/// <summary>
    ///  Set or get the Emp_Pedido property.
    /// </summary>
    
		public string Emp_Pedido { get; set; }
 
	/// <summary>
    ///  Set or get the Pers_pedido property.
    /// </summary>
    
		public string Pers_pedido { get; set; }
 
	/// <summary>
    ///  Set or get the Version property.
    /// </summary>
    
		public string Version { get; set; }
	}
}
