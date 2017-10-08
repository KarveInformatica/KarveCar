using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveControls.UIObjects
{
    //FIXME: fill the need of an abstract superclass
    public class UiDatePicker : UiDfObject
    {
        private DateTime _dateContent;
        private string _width;
        private string _height;

        
        public DateTime Date
        {
            get { return _dateContent; }
            set { _dateContent = value; }
        }
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
