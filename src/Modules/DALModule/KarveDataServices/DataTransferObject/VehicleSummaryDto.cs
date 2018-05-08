using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  This is a vehicle summary 
    /// </summary>
    public class VehicleSummaryDto : BaseDto
    {

        [Display(Name = "Codigo", Description = "Codigo de vehiculo")]
        public string Code { set; get; }
        [Display(Name = "Marca", Description = "Marca de vehiculo")]
        public string Brand { set; get; }
        [Display(Name = "Modelo", Description = "Modelo de vehiculo")]
        public string Model { set; get; }
        [Display(Name = "Matricula", Description = "Matricula de vehiculo")]
        public string Matricula { set; get; }
        [Display(Name = "Grupo de Vehiculo", Description = "Grupo de vehiculo")]
        public string VehicleGroup { set; get; }
        [Display(Name = "Situacion", Description = "Situacion de vehiculo")]
        public string Situation { set; get; }
        [Display(Name = "Oficina", Description = "Oficina de vehiculo")]
        public string Office { set; get; }
        [Display(Name = "Plazas", Description = "Plazas vehiculo")]
        public byte? Places { set; get; }
        [Display(Name = "Metro cubico", Description = "Metro cubico")]
        public Decimal? CubeMeters { set; get; }
        [Display(Name = "Actividad", Description = "Actividad vehiculo")]
        public string Activity { set; get; }
        [Display(Name = "Color", Description = "Color vehiculo")]
        public string Color { set; get; }
        [Display(Name = "Propietario", Description = "Propietario vehiculo")]
        public string Owner { set; get; }
      
        [Display(Name = "Compania de seguro", Description = "Compania seguro")]
        public string AssuranceCompany { set; get; }
        [Display(Name = "Poliza", Description = "Poliza")]
        public string Policy { set; get; }
        [Display(Name = "Compania de Leasing", Description = "Leasing Company")]
        public string LeasingCompany { set; get; }
        [Display(Name = "Fecha Alta", Description = "Fecha Alta")]
        public DateTime StartingDate { set; get; }
        [Display(Name = "Fecha Baja", Description = "Fecha Baja")]
        public DateTime EndingDate { set; get; }
        [Display(Name = "Numero cliente", Description = "Numero  cliente")]
        public string ClientNumber { set; get; }
        [Display(Name = "Cliente", Description = "Cliente")]
        public string Client { set; get; }
        [Display(Name = "Factura compra", Description = "Factura compra")]
        public string PurchaseInvoice { set; get; }
        // bastidor 
        [Display(Name = "Bastidor", Description = "Bastidor")]
        public string  Frame { set; get; }
        [Display(Name = "Numero motor", Description = "Numero Motor")]
        public string MotorNumber { set; get; }
        [Display(Name = "Año Modelo", Description = "Numero Motor")]
        public string ModelYear { set; get; }
        [Display(Name = "Nombre Proprietario", Description = "Nombre Proprietario")]
        public string OwnerName { set; get; }
        [Display(Name = "Referencia", Description = "Referencia")]
        public string Reference { set; get; }
        [Display(Name = "Codigo llave", Description = "Codigo llave")]
        public string KeyCode { set; get; }
        [Display(Name = "Llave magazino", Description = "Llave magazino")]
        public string StorageKey { set; get; }
    }
}
