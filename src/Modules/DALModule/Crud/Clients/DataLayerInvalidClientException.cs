using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Crud.Clients
{
    class DataLayerInvalidClientException: System.Exception
    {
        public DataLayerInvalidClientException(IList<string> errors)
        {
        }
    }
}
