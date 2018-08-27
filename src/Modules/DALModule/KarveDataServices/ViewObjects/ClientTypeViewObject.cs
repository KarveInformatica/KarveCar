using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  Client Type Dto. Client Data Transfer Object
    /// </summary>
   
    public class ClientTypeViewObject: BaseViewObjectDefaultName
    {
        /// <summary>
        ///  Code. Code of the type.
        /// </summary>
        [PrimaryKey]
        [Display(Name = "Codigo", Description ="Codigo Tipo Cliente")]
        public override string Code { set; get; }
        /// <summary>
        ///  Name. Name of the type.
        /// </summary>
        [Display(Name="Importancia", Description = "Tipo Cliente")]
        public override string Name { set; get; }
      
    }
}
