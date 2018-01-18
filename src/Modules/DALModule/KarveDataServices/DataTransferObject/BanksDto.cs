using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class BanksDto : BaseDto
    {
            /// <summary>
            ///  Set or get the CODBAN property.
            /// </summary>

            public string Code { get; set; }

          
            /// <summary>
            ///  Set or get the USUARIO property.
            /// </summary>

            public string Usuario { get; set; }

            /// <summary>
            ///  Set or get the NOMBRE property.
            /// </summary>

            public string Name { get; set; }

            /// <summary>
            ///  Set or get the GESTIONAR property.
            /// </summary>

            public byte? GESTIONAR { get; set; }

            /// <summary>
            ///  Set or get the SWIFT property.
            /// </summary>

            public string Swift { get; set; }

            /// <summary>
            ///  Set or get the CTAPAGO_ASOCIA property.
            /// </summary>

            public string CTAPAGO_ASOCIA { get; set; }
        
    }
}
