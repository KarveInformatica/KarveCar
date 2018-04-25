using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    /// VisitTypeDto. Tipo visita. 
    /// </summary>
    public class VisitTypeDto: BaseDto
    {
        /// <summary>
        ///  Codigo visita
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  Nombre
        /// </summary>
        public string Name { get; set; }
    }
}
