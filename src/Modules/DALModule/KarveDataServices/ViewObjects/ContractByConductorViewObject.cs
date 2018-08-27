using KarveDataServices.ViewObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace KarveDataServices
{
    /// <summary>
    ///  Data Transfer Object to get the contract in the case of 
    /// </summary>
    public class ContractByConductorViewObject: BaseViewObject
    {
        [Display(Name = "Contracto", Description = "Numero de Contracto")]
        public string ContractNo { set; get; }
        [Display(Name = "Desde", Description = "Data de empiezo")]
        public DateTime ContractFrom { set; get; }
        [Display(Name = "Hasta", Description = "Data de baja")]
        public DateTime ContractTo { set; get; }
        [Display(Name = "Conductor", Description = "Conductor de vehiculo")]
        public string Driver { set; get; }
        [Display(Name = "Matricula", Description = "Matricula de vehiculo")]
        public string CarNumber { set; get; }
        [Display(Name = "Marca", Description = "Marca de vehiculo")]
        public string Brand { set; get; }
        [Display(Name = "Modelo", Description = "Modelo de vehiculo")]
        public string Model { set; get; }
        [Display(Name = "Tarifa", Description = "Tarifa de vehiculo")]
        public string Fare { set; get; }
        [Display(Name = "Codigo Vehiculo", Description = "Codigo de vehiculo")]
        public string VehicleCode { set; get; }
    }
}