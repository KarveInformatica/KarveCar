using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices
{
    public class ContractSummaryDto
    {
        /// <summary>
        ///  Codigo di contacto.
        /// </summary>
        [Display(Name = "Numero")]
        public string Code { get; set; }
        [Display(Name = "Desde")]
        public DateTime? StartingFrom { get; set; }
        [Display(Name = "Ora de Salida")]
        public DateTime? HourDateTimeFrom { get; set; }
        [Display(Name = "Hasta")]
        public DateTime? ReturnDate { get; set; }
        [Display(Name = "Ora de Salida")]
        public DateTime? HourDateTimeTo { get; set; }
        [Display(Name = "Dia")]
        public string Days { set; get; }
        [Display(Name = "Lugar de Entrega")]
        public string DeliveringPlace { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Codigo Cliente")]
        public string ClientCode { get; set; }
        [Display(Name = "Nombre Cliente")]
        public string ClientName { set; get; }
        [Display(Name = "Codigo Conductor")]
        public string DriverCode { get; set; }
        [Display(Name = "Nombre Conductor")]
        public string DriverName { get; set; }
        [Display(Name = "Codigo Vehiculos")]
        public string VehicleCode { get; set; }
        [Display(Name = "Matricula Vehiculos")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Marca Vehiculos")]
        public string VehicleBrand { get; set; }
        [Display(Name = "Modelo Vehiculos")]
        public string VehicleModel { get; set; }
       

    }
}