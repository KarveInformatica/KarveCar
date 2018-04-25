using System;
 using Dapper;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a ASI.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("ASI")]
	public class Asi 
	{
	
	/// <summary>
    ///  Set or get the CTA property.
    /// </summary>
     public string CTA { get; set; }
 
	/// <summary>
    ///  Set or get the ASI property.
    /// </summary>
		public string ASI { get; set; }
	}
}
