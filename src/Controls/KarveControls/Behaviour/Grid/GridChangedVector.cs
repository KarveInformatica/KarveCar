using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.Behaviour.Grid
{

    /// <summary>
    ///  This a dictionary of paramteres to be changed
    /// </summary>
    public class GridChangedVector
    {

        public GridChangedVector()
        {
        }
        /// <summary>
        /// SourceView view of the source
        /// </summary>
        public object SourceView { set; get; }
        /// <summary>
        ///  Value changed
        /// </summary>
        public object ChangedValue { set; get; }
        /// <summary>
        ///  Row changed
        /// </summary>
        public long RowVector { set; get; }
        /// <summary>
        ///  PreviousValue
        /// </summary>
        public object PreviousValue { get; set; }

    }
}
