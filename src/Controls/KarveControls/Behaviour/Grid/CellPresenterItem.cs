using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.Behaviour.Grid
{

    /// <summary>
    ///  CellPresenterItem. This is a class for presenting a cell.
    /// </summary>
    public class CellPresenterItem
    {
        // Set or get the name of the mapping 
        public string MappingName { set; get; } = string.Empty;
        /// <summary>
        /// Name of the cell in display mode. 
        /// </summary>
        public string DataTemplateName { set; get; } = string.Empty;
        /// <summary>
        ///  Set or Get if the field is readonly
        /// </summary>
        public bool IsReadOnly { set; get; } = false;
        /// <summary>
        ///  Name of the cell in edit mode.
        /// </summary>
        public string EditTemplateName { get; set; } = string.Empty;

        public bool NoTemplate { get; set; } = false;

    }
    
}
