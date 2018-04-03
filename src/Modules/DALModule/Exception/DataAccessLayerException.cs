using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Exception
{
    class DataAccessLayerException : System.Exception
    {
        public DataAccessLayerException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
