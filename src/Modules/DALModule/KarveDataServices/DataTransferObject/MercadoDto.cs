//using System.ComponentModel.DataAnnotations;
namespace KarveDataServices.DataTransferObject
{
    public class MercadoDto: BaseDto
    {
        [PrimaryKey]
      //  [Display(Name = "Name of the Customer", Description = "CustomerName is necessary for identification ")]
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
}