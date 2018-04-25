using KarveDapper.Extensions;
using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a MODELO.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
    [Table("MODELO")]
	public class MODELO 
	{
	
	/// <summary>
    ///  Set or get the MARCA property.
    /// </summary>
    [ExplicitKey]
		public string MARCA { get; set; }
 
	/// <summary>
    ///  Set or get the CODIGO property.
    /// </summary>
        [Key]
		public string CODIGO { get; set; }
 
	/// <summary>
    ///  Set or get the VARIANTE property.
    /// </summary>
    [ExplicitKey]
		public string VARIANTE { get; set; }
 
	/// <summary>
    ///  Set or get the NOMBRE property.
    /// </summary>
    
		public string NOMBRE { get; set; }
 
	/// <summary>
    ///  Set or get the NOMMARCA property.
    /// </summary>
    
		public string NOMMARCA { get; set; }
 
	/// <summary>
    ///  Set or get the CATEGORIA property.
    /// </summary>
    
		public string CATEGORIA { get; set; }
 
	/// <summary>
    ///  Set or get the CONSUMO property.
    /// </summary>
    
		public Decimal? CONSUMO { get; set; }
 
	/// <summary>
    ///  Set or get the DEPOSITO property.
    /// </summary>
    
		public Decimal? DEPOSITO { get; set; }
 
	/// <summary>
    ///  Set or get the OBS1 property.
    /// </summary>
    
		public string OBS1 { get; set; }
 
	/// <summary>
    ///  Set or get the REFERE property.
    /// </summary>
    
		public string REFERE { get; set; }
 
	/// <summary>
    ///  Set or get the ULTMODI property.
    /// </summary>
    
		public string ULTMODI { get; set; }
 
	/// <summary>
    ///  Set or get the USUARIO property.
    /// </summary>
    
		public string USUARIO { get; set; }
 
	/// <summary>
    ///  Set or get the CHASIS property.
    /// </summary>
    
		public string CHASIS { get; set; }
 
	/// <summary>
    ///  Set or get the TIPOGAS property.
    /// </summary>
    
		public byte? TIPOGAS { get; set; }
 
	/// <summary>
    ///  Set or get the LLAVERO property.
    /// </summary>
    
		public string LLAVERO { get; set; }
 
	/// <summary>
    ///  Set or get the MANTECADA property.
    /// </summary>
    
		public Decimal? MANTECADA { get; set; }
 
	/// <summary>
    ///  Set or get the PUERTAS_MOD property.
    /// </summary>
    
		public string PUERTAS_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the PLAZAS_MOD property.
    /// </summary>
    
		public string PLAZAS_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the RADIO_MOD property.
    /// </summary>
    
		public byte? RADIO_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the AIREA_MOD property.
    /// </summary>
    
		public byte? AIREA_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the MOTOR_MOD property.
    /// </summary>
    
		public string MOTOR_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the SEGURI_MOD property.
    /// </summary>
    
		public string SEGURI_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the DIR_ASIS_MOD property.
    /// </summary>
    
		public Int16? DIR_ASIS_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the ABS property.
    /// </summary>
    
		public Int16? ABS { get; set; }
 
	/// <summary>
    ///  Set or get the CAMBIO_MOD property.
    /// </summary>
    
		public Int16? CAMBIO_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the ABS_MOD property.
    /// </summary>
    
		public Int16? ABS_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the RUTAFOTO property.
    /// </summary>
    
		public string RUTAFOTO { get; set; }
 
	/// <summary>
    ///  Set or get the POTENCIA property.
    /// </summary>
    
		public Decimal? POTENCIA { get; set; }
 
	/// <summary>
    ///  Set or get the CUBIC property.
    /// </summary>
    
		public Decimal? CUBIC { get; set; }
 
	/// <summary>
    ///  Set or get the RUEDAS property.
    /// </summary>
    
		public string RUEDAS { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO_CESION property.
    /// </summary>
    
		public string GRUPO_CESION { get; set; }
 
	/// <summary>
    ///  Set or get the COD_MOD property.
    /// </summary>
    
		public string COD_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the CILIN_MOD property.
    /// </summary>
    
		public string CILIN_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the FEBAJA property.
    /// </summary>
    
		public DateTime? FEBAJA { get; set; }
 
	/// <summary>
    ///  Set or get the FICHA property.
    /// </summary>
    
		public string FICHA { get; set; }
 
	/// <summary>
    ///  Set or get the RUTACROQUIS property.
    /// </summary>
    
		public string RUTACROQUIS { get; set; }
 
	/// <summary>
    ///  Set or get the FEMODELO property.
    /// </summary>
    
		public DateTime? FEMODELO { get; set; }
 
	/// <summary>
    ///  Set or get the PVP property.
    /// </summary>
    
		public Decimal? PVP { get; set; }
 
	/// <summary>
    ///  Set or get the PCOMPRA property.
    /// </summary>
    
		public Decimal? PCOMPRA { get; set; }
 
	/// <summary>
    ///  Set or get the AIRBAGS_MOD property.
    /// </summary>
    
		public string AIRBAGS_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the LUCES_DEPO property.
    /// </summary>
    
		public Int32? LUCES_DEPO { get; set; }
 
	/// <summary>
    ///  Set or get the RUTA_DOCUS property.
    /// </summary>
    
		public string RUTA_DOCUS { get; set; }
 
	/// <summary>
    ///  Set or get the CLI_HABITUAL property.
    /// </summary>
    
		public string CLI_HABITUAL { get; set; }
 
	/// <summary>
    ///  Set or get the DEE property.
    /// </summary>
    
		public string DEE { get; set; }
 
	/// <summary>
    ///  Set or get the TRACCION property.
    /// </summary>
    
		public string TRACCION { get; set; }
 
	/// <summary>
    ///  Set or get the ESVEHICULO_M property.
    /// </summary>
    
		public byte? ESVEHICULO_M { get; set; }
 
	/// <summary>
    ///  Set or get the CLI_DELEGA property.
    /// </summary>
    
		public string CLI_DELEGA { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO_MES property.
    /// </summary>
    
		public string GRUPO_MES { get; set; }
 
	/// <summary>
    ///  Set or get the WEIGHT property.
    /// </summary>
    
		public string WEIGHT { get; set; }
 
	/// <summary>
    ///  Set or get the HP property.
    /// </summary>
    
		public string HP { get; set; }
 
	/// <summary>
    ///  Set or get the IVA_MOD property.
    /// </summary>
    
		public Decimal? IVA_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the TEXTO_BASEOFERTA property.
    /// </summary>
    
		public string TEXTO_BASEOFERTA { get; set; }
 
	/// <summary>
    ///  Set or get the BASEOFERTA property.
    /// </summary>
    
		public string BASEOFERTA { get; set; }
 
	/// <summary>
    ///  Set or get the GRUPO_INFORME property.
    /// </summary>
    
		public Int32? GRUPO_INFORME { get; set; }
 
	/// <summary>
    ///  Set or get the ANNO_MODELO property.
    /// </summary>
    
		public string ANNO_MODELO { get; set; }
 
	/// <summary>
    ///  Set or get the RENDIMIENTO_VEHICULO_MOD property.
    /// </summary>
    
		public string RENDIMIENTO_VEHICULO_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the RENDIMIENTO_CARRETERA_MOD property.
    /// </summary>
    
		public string RENDIMIENTO_CARRETERA_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the RENDIMIENTO_CIUDAD_MOD property.
    /// </summary>
    
		public string RENDIMIENTO_CIUDAD_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the CILINDROS_MOD property.
    /// </summary>
    
		public string CILINDROS_MOD { get; set; }
 
	/// <summary>
    ///  Set or get the NOM_VARIANTE property.
    /// </summary>
    
		public string NOM_VARIANTE { get; set; }
 
	/// <summary>
    ///  Set or get the IMPUESTO property.
    /// </summary>
    
		public Decimal? IMPUESTO { get; set; }
 
	/// <summary>
    ///  Set or get the FT_5RUEDA property.
    /// </summary>
    
		public string FT_5RUEDA { get; set; }
 
	/// <summary>
    ///  Set or get the FT_ALTO property.
    /// </summary>
    
		public string FT_ALTO { get; set; }
 
	/// <summary>
    ///  Set or get the FT_ALTUTIL property.
    /// </summary>
    
		public string FT_ALTUTIL { get; set; }
 
	/// <summary>
    ///  Set or get the FT_ANCHO property.
    /// </summary>
    
		public string FT_ANCHO { get; set; }
 
	/// <summary>
    ///  Set or get the FT_ANCUTIL property.
    /// </summary>
    
		public string FT_ANCUTIL { get; set; }
 
	/// <summary>
    ///  Set or get the FT_ASIENTOS property.
    /// </summary>
    
		public string FT_ASIENTOS { get; set; }
 
	/// <summary>
    ///  Set or get the FT_AUTORIZA property.
    /// </summary>
    
		public string FT_AUTORIZA { get; set; }
 
	/// <summary>
    ///  Set or get the FT_BODEGA property.
    /// </summary>
    
		public string FT_BODEGA { get; set; }
 
	/// <summary>
    ///  Set or get the FT_CILINDROS property.
    /// </summary>
    
		public string FT_CILINDROS { get; set; }
 
	/// <summary>
    ///  Set or get the FT_CLASE property.
    /// </summary>
    
		public string FT_CLASE { get; set; }
 
	/// <summary>
    ///  Set or get the FT_CLASIF property.
    /// </summary>
    
		public string FT_CLASIF { get; set; }
 
	/// <summary>
    ///  Set or get the FT_COMER property.
    /// </summary>
    
		public string FT_COMER { get; set; }
 
	/// <summary>
    ///  Set or get the FT_CONTRASENA property.
    /// </summary>
    
		public string FT_CONTRASENA { get; set; }
 
	/// <summary>
    ///  Set or get the FT_CONTRASENA_AUX property.
    /// </summary>
    
		public string FT_CONTRASENA_AUX { get; set; }
 
	/// <summary>
    ///  Set or get the FT_CV property.
    /// </summary>
    
		public string FT_CV { get; set; }
 
	/// <summary>
    ///  Set or get the FT_EJE12 property.
    /// </summary>
    
		public string FT_EJE12 { get; set; }
 
	/// <summary>
    ///  Set or get the FT_EJE23 property.
    /// </summary>
    
		public string FT_EJE23 { get; set; }
 
	/// <summary>
    ///  Set or get the FT_EJE34 property.
    /// </summary>
    
		public string FT_EJE34 { get; set; }
 
	/// <summary>
    ///  Set or get the FT_FECHA property.
    /// </summary>
    
		public DateTime? FT_FECHA { get; set; }
 
	/// <summary>
    ///  Set or get the FT_LNGUTIL property.
    /// </summary>
    
		public string FT_LNGUTIL { get; set; }
 
	/// <summary>
    ///  Set or get the FT_LONG property.
    /// </summary>
    
		public string FT_LONG { get; set; }
 
	/// <summary>
    ///  Set or get the FT_MARCA property.
    /// </summary>
    
		public string FT_MARCA { get; set; }
 
	/// <summary>
    ///  Set or get the FT_MMA property.
    /// </summary>
    
		public string FT_MMA { get; set; }
 
	/// <summary>
    ///  Set or get the FT_MMA1 property.
    /// </summary>
    
		public string FT_MMA1 { get; set; }
 
	/// <summary>
    ///  Set or get the FT_MMA2 property.
    /// </summary>
    
		public string FT_MMA2 { get; set; }
 
	/// <summary>
    ///  Set or get the FT_MMA3 property.
    /// </summary>
    
		public string FT_MMA3 { get; set; }
 
	/// <summary>
    ///  Set or get the FT_MMA4 property.
    /// </summary>
    
		public string FT_MMA4 { get; set; }
 
	/// <summary>
    ///  Set or get the FT_MMR property.
    /// </summary>
    
		public string FT_MMR { get; set; }
 
	/// <summary>
    ///  Set or get the FT_MOTOR_MARCA property.
    /// </summary>
    
		public string FT_MOTOR_MARCA { get; set; }
 
	/// <summary>
    ///  Set or get the FT_MOTOR_TIPO property.
    /// </summary>
    
		public string FT_MOTOR_TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the FT_NEUMATICOS property.
    /// </summary>
    
		public string FT_NEUMATICOS { get; set; }
 
	/// <summary>
    ///  Set or get the FT_REFORMAS property.
    /// </summary>
    
		public string FT_REFORMAS { get; set; }
 
	/// <summary>
    ///  Set or get the FT_TARA property.
    /// </summary>
    
		public string FT_TARA { get; set; }
 
	/// <summary>
    ///  Set or get the FT_TIPO property.
    /// </summary>
    
		public string FT_TIPO { get; set; }
 
	/// <summary>
    ///  Set or get the FT_VARIANTE property.
    /// </summary>
    
		public string FT_VARIANTE { get; set; }
 
	/// <summary>
    ///  Set or get the FT_VIAS property.
    /// </summary>
    
		public string FT_VIAS { get; set; }
 
	/// <summary>
    ///  Set or get the FT_VOLADIZO property.
    /// </summary>
    
		public string FT_VOLADIZO { get; set; }
 
	/// <summary>
    ///  Set or get the CO2_GRxKM property.
    /// </summary>
    
		public string CO2_GRxKM { get; set; }
 
	/// <summary>
    ///  Set or get the REFERENCIA_MO property.
    /// </summary>
    
		public string REFERENCIA_MO { get; set; }
 
	/// <summary>
    ///  Set or get the TIPO_MO property.
    /// </summary>
    
		public string TIPO_MO { get; set; }
 
	/// <summary>
    ///  Set or get the REFACC_MO property.
    /// </summary>
    
		public string REFACC_MO { get; set; }
 
	/// <summary>
    ///  Set or get the REFACC2_MO property.
    /// </summary>
    
		public string REFACC2_MO { get; set; }
 
	/// <summary>
    ///  Set or get the CAPACIDAD_MO property.
    /// </summary>
    
		public Int32? CAPACIDAD_MO { get; set; }
 
	/// <summary>
    ///  Set or get the CENTROG_MO property.
    /// </summary>
    
		public Int32? CENTROG_MO { get; set; }
 
	/// <summary>
    ///  Set or get the PRECIO_MO property.
    /// </summary>
    
		public Decimal? PRECIO_MO { get; set; }
 
	/// <summary>
    ///  Set or get the CARACT_MO property.
    /// </summary>
    
		public string CARACT_MO { get; set; }
 
	/// <summary>
    ///  Set or get the COSTETRANS_MO property.
    /// </summary>
    
		public Decimal? COSTETRANS_MO { get; set; }
 
	/// <summary>
    ///  Set or get the SRV_SEGURO_MO property.
    /// </summary>
    
		public Decimal? SRV_SEGURO_MO { get; set; }
 
	/// <summary>
    ///  Set or get the SRV_IMPMATRIC_MO property.
    /// </summary>
    
		public Decimal? SRV_IMPMATRIC_MO { get; set; }
 
	/// <summary>
    ///  Set or get the SRV_NEUM_MO property.
    /// </summary>
    
		public Decimal? SRV_NEUM_MO { get; set; }
 
	/// <summary>
    ///  Set or get the SRV_MANT_MO property.
    /// </summary>
    
		public Decimal? SRV_MANT_MO { get; set; }
 
	/// <summary>
    ///  Set or get the SRV_VEHISITU_MO property.
    /// </summary>
    
		public Decimal? SRV_VEHISITU_MO { get; set; }
 
	/// <summary>
    ///  Set or get the SRV_KMS_MO property.
    /// </summary>
    
		public Decimal? SRV_KMS_MO { get; set; }
 
	/// <summary>
    ///  Set or get the SRV_OTROS_MO property.
    /// </summary>
    
		public Decimal? SRV_OTROS_MO { get; set; }
 
	/// <summary>
    ///  Set or get the PRODUCTO property.
    /// </summary>
    
		public string PRODUCTO { get; set; }
 
	/// <summary>
    ///  Set or get the IMPMATRICULAPOR property.
    /// </summary>
    
		public Decimal? IMPMATRICULAPOR { get; set; }
 
	/// <summary>
    ///  Set or get the MEXTRAS property.
    /// </summary>
    
		public string MEXTRAS { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_CONTROLVIN property.
    /// </summary>
    
		public string FTN_CONTROLVIN { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_NOMFABBASE property.
    /// </summary>
    
		public string FTN_NOMFABBASE { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_DIRFABBASE property.
    /// </summary>
    
		public string FTN_DIRFABBASE { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_CATEGORIA property.
    /// </summary>
    
		public string FTN_CATEGORIA { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_CARROCERIA property.
    /// </summary>
    
		public string FTN_CARROCERIA { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_COLOR property.
    /// </summary>
    
		public string FTN_COLOR { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_PROCEDE property.
    /// </summary>
    
		public string FTN_PROCEDE { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_HOMOLO property.
    /// </summary>
    
		public string FTN_HOMOLO { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_ANO property.
    /// </summary>
    
		public string FTN_ANO { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_MOM property.
    /// </summary>
    
		public string FTN_MOM { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_MMTAC property.
    /// </summary>
    
		public string FTN_MMTAC { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_MMC property.
    /// </summary>
    
		public string FTN_MMC { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_MASAREMOLC property.
    /// </summary>
    
		public string FTN_MASAREMOLC { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_BARRATRAC property.
    /// </summary>
    
		public string FTN_BARRATRAC { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_SEMIREMOL property.
    /// </summary>
    
		public string FTN_SEMIREMOL { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_REMOLEJECENT property.
    /// </summary>
    
		public string FTN_REMOLEJECENT { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_REMOLSINFRENO property.
    /// </summary>
    
		public string FTN_REMOLSINFRENO { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_ANCHMAXCARRO property.
    /// </summary>
    
		public string FTN_ANCHMAXCARRO { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_LONGMAXCARRO property.
    /// </summary>
    
		public string FTN_LONGMAXCARRO { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_VIAPOST property.
    /// </summary>
    
		public string FTN_VIAPOST { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_VOLPOST property.
    /// </summary>
    
		public string FTN_VOLPOST { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_VOLPOSTCARRO property.
    /// </summary>
    
		public string FTN_VOLPOSTCARRO { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_POSRUEDAS property.
    /// </summary>
    
		public string FTN_POSRUEDAS { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_EJESMOT property.
    /// </summary>
    
		public string FTN_EJESMOT { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_DIMNEUM property.
    /// </summary>
    
		public string FTN_DIMNEUM { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_POSCILINDROS property.
    /// </summary>
    
		public string FTN_POSCILINDROS { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_POTMOTOR property.
    /// </summary>
    
		public string FTN_POTMOTOR { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_TIPOCOMBUS property.
    /// </summary>
    
		public string FTN_TIPOCOMBUS { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_CINTURONES property.
    /// </summary>
    
		public string FTN_CINTURONES { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_PLAZASPIE property.
    /// </summary>
    
		public string FTN_PLAZASPIE { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_NIVELSO property.
    /// </summary>
    
		public string FTN_NIVELSO { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_VELSO property.
    /// </summary>
    
		public string FTN_VELSO { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_CO2 property.
    /// </summary>
    
		public string FTN_CO2 { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_CO property.
    /// </summary>
    
		public string FTN_CO { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_NIVELEMI property.
    /// </summary>
    
		public string FTN_NIVELEMI { get; set; }
 
	/// <summary>
    ///  Set or get the FTN_VELMAX property.
    /// </summary>
    
		public string FTN_VELMAX { get; set; }
	}
}
