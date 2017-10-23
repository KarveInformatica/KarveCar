using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.UIObjects
{
    /// <summary>
    /// This is a data object for the ui data picker.
    /// </summary>
    public class UiDatePicker : UiDfObject
    {
        private DateTime _dateContent;
        private string _width;
      
        /// <summary>
        /// DateTime data time
        /// </summary>
        public DateTime Date
        {
            get { return _dateContent; }
            set { _dateContent = value; }
        }
        /// <summary>
        ///  Width size string.
        /// </summary>
        public string Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
    }
}
