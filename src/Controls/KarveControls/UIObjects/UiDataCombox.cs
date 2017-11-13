using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.UIObjects
{
    /// <summary>
    ///  UiDataCombox interface for the data template.
    /// </summary>
    public class UiDataCombox: UiDfObject
    {
        /// <summary>
        ///  Returns the collection item of an observable collection.
        /// </summary>
        public ObservableCollection<string> Items { set; get; } = new ObservableCollection<string>();
    }
}
