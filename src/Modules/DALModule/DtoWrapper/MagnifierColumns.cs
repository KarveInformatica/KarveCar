using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDapper;
using KarveDapper.Extensions;
namespace DataAccessLayer.DtoWrapper
{
    [KarveDapper.Extensions.Table("USER_LUPAS_COLUMNAS")]
    public class MagnifierColumns: IMagnifierColumns
    {

        /// <summary>
        ///  Magnifier id
        /// </summary>
        [KarveDapper.Extensions.Key]
        public int ID_COL { get; set; }
        // ID_LUPA
        public int ID_LUPA { get; set; }
        /// <summary>
        ///  COLUMNA_NOMBRE
        /// </summary>
        public string COLUMNA_NOMBRE { get; set; }
        /// <summary>
        ///  The columns is visible or not
        /// </summary>
        public byte? VISIBLE { get; set; }
        /// <summary>
        ///  The position is ok or not
        /// </summary>
        public int? POSICION { get; set; }
        /// <summary>
        ///  The width of the columns.
        /// </summary>
        public int? ANCHO { get; set; }
    }
}
