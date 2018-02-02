using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Client Type Dto. Client Data Transfer Object
    /// </summary>
   
    public class ClientTypeDto: BaseDto
    {
        /// <summary>
        ///  Code. Code of the type.
        /// </summary>
        [PrimaryKey]
        [Display(Name = "Codigo", Description ="Codigo Tipo Cliente")]
        public string Code { set; get; }
        /// <summary>
        ///  Name. Name of the type.
        /// </summary>
        [Display(Name="Importancia", Description = "Tipo Cliente")]
        public string Name { set; get; }
      
    }
}
