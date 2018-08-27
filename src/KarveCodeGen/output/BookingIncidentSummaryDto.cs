using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  BookingIncidentSummaryDto.
    /// </summary>
	public class BookingIncidentSummaryDto: BaseDto
    {
	    
        private  _code;
        
        private  _booking;
        
        private  _name;
        
        
		[Display(Name = "Codigo", Description ="Codigo Incidencia Reserva")]
		public  CodeValue
       {
           set
           {
               _code = value;
               RaisePropertyChanged("CodeValue");
           }
           get => _code;
     }
        
		[Display(Name = "Reserva", Description ="Numero Reserva")]
		public  BookingValue
       {
           set
           {
               _booking = value;
               RaisePropertyChanged("BookingValue");
           }
           get => _booking;
     }
        
		[Display(Name = "Nombre", Description ="Nombre Incidencia")]
		public  NameValue
       {
           set
           {
               _name = value;
               RaisePropertyChanged("NameValue");
           }
           get => _name;
     }
        
    
    }
   
}