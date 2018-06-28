using System;
 using Dapper;
using KarveDapper;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a PROVEE2.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	[Table("PROVEE2")]
	public class PROVEE2 
	{
	
	/// <summary>
    ///  Set or get the NUM_PROVEE property.
    /// </summary>
		[Key]
		public string NUM_PROVEE { get; set; }
 
	/// <summary>
    ///  Set or get the CENTRO property.
    /// </summary>
    
		public string CENTRO { get; set; }
 
	/// <summary>
    ///  Set or get the IDENTIFI property.
    /// </summary>
    
		public string IDENTIFI { get; set; }
 
	/// <summary>
    ///  Set or get the COMP1 property.
    /// </summary>
    
		public Decimal? COMP1 { get; set; }
 
	/// <summary>
    ///  Set or get the COMP2 property.
    /// </summary>
    
		public Decimal? COMP2 { get; set; }
 
	/// <summary>
    ///  Set or get the MARCA property.
    /// </summary>
    
		public string MARCA { get; set; }
 
	/// <summary>
    ///  Set or get the DTO property.
    /// </summary>
    
		public Decimal? DTO { get; set; }
 
	/// <summary>
    ///  Set or get the ULTIMA property.
    /// </summary>
    
		public DateTime? ULTIMA { get; set; }
 
	/// <summary>
    ///  Set or get the FORMA property.
    /// </summary>
    
		public byte? FORMA { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO property.
    /// </summary>
    
		public Int16? PLAZO { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO2 property.
    /// </summary>
    
		public Int16? PLAZO2 { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZO3 property.
    /// </summary>
    
		public Int16? PLAZO3 { get; set; }
 
	/// <summary>
    ///  Set or get the DIA property.
    /// </summary>
    
		public byte? DIA { get; set; }
 
	/// <summary>
    ///  Set or get the DIA2 property.
    /// </summary>
    
		public byte? DIA2 { get; set; }
 
	/// <summary>
    ///  Set or get the DIA3 property.
    /// </summary>
    
		public byte? DIA3 { get; set; }



        /// <summary>
        /// Get the supplier albaran.
        /// </summary>
        public char? PALBARAN {
            get;
            set; }

        /// <summary>
        ///  Set or get the PP property.
        /// </summary>

        public Decimal? PP { get; set; }
 
	/// <summary>
    ///  Set or get the MONEDA property.
    /// </summary>
    
		public string MONEDA { get; set; }
 
	/// <summary>
    ///  Set or get the INTRACO property.
    /// </summary>
    
		public byte? INTRACO { get; set; }
 
	/// <summary>
    ///  Set or get the PREFIJO property.
    /// </summary>
    
		public string PREFIJO { get; set; }
 
	/// <summary>
    ///  Set or get the CONTABLE property.
    /// </summary>
    
		public string CONTABLE { get; set; }
 
	/// <summary>
    ///  Set or get the VALOR property.
    /// </summary>
    
		public Decimal? VALOR { get; set; }
 
	/// <summary>
    ///  Set or get the FORPA property.
    /// </summary>
    
		public byte? FORPA { get; set; }
 
	/// <summary>
    ///  Set or get the ALBARANES property.
    /// </summary>
    
		public string ALBARANES { get; set; }
 
	/// <summary>
    ///  Set or get the SALIR property.
    /// </summary>
    
		public string SALIR { get; set; }
 
	/// <summary>
    ///  Set or get the IDIOMA property.
    /// </summary>
    
		public string IDIOMA { get; set; }
 
	/// <summary>
    ///  Set or get the COMERCIAL property.
    /// </summary>
    
		public string COMERCIAL { get; set; }
 
	/// <summary>
    ///  Set or get the CUGASTO property.
    /// </summary>
    
		public string CUGASTO { get; set; }
 
	/// <summary>
    ///  Set or get the FULTCOMP property.
    /// </summary>
    
		public DateTime? FULTCOMP { get; set; }
 
	/// <summary>
    ///  Set or get the ACTUAL property.
    /// </summary>
    
		public Decimal? ACTUAL { get; set; }
 
	/// <summary>
    ///  Set or get the RETENCION property.
    /// </summary>
    
		public string RETENCION { get; set; }
 
	/// <summary>
    ///  Set or get the DIVISA property.
    /// </summary>
    
		public string DIVISA { get; set; }
 
    
    
	/// <summary>
    ///  Set or get the EXCLUSIVIDAD property.
    /// </summary>
    
		public byte? EXCLUSIVIDAD { get; set; }
 
	/// <summary>
    ///  Set or get the CUESTIONARIO property.
    /// </summary>
    
		public byte? CUESTIONARIO { get; set; }
 
	/// <summary>
    ///  Set or get the PUNTUACION property.
    /// </summary>
    
		public Decimal? PUNTUACION { get; set; }
 
	/// <summary>
    ///  Set or get the HISTORICO property.
    /// </summary>
    
		public byte? HISTORICO { get; set; }
 
	/// <summary>
    ///  Set or get the CERTIF property.
    /// </summary>
    
		public byte? CERTIF { get; set; }
 
	/// <summary>
    ///  Set or get the PRUEBA property.
    /// </summary>
    
		public byte? PRUEBA { get; set; }
 
	
	/// <summary>
    ///  Set or get the TELF_ATENCION property.
    /// </summary>
    
		public string TELF_ATENCION { get; set; }
 
	/// <summary>
    ///  Set or get the TELF_ASISTENCIA property.
    /// </summary>
    
		public string TELF_ASISTENCIA { get; set; }
 
	/// <summary>
    ///  Set or get the TELF_ASISTENCIAINT property.
    /// </summary>
    
		public string TELF_ASISTENCIAINT { get; set; }
 
	/// <summary>
    ///  Set or get the CLAVEHAC_PRO property.
    /// </summary>
    
		public string CLAVEHAC_PRO { get; set; }
	}
}
