using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Code actividad dto.
    /// </summary>
    public class ActividadDto : BaseDto
    {
        /// <summary>
        ///  Code of the activity
        /// </summary>
        public string Codigo { set; get; }
        /// <summary>
        ///  Name of the activity.
        /// </summary>
        public string Nombre { set; get; }
    }
}
