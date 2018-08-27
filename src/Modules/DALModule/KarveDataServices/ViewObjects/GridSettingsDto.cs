using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  Data Transfer object for data trasnfer object.
    /// </summary>
    public class GridSettingsDto
    {
        /// <summary>
        /// Identifier of the grid
        /// </summary>
        public long GridIdentifier { get; set; }
        /// <summary>
        ///  Name of the grid.
        /// </summary>
        public string GridName { get; set; }
        /// <summary>
        /// XmlBase 64 of the serialized grid
        /// </summary>
        public string XmlBase64 { get; set; }
        /// <summary>
        ///  User of the grid
        /// </summary>
        public string User { get; set; }
        /// <summary>
        ///  Last modification of the grid.
        /// </summary>
        public DateTime LastModification { get; set; }

        /// <summary>
        ///  columns for a grid.
        /// </summary>
        public IEnumerable<string> AllowedColumns;
    }
}
