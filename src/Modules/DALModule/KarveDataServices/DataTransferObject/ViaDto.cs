using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class ViaDto: BaseDto
    {
        /// <summary>
        ///  Set or get the NUM_VIA property.
        /// </summary>

        public byte NUM_VIA { get; set; }

        /// <summary>
        ///  Set or get the OBS1 property.
        /// </summary>

        public string OBS1 { get; set; }

        /// <summary>
        ///  Set or get the ULTMODI property.
        /// </summary>

        public string ULTMODI { get; set; }

        /// <summary>
        ///  Set or get the USUARIO property.
        /// </summary>

        public string USUARIO { get; set; }

        /// <summary>
        ///  Set or get the NOMBRE property.
        /// </summary>

        public string NOMBRE { get; set; }

        bool IsInvalid()
        {
            var errors = base.HasErrors;
            if (!errors)
            {
                if ((NOMBRE != null) && (NOMBRE.Length > 35))
                {
                    return true;
                }
            }
            return errors;
        }
        public override bool HasErrors { get => IsInvalid(); set => base.HasErrors = value; }
    }
}
