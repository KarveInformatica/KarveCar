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
        private ObservableCollection<string> _valuesCollection = new ObservableCollection<string>();

        public ObservableCollection<string> Items
        {
            set { _valuesCollection = value; }
            get { return _valuesCollection; }
        }
    }
}
