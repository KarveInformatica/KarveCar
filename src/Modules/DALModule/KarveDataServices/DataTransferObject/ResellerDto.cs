using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    public class ResellerDto: BaseDto
    {

        public ResellerDto()
        {
            City = new CityDto();
            Province = new ProvinciaDto();
            Country = new CountryDto();
        }
        /// <summary>
        ///  Reseller code.
        /// </summary>
        [Display(Name = "Codigo ")]
        public override string Code { get; set; }

        /// <summary>
        ///  Reseller Name.
        /// </summary>
        [Display(Name = "Nombre")]
        public override string Name { get; set; }
        /// <summary>
        ///  Reseller direciton.
        /// </summary>
        [Display(Name = "Dirección ")]
        public string Direction { get; set; }

        /// <summary>
        ///  Set or get the POBLACION property.
        /// </summary>
        [Display(Name = "Poblacion ")]

        public CityDto City { get; set; }

        /// <summary>
        ///  Set or get the PROVINCIA property.
        /// </summary>
        [Display(Name = "Provincia ")]
        public ProvinciaDto Province { get; set; }
        /// <summary>
        ///  Set or get the NACIOPER property.
        /// </summary>

        /// <summary>
        ///  Set or get the NACIODOMI property.
        /// </summary>
        [Display(Name = "Codigo Pais")]
        public string CountryDomain { get; set; }

        /// <summary>
        ///  Set or get the CP property.
        /// </summary>
        [Display(Name = "CP")]

        public string Zip { get; set; }

       

        /// <summary>
        ///  Set or get the TELEFONO property.
        /// </summary>
        [Display(Name = "Telefono")]

        public string Phone { get; set; }

        /// <summary>
        ///  Set or get the ZONA property.
        /// </summary>
        [Display(Name = "Zona")]

        public string Zone { get; set; }

        /// <summary>
        ///  Set or get the SUELDO property.
        /// </summary>

        public Decimal? Salary { get; set; }

        /// <summary>
        ///  Set or get the OBS1 property.
        /// </summary>
        [Display(Name = "Notes")]
        public string Observation { get; set; }

        /// <summary>
        ///  Set or get the NIF property.
        /// </summary>

        public string Nif { get; set; }

       
        public string Fax { get; set; }

        /// <summary>
        ///  Set or get the MOVIL property.
        /// </summary>
        
        [Display(Name = "Movil")]
        public string CellPhone { get; set; }

        /// <summary>
        ///  Set or get the EMAIL property.
        /// </summary>
        [Display(Name = "Email")]
        public string Email {
            get
            {
                string tmpMail = _email;
                if (tmpMail != null)
                {
                    tmpMail.Replace('#', '@');
                    _email = tmpMail;
                }
                return _email;   
            }
            set
            {
                string tmpMail = _email;
                if (tmpMail != null)
                {
                    tmpMail.Replace('@', '#');
                    _email = tmpMail;
                }
            }
        }

        /// <summary>
        ///  Set or get the FECHALTA property.
        /// </summary>

        public DateTime? StartDate { get; set; }

        /// <summary>
        ///  Set or get the FECHABAJA property.
        /// </summary>

        public DateTime? LeaveDate { get; set; }

        /// <summary>
        ///  Set or get the CTACAJA property.
        /// </summary>

        public string Ctacaja { get; set; }

        /// <summary>
        ///  Set or get the DIR_VENDE property.
        /// </summary>

        public string ResellerDirection { get; set; }

        /// <summary>
        ///  Set or get the WEB property.
        /// </summary>

        public string Web { get; set; }

        /// <summary>
        ///  Set or get the NOTAS property.
        /// </summary>

        public string Notes { get; set; }

        /// <summary>
        ///  Set or get the TIPO_VENDE property.
        /// </summary>

        public string ResellerType { get; set; }

        /// <summary>
        ///  Set or get the COORDGPS property.
        /// </summary>

        public string Coordgps { get; set; }

        /// <summary>
        ///  Set or get the MOVIL2 property.
        /// </summary>

        public string CellPhone2 { get; set; }

        /// <summary>
        ///  Set or get the ZONA_VENDE property.
        /// </summary>

        public string ResellerZone { get; set; }

        /// <summary>
        ///  Set or get the DEPARTAMENTO_VEND property.
        /// </summary>

        public string DEPARTAMENTO_VEND { get; set; }

        /// <summary>
        ///  Set or get the PERSONAL_VE property.
        /// </summary>

        public string PERSONAL_VE { get; set; }

        /// <summary>
        ///  Set or get the PORCOMI property.
        /// </summary>

        public Decimal? PORCOMI { get; set; }

        /// <summary>
        ///  Set or get the BPID property.
        /// </summary>

        public string BPID { get; set; }

        /// <summary>
        ///  Set or get the TRASPASA_CARTERA property.
        /// </summary>

        public byte? TRASPASA_CARTERA { get; set; }

        /// <summary>
        ///  Set or get the ES_AMAZON property.
        /// </summary>

        public byte? ES_AMAZON { get; set; }

        /// <summary>
        ///  Set or get the FOTOFIRMA property.
        /// </summary>

        public string Contacto { get; set; }

        public Int32? FOTOFIRMA { get; set; }

        public CountryDto Country { get; set; }
    }
}