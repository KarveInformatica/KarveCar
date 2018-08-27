using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.ViewObjects
{
    public class ClientSummaryExtended: BaseViewObject
    {
        private string _eMail;

        public ClientSummaryExtended()
        {
            Code = string.Empty;
            Name = string.Empty;
            Nif = string.Empty;
            Phone = string.Empty;
            Movil = string.Empty;
            Email = string.Empty;
            Direction = string.Empty;
            Zip = string.Empty;
            City = string.Empty;
            CreditCardType = string.Empty;
            NumberCreditCard = string.Empty;
            PaymentForm = string.Empty;
            AccountableAccount = string.Empty;
            Sector = string.Empty;
            Zone = string.Empty;
            Origin = string.Empty;
            Reseller = string.Empty;
            Office = string.Empty;
            Falta = DateTime.Now;
            BirthDate = DateTime.Now;
        }
       
        [Display(Name = "Numero")]
        public new string  Code { set; get; }
        [Display(Name = "Nombre Cliente")]
        public new string Name { set; get; }
        [Display(Name = "Nif")]
        public string Nif { set; get; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Phone { set; get; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Movil")]
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
        [Display(Name = "Direccion")]
        public string Direction { set; get; }

        [Display(Name = "Codigo Postal")]
        public string Zip { set; get; }
        [Display(Name = "Poblacion")]
        public string City { set; get; }

        [Display(Name = "Tipo carta credito")]
        public string CreditCardType { set; get; }
        [Display(Name = "Numero carta credito")]
        [DataType(DataType.CreditCard)]
        public string NumberCreditCard { set; get; }
        [Display(Name = "Forma Cobro")]
        public string PaymentForm { set; get; }
        // conta contable.
        [Display(Name = "Conta Contable")]
        public string AccountableAccount { set; get; }
        [Display(Name = "Sector")]
        public string Sector { set; get; }
        [Display(Name = "Zona")]
        public string Zone { set; get; }
        [Display(Name = "Origin")]
        public string Origin { set; get; }
        [Display(Name = "Vendidor")]
        public string Reseller { set; get; }
        [Display(Name = "Oficina")]
        public string Office { set; get; }
        [Display(Name = "Fecha Alta")]
        public DateTime? Falta { set; get; }
        [Display(Name = "Fecha Nacimiento")]
        public DateTime? BirthDate { set; get; }
        [Display(Name = "Vehiculo Sust.")]
        public string ReplacementCar { set; get; }
        [Display(Name = "Tarjeta")]
        public string Card { set; get; }
    }
}
