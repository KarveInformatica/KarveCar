using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KarveControls.Behaviour.Grid
{


    /// <summary>
    ///  NavigationAwareItem. It is a class for generating the line and associate navigation
    /// </summary>
    public class NavigationAwareItem : CellPresenterItem
    {
        /// <summary>
        /// Set or Get the action to execute.
        /// </summary>
        public ICommand Action { set; get; }
        /// <summary>
        ///  Set or get the region name to navigate to
        /// </summary>
        public string RegionName { set; get; }
    }


}
