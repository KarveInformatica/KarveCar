using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a AENA_LOG.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class AENA_LOG 
	{
	
	/// <summary>
    ///  Set or get the OPERACION property.
    /// </summary>
    
		public Int32 OPERACION { get; set; }
 
	/// <summary>
    ///  Set or get the CONCEPTO property.
    /// </summary>
    
		public Int32? CONCEPTO { get; set; }
 
	/// <summary>
    ///  Set or get the BRUTO property.
    /// </summary>
    
		public Decimal? BRUTO { get; set; }
 
	/// <summary>
    ///  Set or get the NETO property.
    /// </summary>
    
		public Decimal? NETO { get; set; }
 
	/// <summary>
    ///  Set or get the IMPUESTOS property.
    /// </summary>
    
		public Decimal? IMPUESTOS { get; set; }
 
	/// <summary>
    ///  Set or get the CONTRATO property.
    /// </summary>
    
		public string CONTRATO { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_OPERACION property.
    /// </summary>
    
		public Int32 TIPO_OPERACION { get; set; }
 
	/// <summary>
    ///  Set or get the FECHA_OP_KARVE property.
    /// </summary>
    
		public DateTime FECHA_OP_KARVE { get; set; }
 
	/// <summary>
    ///  Set or get the SALIDA property.
    /// </summary>
    
		public string SALIDA { get; set; }
 
	/// <summary>
    ///  Set or get the PREVISTA property.
    /// </summary>
    
		public string PREVISTA { get; set; }
 
	/// <summary>
    ///  Set or get the RETORNO property.
    /// </summary>
    
		public string RETORNO { get; set; }
 
	/// <summary>
    ///  Set or get the MATRICULA property.
    /// </summary>
    
		public string MATRICULA { get; set; }
 
	/// <summary>
    ///  Set or get the IATA_CREDENCIALES property.
    /// </summary>
    
		public string IATA_CREDENCIALES { get; set; }
 
	/// <summary>
    ///  Set or get the IATA_PARKING property.
    /// </summary>
    
		public string IATA_PARKING { get; set; }
 
	/// <summary>
    ///  Set or get the TOTAL_BRUTO property.
    /// </summary>
    
		public Decimal? TOTAL_BRUTO { get; set; }
 
	/// <summary>
    ///  Set or get the TOTAL_NETO property.
    /// </summary>
    
		public Decimal? TOTAL_NETO { get; set; }
 
	/// <summary>
    ///  Set or get the TOTAL_IMPUESTOS property.
    /// </summary>
    
		public Decimal? TOTAL_IMPUESTOS { get; set; }
 
	/// <summary>
    ///  Set or get the OBSERVACIONES property.
    /// </summary>
    
		public string OBSERVACIONES { get; set; }
 
	/// <summary>
    ///  Set or get the PARKING_MATRI_ENTRADA property.
    /// </summary>
    
		public string PARKING_MATRI_ENTRADA { get; set; }
 
	/// <summary>
    ///  Set or get the PARKING_MATRI_SALIDA property.
    /// </summary>
    
		public string PARKING_MATRI_SALIDA { get; set; }
 
	/// <summary>
    ///  Set or get the PARKING_MOTIVO property.
    /// </summary>
    
		public string PARKING_MOTIVO { get; set; }
	}
}
