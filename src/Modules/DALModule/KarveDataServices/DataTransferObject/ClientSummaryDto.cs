using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// This is the client summary dto.
    /// </summary>
    public class ClientSummaryDto: BaseDto
    {

        private string _eMail;

        [Display(Name = "Numero Cliente")]
        public string Code { set; get; }
        [Display(Name = "Nombre Cliente")]
        public string Name { set; get; }
        [Display(Name = "Nif")]
        public string Nif { set; get; }
        [Display(Name = "Direccion")]
        public string Direction { set; get; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefono { set; get; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Movil")]
        public string Movil { set; get; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email
        {
            set
            {
                var email = value;
                _eMail = email.Replace('#', '@');
            }
            get
            {
                return _eMail;
            }
        }
        [Display(Name = "Tipo carta credito")]
        public string CreditCardType { set; get; }
        [Display(Name = "Numero carta credito")]
        [DataType(DataType.CreditCard)]
        public string NumberCreditCard { set; get; }
        // conta contable.
        [Display(Name = "Conta Contable")]
        public string AccountableAccount { set; get; }
       
        [Display(Name = "Codigo Postal")]
        public string Zip { set; get; }
        [Display(Name = "Poblacion")]
        public string City { set; get; }
        [Display(Name="Sector")]
        public string Sector { set; get; }
        [Display(Name = "Vendidor")]
        public string Reseller { set; get; }
        [Display(Name = "Oficina")]
        public string Office { set; get; }
        [Display(Name = "Fecha Alta")]
        public DateTime? Falta { set; get; }
        /*
        [Display(Name = "Fecha Nacimento")]
        public DateTime FNacimiento { set; get; }
        */
    }
}
