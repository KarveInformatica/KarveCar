using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Company data transfer object
    /// </summary>
    public class CompanyDto : BaseDto
    {
        private string _name;
        private string _commercialName;

        public CompanyDto() : base()
        {
            City = new CityDto();
            Province = new ProvinciaDto();
            Country = new CountryDto();
            Offices = new List<OfficeDtos>();
        }
        public override string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override bool HasErrors
        {
            get
            {
                if ((Name != null) && (Name.Length > 80))
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }
                if ((CommercialName != null) && (CommercialName.Length > 250))
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }
                return false;
            }
        }

        // Commercial Name
        public string CommercialName { get { return _commercialName; }
            set { _commercialName = value; } }
        /// <summary>
        ///  Poblacion
        /// </summary>
        public string Poblacion { get; set; }
        /// <summary>
        ///  Nif
        /// </summary>
        public string Nif { get; set; }


        public CityDto City { get; set; }

        public ProvinciaDto Province { get; set; }

        public CountryDto Country { get; set; }
        /// <summary>
        ///  Offices of the company.
        /// </summary>
        public IEnumerable<OfficeDtos> Offices { get; set; }

        // this port the entity to the company

        public string CODIGO { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>
        [Required]
        public string NOMBRE { get { return _name; } set { _name = value; } }

        /// <summary>
        ///  Set or get the DIRECCION property.
        /// </summary>

        public string DIRECCION { get; set; }

        /// <summary>
        ///  Set or get the POBLACION property.
        /// </summary>

        public string POBLACION { get; set; }

        /// <summary>
        ///  Set or get the PROVINCIA property.
        /// </summary>

        public string PROVINCIA { get; set; }

        /// <summary>
        ///  Set or get the CP property.
        /// </summary>

        public string CP { get; set; }

        /// <summary>
        ///  Set or get the RESPONSA property.
        /// </summary>

        public string RESPONSA { get; set; }

        /// <summary>
        ///  Set or get the PROPIO property.
        /// </summary>

        public string PROPIO { get; set; }

        /// <summary>
        ///  Set or get the TELEFONO property.
        /// </summary>

        public string TELEFONO { get; set; }

        /// <summary>
        ///  Set or get the FAX property.
        /// </summary>

        public string FAX { get; set; }

        /// <summary>
        ///  Set or get the MODEM property.
        /// </summary>

        public string MODEM { get; set; }

        /// <summary>
        ///  Set or get the OBS1 property.
        /// </summary>

        public string OBS1 { get; set; }

        /// <summary>
        ///  Set or get the MULTAS property.
        /// </summary>

        public string MULTAS { get; set; }

        /// <summary>
        ///  Set or get the DNIMULTAS property.
        /// </summary>

        public string DNIMULTAS { get; set; }

        /// <summary>
        ///  Set or get the TIPO1 property.
        /// </summary>

        public string TIPO1 { get; set; }

        /// <summary>
        ///  Set or get the TIPO2 property.
        /// </summary>

        public string TIPO2 { get; set; }

        /// <summary>
        ///  Set or get the TIPO3 property.
        /// </summary>

        public string TIPO3 { get; set; }

        /// <summary>
        ///  Set or get the TIPO4 property.
        /// </summary>

        public string TIPO4 { get; set; }

        /// <summary>
        ///  Set or get the NIF property.
        /// </summary>

        public string NIF { get; set; }

        /// <summary>
        ///  Set or get the COBERTU property.
        /// </summary>

        public string COBERTU { get; set; }

        /// <summary>
        ///  Set or get the CLIENTE property.
        /// </summary>

        public string CLIENTE { get; set; }

        /// <summary>
        ///  Set or get the APORTACION property.
        /// </summary>

        public Decimal? APORTACION { get; set; }

        /// <summary>
        ///  Set or get the FEAPOR property.
        /// </summary>

        public DateTime? FEAPOR { get; set; }

        /// <summary>
        ///  Set or get the FACFEE property.
        /// </summary>

        public string FACFEE { get; set; }

        /// <summary>
        ///  Set or get the ROYALTY property.
        /// </summary>

        public Decimal? ROYALTY { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>

        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>

        public string USUARIO { get; set; }

        /// <summary>
        ///  Set or get the COMISIO property.
        /// </summary>

        public string COMISIO { get; set; }

        /// <summary>
        ///  Set or get the NUM_OFI property.
        /// </summary>

        public byte? NUM_OFI { get; set; }

        /// <summary>
        ///  Set or get the NUM_EMP property.
        /// </summary>

        public byte? NUM_EMP { get; set; }

        /// <summary>
        ///  Set or get the FAC_PREV property.
        /// </summary>

        public Decimal? FAC_PREV { get; set; }

        /// <summary>
        ///  Set or get the FEC_ALTA property.
        /// </summary>

        public DateTime? FEC_ALTA { get; set; }

        /// <summary>
        ///  Set or get the FEC_BAJA property.
        /// </summary>

        public DateTime? FEC_BAJA { get; set; }

        /// <summary>
        ///  Set or get the IMPFEE property.
        /// </summary>

        public Decimal? IMPFEE { get; set; }

        /// <summary>
        ///  Set or get the DIAMINFEE property.
        /// </summary>

        public byte? DIAMINFEE { get; set; }

        /// <summary>
        ///  Set or get the CONDI_SUB property.
        /// </summary>

        public string CONDI_SUB { get; set; }

        /// <summary>
        ///  Set or get the CCOSTE_SUB property.
        /// </summary>

        public string CCOSTE_SUB { get; set; }

        /// <summary>
        ///  Set or get the PASS_SUB property.
        /// </summary>

        public string PASS_SUB { get; set; }

        /// <summary>
        ///  Set or get the TARTRANS property.
        /// </summary>

        public string TARTRANS { get; set; }

        /// <summary>
        ///  Set or get the PROSPECCION property.
        /// </summary>

        public byte? PROSPECCION { get; set; }

        /// <summary>
        ///  Set or get the ORIGEN_CONFIG property.
        /// </summary>

        public byte? ORIGEN_CONFIG { get; set; }

        /// <summary>
        ///  Set or get the COD_SOCIEDAD property.
        /// </summary>

        public string COD_SOCIEDAD { get; set; }

        /// <summary>
        ///  Set or get the GRUPO_EMP property.
        /// </summary>

        public string GRUPO_EMP { get; set; }

        /// <summary>
        ///  Set or get the NO_ACTIVA property.
        /// </summary>

        public byte? NO_ACTIVA { get; set; }

        /// <summary>
        ///  Set or get the NOMCOMER property.
        /// </summary>

        public string NOMCOMER
        {
            get { return _commercialName; }
            set { _commercialName = value; }
        }
    /// <summary>
///  Set or get the PERSONA property.
/// </summary>

public string PERSONA { get; set; }

        /// <summary>
        ///  Set or get the RESPDNI property.
        /// </summary>

        public string RESPDNI { get; set; }

        /// <summary>
        ///  Set or get the NACIO property.
        /// </summary>

        public string NACIO { get; set; }

        /// <summary>
        ///  Set or get the USUARIOWEB_EMP property.
        /// </summary>

        public string USUARIOWEB_EMP { get; set; }

        /// <summary>
        ///  Set or get the PWDWEB_EMP property.
        /// </summary>

        public string PWDWEB_EMP { get; set; }


    }
}
