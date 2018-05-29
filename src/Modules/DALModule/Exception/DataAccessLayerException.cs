using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Exception
{
    /// <summary>
    ///  DataAccessLayerException is the exception for the data layer
    /// </summary>
    class DataAccessLayerException : System.Exception
    {
        public DataAccessLayerException(string message) : base(message)
        {

        }
        public DataAccessLayerException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
