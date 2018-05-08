using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Data trasnfer for the contract
    /// </summary>
    public class ContractDto : BaseDto
    {
        /// <summary>
        ///  Codigo 
        /// </summary>
        [Display(Name = "Numero")]
        public string Code { get; set; }
        [Display(Name = "Desde")]
        public DateTime? StartingFrom { get; set; }
        [Display(Name = "Fecha de Salida")]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Data Entrega")]
        public DateTime? ReturnDate { get; set; }

        public string Days { set; get; }
        [Display(Name = "Data Entrega")]
        public string DeliveringPlace { get; set; }
        public string Name { get; set; }
        public string ClientCode { get; set; }
        public string DriverCode { get; set; }
        public string VehicleCode { get; set; }
    }
}