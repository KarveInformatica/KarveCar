using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class BanksDto
    {
            /// <summary>
            ///  Set or get the CODBAN property.
            /// </summary>

            public string Codigo { get; set; }

            /// <summary>
            ///  Set or get the ULTMODI property.
            /// </summary>

            public string UltimaModification { get; set; }

            /// <summary>
            ///  Set or get the USUARIO property.
            /// </summary>

            public string Usuario { get; set; }

            /// <summary>
            ///  Set or get the NOMBRE property.
            /// </summary>

            public string Nombre { get; set; }

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
