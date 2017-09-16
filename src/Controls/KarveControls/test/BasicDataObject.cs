using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KarveControlsTest
{
    public class BasicDataObject
    {
        private string _label;
        private string _width;
        private string _field;
        private DataTable _auxTable;
        private DataTable _dataTable;

        public string Label
        {
            set
            {
                _label = value;
            }

            get
            {
                return _label;
            }
        }
        public string Width
        {
            set
            {
                _width = value;
            }

            get
            {
                return _width;
            }
        }

        public string DataField
        {
            set
            {
                _field = value;
            }

            get
            {
                return _field;
            }
        }


    }
}
