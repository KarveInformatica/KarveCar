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
	    
        private  _name;
        
        private  _oficina;
        
        
		[Display(Name = "Nombre", Description ="Nombre Usuario")]
		public  NameValue
       {
           set
           {
               _name = value;
               RaisePropertyChanged("NameValue");
           }
           get => _name;
     }
        
		[Display(Name = "Oficina", Description ="Oficina")]
		public  OfficeValue
       {
           set
           {
               _oficina = value;
               RaisePropertyChanged("OfficeValue");
           }
           get => _oficina;
     }
        
    
    }
   
}