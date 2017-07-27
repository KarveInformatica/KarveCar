using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataLayerExecutionException: Exception
    {
        public DataLayerExecutionException() : base("Cannot save the data. Null data object")
        {   
        }
    }
}
