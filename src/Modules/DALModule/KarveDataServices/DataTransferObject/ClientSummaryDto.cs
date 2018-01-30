using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// This is the client summary dto.
    /// </summary>
    public class ClientSummaryDto: BaseDto
    {

        [Display(Name = "Numero Cliente")]
        public string Number { set; get; }
        [Display(Name = "Nombre Cliente")]
        public string Name { set; get; }
        [Display(Name = "Nif")]
        public string Nif { set; get; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Telefono { set; get; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Movil")]
        public string Movil { set; get; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { set; get; }
        [Display(Name = "Tipo carta credito")]
        public string CreditCardType { set; get; }
        [Display(Name = "Numero carta credito")]
        [DataType(DataType.CreditCard)]
        public string NumberCreditCard { set; get; }
        // conta contable.
        [Display(Name = "Conta Contable")]
        public string AccountableAccount { set; get; }
        [Display(Name = "Vehiculo Sustitivo")]
        public bool ReplacementVeichle { set; get; }
        [Display(Name = "Direccion")]
        public string Direction { set; get; }
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
        public DateTime Falta { set; get; }
        [Display(Name = "Fecha Nacimento")]
        public DateTime FNacimiento { set; get; }

    }
}
