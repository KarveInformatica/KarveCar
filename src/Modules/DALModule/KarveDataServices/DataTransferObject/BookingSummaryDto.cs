using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Data transfer object for the booking.
    /// </summary>
    public class BookingSummaryDto: BaseDto
    {
        /// <summary>
        ///  Set or Get the booking number
        /// </summary>
        [Display(Name = "Numero", Description = "Numero reserva")]
        public string BookingNumber { set; get; }
        /// <summary>
        ///  Set or Get the booking date 
        /// </summary>
        [Display(Name = "Fecha Crea.", Description = "Fecha creacion reserva")]
        public DateTime BookingDate { set; get; }
        /// <summary>
        ///  Set or Get the locator 
        /// </summary>
        [Display(Name = "Localizador", Description = "Localizador reserva")]
        public string Locator { set; get; }

        /// <summary>
        ///  Ser to get the office zone
        /// </summary>
        [Display(Name = "OfficeZone", Description = "Zona Oficina")]
        public string OfficeZone { set; get; }
        /// <summary>
        ///  Set or Get the office
        /// </summary>
        [Display(Name = "OfficeCode", Description = "Codigo Oficina")]
        public string OfficeCode { set; get; }
        /// <summary>
        ///  Set or Get the office.
        /// </summary>
        [Display(Name = "OfficeName", Description = "Nombre Oficina")]
        public string OfficeName { set; get; }
        /// <summary>
        ///  Set or Get the driver code.
        /// </summary>
        [Display(Name = "Codigo Conductor", Description = "Conductor")]
        public string DriverCode { set; get; }
        /// <summary>
        ///  Set or get the driver name
        /// </summary>
        [Display(Name = "Conductor", Description = "Conductor")]
        public string DriverName { set; get; }
        /// <summary>
        ///  Set or get the driver code
        /// </summary>
        [Display(Name = "Codigo  Client", Description = "Codigo Cliente")]
        public string ClientCode { set; get; }
        /// <summary>
        ///  Set or get the driver name
        /// </summary>
        [Display(Name = "Client Name", Description = "Nombre Cliente")]
        public string ClientName { set; get; }

        /// <summary>
        ///  Set or get the departure date
        /// </summary>
        [Display(Name = "Fecha Salida", Description = "Fecha Salida")]
        public DateTime DepartureDate { set; get; }
        /// <summary>
        ///  Set or Get Hora Saldia
        /// </summary>
        [Display(Name = "Hora Salida", Description = "Hora Salida")]
        public string DepartureHour { set; get; }
        /// <summary>
        ///  Set or Get DeliveryPlace 
        /// </summary>
        /// <summary>
        [Display(Name = "Lugar Entrega", Description = "Lugar Entrega")]
        public string DeliveryPlace { set; get; }
        /// <summary>
        ///  Set or Get Fecha Prev.Retorno.
        /// </summary>
        [Display(Name = "Fecha Prev.Retorno", Description = "Fecha Prevista Retorno")]
        public DateTime ReturnDate { set; get; }

        /// <summary>
        ///  Hora prevista retorno.
        /// </summary>
        [Display(Name = "Hora Prev.Retorno", Description = "Hora Prevista Retorno")]
        public string ReturnTime { set; get; }

        [Display(Name = "Hora Prev.Retorno", Description = "Hora Prevista Retorno")]
        public DateTime ReturnHour { set; get; }

        [Display(Name = "Lugar Retorno", Description = "Lugar Retorno")]
        public string ReturnPlace { set; get; }

        [Display(Name = "Tarifa", Description = "Tarifa")]
        public string Fare { set; get; }

        [Display(Name = "Anulada", Description = "Anulada")]

        public string Confirmed { set; get; }
        [Display(Name = "Otro Conductor", Description = "Otro conductor")]

        public string OtherDriver { set; get; }
        [Display(Name = "Otro Conductor 2", Description = "Otro conductor")]

        public string OtherDriver2 { set; get; }
        [Display(Name = "Otro Conductor 2", Description = "Otro conductor")]

        public string OtherDriver3 { set; get; }

        [Display(Name = "Importe", Description = "Importe cobrado")]
        public long BookingBill { set; get; }

        [Display(Name = "Origen", Description = "Origen Reserva")]

        public string BookingOrigenName { set; get; }

        [Display(Name = "Bonus", Description = "Bonus")]

        public string Bonus  { set; get; }

        [Display(Name = "Comisionista", Description = "Comisionista")]

        public string BookingBroker { set; get; }
        /// <summary>
        ///  VehicleModel.
        /// </summary>
        [Display(Name = "Situacion Vehiculo", Description = "Situacion Vehiculo")]

        public string VehicleSituation { set; get; }
        /// <summary>
        ///  VehicleModel.
        /// </summary>
        [Display(Name = "Modelo", Description = "Modelo")]

        public string VehicleModel { set; get; }
        /// <summary>
        ///  Set or Get the booking number
        /// </summary>
        [Display(Name = "Data Rechazo", Description = "Data Rechazo")]
    

        public DateTime RejectionDate { set; get; }



        /// <summary>
        ///  Set or Get the booking group
        /// </summary>
        [Display(Name = "Grupo", Description = "Grupo")]

        public string BookingGroup { set; get; }
        /// <summary>
        ///  Set or Get the booker user.
        /// </summary>
        [Display(Name = "Codigo Usuario Reserva", Description = "Codigo Usuario Reserva")]

        public string BookerUserCode{ set; get; }
        /// <summary>
        ///  Booker user name
        /// </summary>
        [Display(Name = "Nombre Usuario Reserva", Description = "Nombre usuario che hice la reserva")]

        public string BookerUserName { set; get; }
        /// <summary>
        ///  Booking origin
        /// </summary>
        [Display(Name = "Origen Reserva", Description = "Origen Reserva")]

        public string BookingOrigin { set; get; }
        /// <summary>
        ///  Multiple direction
        /// </summary>

        public string MultipleDirection { set; get; }
        [Display(Name = "Total deposito", Description = "Total")]
    
        public decimal DepositTotal { set; get; }
        [Display(Name = "Deposito", Description = "Deposito")]

        public decimal Deposit { set; get; }
        /// <summary>
        ///  Set or get the notes.
        /// </summary>
        [Display(Name = "Observaciones", Description = "Observaciones")]

        public string Notes { set; get; }


        [Display(Name = "Codigo Empresa", Description = "Codigo Empresa")]

        public string CompanyCode { set; get; }

        [Display(Name = "Empresa", Description = "Empresa")]

        public string Company { set; get; }

        [Display(Name = "Contrato", Description = "Contrato")]

        public string Contract { set; get; }
        // Company code. 
        /// <summary>
        ///  Group
        /// </summary>
        [Display(Name = "Grupo", Description = "Grupo")]

        public string Group { set; get; }
        /// <summary>
        ///  Matricola
        /// </summary>
        [Display(Name = "Matricula", Description = "Matricula")]
        public string RegistrationNumber { set; get; }
       
        /// <summary>
        /// Anula reserva.
        /// </summary>
        [Display(Name = "Anula Reserva", Description = "Anula")]      
        public ICommand CancelBook { set; get; }

    }
}
