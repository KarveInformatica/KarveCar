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


        public override bool HasErrors
        {
            get
            {
                if ((Nombre != null) && (Nombre.Length > 35))
                {
                    ErrorList.Add(ConstantDataError.NameTooLong);
                    return true;
                }
                return false;
            }
        }

    }
}
