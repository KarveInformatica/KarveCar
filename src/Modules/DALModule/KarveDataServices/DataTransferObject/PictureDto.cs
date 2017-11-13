using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    public class PictureDto
    {
        /// <summary>
        ///  Set or get the CODIGO property.
        /// </summary>

        public string CODIGO { get; set; }

        /// <summary>
        ///  Set or get the EMPRESA property.
        /// </summary>

        public string EMPRESA { get; set; }

        /// <summary>
        ///  Set or get the COD_ASOCIADO property.
        /// </summary>

        public string COD_ASOCIADO { get; set; }

        /// <summary>
        ///  Set or get the FILENAME property.
        /// </summary>

        public string FILENAME { get; set; }

        /// <summary>
        ///  Set or get the PICTURE property.
        /// </summary>

        public byte[] PICTURE { get; set; }

        /// <summary>
        ///  Set or get the IDEN property.
        /// </summary>

        public string IDEN { get; set; }

    }
}
