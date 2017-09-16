using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  This object contains a simple property for page.
    /// </summary>
    public class PageParameterObject
    {
        private long _startPosition;
        public long startPos
        {
            set
            {
                _startPosition = value;
            }
            get
            {
                return _startPosition;
            }
        }
    }
}
