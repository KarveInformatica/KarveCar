using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  UserSummaryDto.
    /// </summary>
	public class UserSummaryDto: BaseDto
    {
	    
        private  _code;
        
        private  _booking;
        
        private  _name;
        
        private  _password;
        
        
		[Display(Name = "Codigo", Description ="Codigo Oficina")]
		public  CodeValue
       {
           set
           {
               _code = value;
               RaisePropertyChanged("CodeValue");
           }
           get => _code;
     }
        
		[Display(Name = "Oficina", Description ="Codigo Oficina")]
		public  OficinaValue
       {
           set
           {
               _booking = value;
               RaisePropertyChanged("OficinaValue");
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
        
		[Display(Name = "Password", Description ="Password")]
		public  PasswordValue
       {
           set
           {
               _password = value;
               RaisePropertyChanged("PasswordValue");
           }
           get => _password;
     }
        
    
    }
   
}